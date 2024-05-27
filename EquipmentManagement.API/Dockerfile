#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EquipmentManagement.API/EquipmentManagement.API.csproj", "EquipmentManagement.API/"]
COPY ["EquipmentManagement.Application/EquipmentManagement.Application.csproj", "EquipmentManagement.Application/"]
COPY ["EquipmentManagement.Domain/EquipmentManagement.Domain.csproj", "EquipmentManagement.Domain/"]
COPY ["EquipmentManagement.Infrastructure/EquipmentManagement.Infrastructure.csproj", "EquipmentManagement.Infrastructure/"]
COPY ["EquipmentManagement.Persistence/EquipmentManagement.Persistence.csproj", "EquipmentManagement.Persistence/"]
RUN dotnet restore "./EquipmentManagement.API/EquipmentManagement.API.csproj"
COPY . .
WORKDIR "/src/EquipmentManagement.API"
RUN dotnet build "./EquipmentManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EquipmentManagement.API.csproj"  -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquipmentManagement.API.dll"]