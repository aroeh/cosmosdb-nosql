FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["CosmosDb.NoSql.API/CosmosDb.NoSql.API.csproj", "CosmosDb.NoSql.API/CosmosDb.NoSql.API/"]
COPY ["CosmosDb.NoSql.Core/CosmosDb.NoSql.Core.csproj", "CosmosDb.NoSql.Core/CosmosDb.NoSql.Core/"]
COPY ["CosmosDb.NoSql.Infrastructure/CosmosDb.NoSql.Infrastructure.csproj", "CosmosDb.NoSql.Infrastructure/CosmosDb.NoSql.Infrastructure/"]
COPY ["CosmosDb.NoSql.Shared/CosmosDb.NoSql.Shared.csproj", "CosmosDb.NoSql.Shared/CosmosDb.NoSql.Shared/"]

RUN dotnet restore "./CosmosDb.NoSql.API/CosmosDb.NoSql.API/CosmosDb.NoSql.API.csproj"

COPY . CosmosDb.NoSql.API/
WORKDIR "/src/CosmosDb.NoSql.API/CosmosDb.NoSql.API"

RUN dotnet build "./CosmosDb.NoSql.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CosmosDb.NoSql.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CosmosDb.NoSql.API.dll"]