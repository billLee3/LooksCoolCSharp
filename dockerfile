FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet build -c Release -o /rel
EXPOSE 80
WORKDIR /rel
ENTRYPOINT ["dotnet", "powerappsuivalues.dll"]

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