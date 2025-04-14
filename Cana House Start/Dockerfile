# Use official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["Cana-House-Start.csproj", "./"]
RUN dotnet restore "./Cana-House-Start.csproj"

# Copy the rest of the source
COPY . .
RUN dotnet publish "Cana-House-Start.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Cana-House-Start.dll"]
