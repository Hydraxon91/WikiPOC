FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /app

# Copy the test project files
COPY ./tests/ ./

# Restore dependencies
RUN dotnet restore

# Build the test project
RUN dotnet build --no-restore

# Run tests
ENTRYPOINT ["dotnet", "test", "--logger:trx"]
