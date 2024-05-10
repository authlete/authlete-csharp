# Use the .NET 8.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /src

# Copy the solution file
# Using a wildcard to copy the solution file, suitable if there's only one .sln file in the root
COPY *.sln .

# Copy the csproj files and restore as distinct layers
COPY Authlete/Authlete.csproj Authlete/
COPY Authlete.Tests/Authlete.Tests.csproj Authlete.Tests/

# Restore NuGet packages
RUN dotnet restore "Authlete.sln" -v d

# Copy the rest of the source code
COPY . .

# Build the project
RUN dotnet build "Authlete/Authlete.csproj" -c Release -o /app/build

# Run tests and generate detailed test results in the console
RUN dotnet test "Authlete.Tests/Authlete.Tests.csproj" -c Release --no-restore --logger "console;verbosity=detailed"