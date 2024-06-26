﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderService.WebAPI/OrderService.WebAPI.csproj", "OrderService.WebAPI/"]
COPY ["OrderService.ApplicationService/OrderService.ApplicationService.csproj", "OrderService.ApplicationService/"]
COPY ["OrderService.Domain/OrderService.Domain.csproj", "OrderService.Domain/"]
COPY ["SharedCore/SharedCore.csproj", "SharedCore/"]
COPY ["OrderService.DataAccess/OrderService.DataAccess.csproj", "OrderService.DataAccess/"]
RUN dotnet restore "OrderService.WebAPI/OrderService.WebAPI.csproj"
COPY . .
WORKDIR "/src/OrderService.WebAPI"
RUN dotnet build "OrderService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrderService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderService.WebAPI.dll"]
