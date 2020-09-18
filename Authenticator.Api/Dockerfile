#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Authenticator.Api/Authenticator.Api.csproj", "Authenticator.Api/"]
COPY ["Authenticator.Data/Authenticator.Data.csproj", "Authenticator.Data/"]
COPY ["Authenticator.Core/Authenticator.Core.csproj", "Authenticator.Core/"]
RUN dotnet restore "Authenticator.Api/Authenticator.Api.csproj"
COPY . .
WORKDIR "/src/Authenticator.Api"
RUN dotnet build "Authenticator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authenticator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authenticator.Api.dll"]