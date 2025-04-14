# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the .csproj file and restore dependencies (make sure to use the correct path)
COPY Cana-House-Start/Cana_House_Start/Cana_House_Start.csproj ./Cana_House_Start.csproj
RUN dotnet restore "Cana_House_Start.csproj"

# Copy the rest of the app and publish it
COPY Cana-House-Start/Cana_House_Start./Cana_House_Start.csproj
RUN dotnet publish "Cana_House_Start.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app will run on
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "Cana_House_Start.dll"]
