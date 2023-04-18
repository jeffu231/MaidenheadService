FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MaidenheadService/MaidenheadService.csproj", "MaidenheadService/"]
RUN dotnet restore "MaidenheadService/MaidenheadService.csproj"
COPY . .
WORKDIR "/src/MaidenheadService"
RUN dotnet build "MaidenheadService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MaidenheadService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MaidenheadService.dll"]
