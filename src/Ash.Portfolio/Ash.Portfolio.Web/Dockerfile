FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Ash.Portfolio.Web/Ash.Portfolio.Web.csproj", "Ash.Portfolio.Web/"]
RUN dotnet restore "./Ash.Portfolio.Web/Ash.Portfolio.Web.csproj"
COPY . .
WORKDIR "/src/Ash.Portfolio.Web"
RUN dotnet build "./Ash.Portfolio.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Ash.Portfolio.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ash.Portfolio.Web.dll"]