# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

COPY . /source

WORKDIR /source

RUN dotnet publish ./VehicleRegistryAPI/VehicleRegistries.sln --use-current-runtime --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

COPY --from=build /app .

USER $APP_UID
ENV ASPNETCORE_ENVIRONMENT="Development"

ENTRYPOINT ["dotnet", "fleet-of-knowledge.dll"]
