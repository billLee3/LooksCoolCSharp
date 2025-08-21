# FROM mcr.microsoft.com/dotnet/sdk:8.0
# WORKDIR /app
# COPY . .
# RUN dotnet build -c Release -o /rel
# EXPOSE 80
# WORKDIR /rel
# ENTRYPOINT ["dotnet", "powerappsuivalues.dll"]

# FROM mcr.microsoft.com/dotnet/sdk:8.0
# WORKDIR /src
# COPY ["PowerAppsUIValues.csproj", "PowerAppsUIValues/"]
# RUN dotnet restore "PowerAppsUIValues/PowerAppsUIValues.csproj"

# COPY . .

# RUN dotnet build "src/PowerAppsUIValues/PowerAppsUIValues.csproj" -c Release -o /app

# RUN dotnet publish "src/PowerAppsUIValues/PowerAppsUIValues.csproj" -c Release -o /app

# EXPOSE 80
# WORKDIR /app
# ENTRYPOINT [ "dotnet", "powerappsuivalues.dll" ]

# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

#1a: restore the project
COPY ["PowerAppsUIValues.csproj", "PowerAppsUIValues/"]
RUN dotnet restore "PowerAppsUIValues/PowerAppsUIValues.csproj"
#1b: build the project
COPY . .
WORKDIR /src/PowerAppsUIValues
RUN dotnet build 'PowerAppsUIValues.csproj' -c Release -o /app/build

#Stage 2: Publish Stage
FROM build AS publish

RUN dotnet publish 'PowerAppsUIValues.csproj' -c Release -o /app/publish

#Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "powerappsuivalues.dll"]
