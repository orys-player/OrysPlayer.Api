# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

# SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrysPlayer.Api/OrysPlayer.Api.csproj", "OrysPlayer.Api/"]
RUN dotnet restore "OrysPlayer.Api/OrysPlayer.Api.csproj"
COPY . .
WORKDIR "/src/OrysPlayer.Api"
RUN dotnet build "OrysPlayer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish step
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrysPlayer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrysPlayer.Api.dll"]
