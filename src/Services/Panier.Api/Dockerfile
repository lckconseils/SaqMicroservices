#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/Panier.Api/Panier.Api.csproj", "Services/Panier.Api/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/Panier.Api/Panier.Api.csproj"
COPY . .
WORKDIR "/src/Services/Panier.Api"
RUN dotnet build "Panier.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Panier.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Panier.Api.dll"]
