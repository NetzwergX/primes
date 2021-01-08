#!/bin/sh

echo "Building frontend (Aurelia SPA) ..."
pushd aurelia-spa
npm install
npm run build
cp ./dist/* ../lighttpd/htdocs/
popd

echo "Building backend (Quarkus) ..."
pushd quarkus-api
./mvnw clean package
docker build -f .\src\main\docker\Dockerfile.jvm -t primes/prime-api/quarkus:latest .
popd

echo "Building backend (.Net Core 3.1) ..."
pushd dotnet-web-api/
dotnet publish -c Release
popd

docker-compose up "$@"