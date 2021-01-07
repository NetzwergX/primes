param (
    [ValidateSet("quarkus", "dotnet-3.1")]
    [string] $backend = "quarkus"
)
Write-Host "Building primes with backend $backend"

docker network inspect primes-net | out-null

if(!$?) {
    Write-Host "Create network primes-net ..."
	docker network create --driver bridge primes-net
} else {
    Write-Host "Using existing network primes-net ..."
}

$apiUrl='http://api:5000'

docker container inspect api | out-null

if($?) {
    Write-Host "Stopping api container ..."
    docker container stop api
    Write-Host "Removing api container ..."
    docker container rm api
}

docker container inspect prime-app | out-null

if($?) {
    Write-Host "Stopping api container ..."
    docker container stop prime-app
    Write-Host "Removing api container ..."
    docker container rm prime-app
}

Write-Host "Building api container ($backend) ... "

if ($backend -eq "quarkus") {
    Push-Location quarkus-api
    ./mvnw clean package "-Dquarkus.container-image.build=true"
    Write-Host "Starting api container ..."
    docker run -d --name 'api' --network primes-net 'polygnome/prime-api:quarkus-1.0.0-SNAPSHOT'
    Pop-Location
} elseif ($backend -eq "dotnet-3.1") {
    Push-Location dotnet-web-api/
    dotnet publish -c Release
    Push-Location Prime.WebApi/
    docker build -t polygnome/prime-api:dotnet-3.1 .
    Write-Host "Starting api container ..."
    docker run -d --name 'api' --network primes-net 'polygnome/prime-api:dotnet-3.1' --urls $apiUrl
    Pop-Location
    Pop-Location
}

Write-Host "Starting web app container ..."

docker run `
    -v E:\dev\git\Primes\lighttpd\:/etc/lighttpd `
    -v E:\dev\git\Primes\web-app\dist\:/var/www/localhost/htdocs `
    --name prime-app --network primes-net `
    -dp 8080:8080 polygnome/lighttpd