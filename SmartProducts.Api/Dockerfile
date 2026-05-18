# SmartProducts.Api/Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el código fuente
COPY . .

# Restaurar el proyecto específico
RUN dotnet restore SmartProducts.Api/SmartProducts.Api.csproj

# Publicar la API
RUN dotnet publish SmartProducts.Api/SmartProducts.Api.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "SmartProducts.Api.dll"]
