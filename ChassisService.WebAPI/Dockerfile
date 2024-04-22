FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChassisService.WebAPI/ChassisService.WebAPI.csproj", "ChassisService.WebAPI/"]
COPY ["ChassisService.ApplicationService/ChassisService.ApplicationService.csproj", "ChassisService.ApplicationService/"]
COPY ["SharedCore/SharedCore.csproj", "SharedCore/"]
COPY ["ChassisService.DataAccess/ChassisService.DataAccess.csproj", "ChassisService.DataAccess/"]
COPY ["ChassisService.Domain/ChassisService.Domain.csproj", "ChassisService.Domain/"]
RUN dotnet restore "ChassisService.WebAPI/ChassisService.WebAPI.csproj"
COPY . .
WORKDIR "/src/ChassisService.WebAPI"
RUN dotnet build "ChassisService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN dotnet add package RabbitMQ.Client --version *

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChassisService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChassisService.WebAPI.dll"]
