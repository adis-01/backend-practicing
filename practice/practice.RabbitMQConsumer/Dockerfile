# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the entire solution
COPY . .

# Build the solution
RUN dotnet build -c Release -o /app/build

# Publish the console app
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Build the final runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "practice.RabbitMQConsumer.dll"]