#=================  OPTION 1:  ==================== 
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#COPY bin/Release/net6.0/publish/ App/
#WORKDIR /App
#ENTRYPOINT ["dotnet", "init-api.dll"]
#==================================================


#=================  OPTION 2:  ==================== 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:9096
ENTRYPOINT ["dotnet", "init-api.dll"]
