#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CheapestRouteFinder.API/CheapestRouteFinder.API.csproj", "CheapestRouteFinder.API/"]
RUN dotnet restore "CheapestRouteFinder.API/CheapestRouteFinder.API.csproj"
COPY . .
WORKDIR "/src/CheapestRouteFinder.API"
RUN dotnet build "CheapestRouteFinder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheapestRouteFinder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_URLS=http://+:5000
ENTRYPOINT ["dotnet", "CheapestRouteFinder.API.dll", "--server.urls", "http://+:5000"]