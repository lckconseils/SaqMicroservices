#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/Commande/Commande.Api/Commande.Api.csproj", "Services/Commande/Commande.Api/"]
COPY ["Services/Commande/Commande.Infrastructure/Commande.Infrastructure.csproj", "Services/Commande/Commande.Infrastructure/"]
COPY ["Services/Commande/Commande.Application/Commande.Application.csproj", "Services/Commande/Commande.Application/"]
COPY ["Services/Commande/Commande.Domaine/Commande.Domaine.csproj", "Services/Commande/Commande.Domaine/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/Commande/Commande.Api/Commande.Api.csproj"
COPY . .
WORKDIR "/src/Services/Commande/Commande.Api"
RUN dotnet build "Commande.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Commande.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Commande.Api.dll"]
