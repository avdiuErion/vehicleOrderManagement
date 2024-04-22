FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EngineService.WebAPI/EngineService.WebAPI.csproj", "EngineService.WebAPI/"]
COPY ["SharedCore/SharedCore.csproj", "SharedCore/"]
COPY ["EngineService.ApplicationService/EngineService.ApplicationService.csproj", "EngineService.ApplicationService/"]
COPY ["EngineService.Domain/EngineService.Domain.csproj", "EngineService.Domain/"]
COPY ["EngineService.DataAccess/EngineService.DataAccess.csproj", "EngineService.DataAccess/"]
RUN dotnet restore "EngineService.WebAPI/EngineService.WebAPI.csproj"
COPY . .
WORKDIR "/src/EngineService.WebAPI"
RUN dotnet build "EngineService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EngineService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EngineService.WebAPI.dll"]
