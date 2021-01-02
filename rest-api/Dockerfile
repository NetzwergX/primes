FROM mcr.microsoft.com/dotnet/core/sdk:latest
WORKDIR /prime/rest-api/
COPY . .
RUN dotnet build
EXPOSE 5000
CMD ["dotnet", "run", "-p", "Prime.WebApi/", "--urls", "http://*:5000"]