#!/bin/bash
# Setup script for VibeQuest

set -e

if ! command -v dotnet >/dev/null; then
  echo "dotnet CLI not found. Install .NET 9 SDK first." >&2
  exit 1
fi

# Restore, build, and run the UI project

dotnet restore VibeQuest.sln

dotnet build VibeQuest.sln -c Release

# Run database migrations (placeholder)
# dotnet ef migrations add Initial --project Infrastructure --startup-project UI
# dotnet ef database update --project Infrastructure --startup-project UI

dotnet run --project UI/VibeQuest.UI.csproj -c Release
