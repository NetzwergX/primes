Write-Host "Building primes:api-dotnet-sdk ..."
docker build -t registry.gitlab.com/s.teumert/primes:api-dotnet-sdk rest-api/
Write-Host "Building primes:spa-node-webpack ..."
docker build -t registry.gitlab.com/s.teumert/primes:spa-node-webpack web-app/

# $ip = [Array]::Find(
#     @((Get-NetIPAddress).IPAddress),
#     [Predicate[string]]{ $args[0].StartsWith("172") }
# )

# Write-Host ("Running on {0}" -f $ip)
# $port = 5000
# $url = ("http://{0}:{1}/" -f $ip, $port)
# Write-Host ("Proxy URL: {0}" -f $url)

Write-Host "Create network primes-net ..."
docker network create --driver bridge primes-net

$apiUrl='http://prime-api:5000'

Write-Host "Stopping containers ..."
docker container stop prime-api prime-app
Write-Host "Removing containers ..."
docker container rm prime-api prime-app

Write-Host "Starting API ..."
docker run -d --name 'prime-api' --network primes-net 'registry.gitlab.com/s.teumert/primes:api-dotnet-sdk' --urls $apiUrl
Write-Host "Start web app ..."
docker run -dp 8080:8080 --name 'prime-app' --network primes-net 'registry.gitlab.com/s.teumert/primes:spa-node-webpack'  --host 0.0.0.0 --env proxyUrl=$apiUrl