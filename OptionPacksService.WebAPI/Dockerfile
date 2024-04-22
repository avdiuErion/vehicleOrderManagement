FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OptionPacksService.WebAPI/OptionPacksService.WebAPI.csproj", "OptionPacksService.WebAPI/"]
COPY ["SharedCore/SharedCore.csproj", "SharedCore/"]
COPY ["OptionPacksService.ApplicationService/OptionPacksService.ApplicationService.csproj", "OptionPacksService.ApplicationService/"]
COPY ["OptionPacksService.DataAccess/OptionPacksService.DataAccess.csproj", "OptionPacksService.DataAccess/"]
COPY ["OptionPacksService.Domain/OptionPacksService.Domain.csproj", "OptionPacksService.Domain/"]
RUN dotnet restore "OptionPacksService.WebAPI/OptionPacksService.WebAPI.csproj"
COPY . .
WORKDIR "/src/OptionPacksService.WebAPI"
RUN dotnet build "OptionPacksService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OptionPacksService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OptionPacksService.WebAPI.dll"]
