# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["Cana-House-Start/Cana-House-Start.csproj", "Cana-House-Start/"]
RUN dotnet restore "Cana-House-Start/Cana-House-Start.csproj"

# Copy the rest of the application files
COPY . .

# Build the app
WORKDIR "/src/Cana-House-Start"
RUN dotnet build "Cana-House-Start.csproj" -c Release -o /app/build

# Publish the app
RUN dotnet publish "Cana-House-Start.csproj" -c Release -o /app/publish

# Use the ASP.NET Core runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80 for HTTP traffic
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "Cana-House-Start.dll"]
