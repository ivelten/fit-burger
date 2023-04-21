FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FitBurger.WebApi/FitBurger.WebApi.csproj", "src/FitBurger.WebApi/"]
RUN dotnet restore "src/FitBurger.WebApi/FitBurger.WebApi.csproj"
COPY . .
WORKDIR "/src/src/FitBurger.WebApi"
RUN dotnet build "FitBurger.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitBurger.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitBurger.WebApi.dll"]
