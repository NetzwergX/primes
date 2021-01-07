FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /primes/rest-api/
COPY bin/Release/netcoreapp3.1/publish/ .

ENTRYPOINT ["dotnet", "Prime.WebApi.dll"]