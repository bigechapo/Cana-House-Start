# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the .csproj file and restore dependencies (make sure to use the correct path)
COPY "Cana\ House\ Start/Cana\ House\ Start.csproj" "./Cana\ House\ Start.csproj"
RUN dotnet restore Cana\ House\ Start.csproj

# Copy the rest of the app and publish it
COPY "Cana\ House\ Start" "./"" 
RUN dotnet publish Cana\ House\ Start.csproj -c Release -o /app/publish

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published app from the build container
COPY --from=build /app/publish . 

# Expose the port the app will run on
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "Cana\ House\ Start.dll"]
