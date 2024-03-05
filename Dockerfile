# Use the .NET 8.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
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

# Run tests and generate TRX test results
RUN dotnet test "Authlete.Tests/Authlete.Tests.csproj" -c Release --no-restore --logger "trx;LogFileName=test_results.trx"

# Copy test results to a known location
RUN mkdir /test-results
RUN cp Authlete.Tests/TestResults/*.trx /test-results

# Publish the application
FROM build AS publish
RUN dotnet publish "Authlete/Authlete.csproj" -c Release -o /app/publish

# Final stage/image uses the .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish ./

CMD ["dotnet", "Authlete.dll"]