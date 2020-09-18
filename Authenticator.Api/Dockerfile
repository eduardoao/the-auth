# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY *.sln .

COPY Authenticator.Api/*.csproj  Authenticator.Api/
COPY Authenticator.Data/*.csproj ./Authenticator.Data/
COPY Authenticator.Core/*.csproj ./Authenticator.Core/
COPY Authenticator.Test/*.csproj Authenticator.Test/

RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/Authenticator.Api
RUN dotnet build
WORKDIR /src/Authenticator.Test
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src/Authenticator.Api
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Authenticator.Api.dll