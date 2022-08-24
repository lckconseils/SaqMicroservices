#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj", "Services/Promotion/Promotion.Grpc/"]
RUN dotnet restore "Services/Promotion/Promotion.Grpc/Promotion.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Promotion/Promotion.Grpc"
RUN dotnet build "Promotion.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Promotion.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Promotion.Grpc.dll"]
