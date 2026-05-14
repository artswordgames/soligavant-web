# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/SoliGavant.Api/SoliGavant.Api.csproj src/SoliGavant.Api/
RUN dotnet restore src/SoliGavant.Api/SoliGavant.Api.csproj
COPY . .
WORKDIR /src/src/SoliGavant.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SoliGavant.Api.dll"]
