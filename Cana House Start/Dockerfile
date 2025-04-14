# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the .csproj and restore dependencies
COPY Cana_House_Start.csproj ./
RUN dotnet restore "Cana_House_Start.csproj"

# Copy the rest of the application
COPY . .

# Build the app
RUN dotnet build "Cana_House_Start.csproj" -c Release -o /app/build

# Publish the app
RUN dotnet publish "Cana_House_Start.csproj" -c Release -o /app/publish

# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "Cana_House_Start.dll"]
