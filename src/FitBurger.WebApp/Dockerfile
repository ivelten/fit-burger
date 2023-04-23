FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FitBurger.WebApp.csproj", "."]
RUN dotnet restore "FitBurger.WebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FitBurger.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitBurger.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "FitBurger.WebApp.dll"]
