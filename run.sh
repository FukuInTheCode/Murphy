#!/bin/sh

# Set the base directory for your projects
BASE_DIR="/home/fu/code/App"

# Build each project
echo "Building the Client project..."
cd $BASE_DIR/Client && dotnet build

echo "Building the Shared project..."
cd $BASE_DIR/Shared && dotnet build

echo "Building the Server project..."
cd $BASE_DIR/Server && dotnet build

kitty --hold sh -c "cd /home/fu/code/App/Server && dotnet run" & disown
cd /home/fu/code/App/Client && dotnet run
