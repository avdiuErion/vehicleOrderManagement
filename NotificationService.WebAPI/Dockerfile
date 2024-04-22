FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NotificationService.WebAPI/NotificationService.WebAPI.csproj", "NotificationService.WebAPI/"]
COPY ["NotificationService.ApplicationService/NotificationService.ApplicationService.csproj", "NotificationService.ApplicationService/"]
COPY ["SharedCore/SharedCore.csproj", "SharedCore/"]
RUN dotnet restore "NotificationService.WebAPI/NotificationService.WebAPI.csproj"
COPY . .
WORKDIR "/src/NotificationService.WebAPI"
RUN dotnet build "NotificationService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NotificationService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationService.WebAPI.dll"]
