# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the .csproj file and restore any dependencies
COPY WishlistAPI/WishlistAPI.csproj WishlistAPI/
RUN dotnet restore "WishlistAPI/WishlistAPI.csproj"

# Copy the rest of the application code
COPY WishlistAPI/ WishlistAPI/

# Set the working directory inside the container
WORKDIR /src/WishlistAPI

# Build the application
RUN dotnet publish -c Release -o /app

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the build output from the build image
COPY --from=build /app .

# Expose the port the application runs on
EXPOSE 8080

# Specify the command to run the application
ENTRYPOINT ["dotnet", "WishlistAPI.dll"]
