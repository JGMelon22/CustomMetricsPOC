# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy all files including Store.db
COPY . ./CustomMetricsPOC
WORKDIR /source/CustomMetricsPOC
RUN dotnet restore

# Build the app
RUN dotnet publish -c release -o /app --no-restore

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim
WORKDIR /app

# Create Database directory
RUN mkdir -p /app/Database

# Copy the published app files
COPY --from=build /app ./

# Copy the SQLite database file from the build stage to the final container
COPY --from=build /source/CustomMetricsPOC/Store.db /app/Database/Store.db

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "CustomMetricsPOC.dll"]
