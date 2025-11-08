# Bird Watching MAUI App

This is the .NET MAUI desktop application for viewing bird sightings uploaded from the Android app.

## Setup

1. Update the Azure connection string in `Services/AzureService.cs`:
   - Replace `YOUR_ACCOUNT_NAME` with your Azure Storage Account name
   - Replace `YOUR_ACCOUNT_KEY` with your Azure Storage Account key

2. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```

## Features

- View all bird sightings uploaded from the Android app
- Search for birds by species, location, or comments
- View detailed information about each bird sighting
- Refresh data from Azure cloud storage

## Requirements

- .NET 8.0 SDK
- Windows 10/11 (for Windows desktop)
- Azure Storage Account with container named "bird-watching-data"

