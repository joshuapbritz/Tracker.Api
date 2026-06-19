ARG DOTNET_VERSION=10.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

COPY Tracker.slnx ./

COPY Tracker.Api/Tracker.Api.csproj Tracker.Api/
COPY Tracker.Application/Tracker.Application.csproj Tracker.Application/
COPY Tracker.Domain/Tracker.Domain.csproj Tracker.Domain/
COPY Tracker.Infrastructure/Tracker.Infrastructure.csproj Tracker.Infrastructure/

RUN dotnet restore Tracker.Api/Tracker.Api.csproj

COPY . .

RUN dotnet publish Tracker.Api/Tracker.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Tracker.Api.dll"]
