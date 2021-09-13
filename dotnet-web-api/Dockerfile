FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /prime/dotnet-web-api/
COPY . .
RUN dotnet publish -c Release -r linux-x64

FROM ubuntu:20.04
WORKDIR /prime/backend/
COPY --from=build /prime/dotnet-web-api/Prime.WebApi/bin/Release/netcoreapp3.1/linux-x64/publish/ ./

EXPOSE 5000
ENTRYPOINT ["./Prime.WebApi"]
