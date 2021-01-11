FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /primes/web-api-dotnet/
COPY bin/Release/netcoreapp3.1/publish/ .

ENTRYPOINT ["dotnet", "Prime.WebApi.dll"]