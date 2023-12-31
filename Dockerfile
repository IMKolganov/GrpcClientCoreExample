﻿hFROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GrpcClientCoreExample.csproj", "./"]
RUN dotnet restore "GrpcClientCoreExample.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "GrpcClientCoreExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcClientCoreExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcClientCoreExample.dll"]
