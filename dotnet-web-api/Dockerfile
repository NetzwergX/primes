FROM mcr.microsoft.com/dotnet/core/sdk:latest
WORKDIR /prime/web-api-dotnet/
COPY . .
RUN dotnet build
EXPOSE 5000
ENTRYPOINT ["dotnet", "run", "-p", "Prime.WebApi/"]