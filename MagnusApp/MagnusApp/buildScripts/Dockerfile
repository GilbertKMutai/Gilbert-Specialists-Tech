FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /SRC

COPY MagnusApp/MagnusApp.csproj MagnusApp/
COPY MagnusApp.Client/MagnusApp.Client.csproj MagnusApp.Client/
COPY MagnusApp.Shared/MagnusApp.Shared.csproj MagnusApp.Shared/
RUN dotnet restore MagnusApp/MagnusApp.csproj

COPY . .
WORKDIR /src/MagnusApp
RUN dotnet build MagnusApp.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish MagnusApp.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8000
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagnusApp.dll"]
