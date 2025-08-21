# FROM mcr.microsoft.com/dotnet/sdk:8.0
# WORKDIR /app
# COPY . .
# RUN dotnet build -c Release -o /rel
# EXPOSE 80
# WORKDIR /rel
# ENTRYPOINT ["dotnet", "powerappsuivalues.dll"]

# FROM mcr.microsoft.com/dotnet/sdk:8.0
# WORKDIR /src
# COPY . .
# RUN dotnet restore "PowerAppsUIValues.csproj"

# RUN dotnet build "PowerAppsUIValues.csproj"

# RUN dotnet publish "PowerAppsUIValues.csproj"

# EXPOSE 80
# # WORKDIR /app
# ENTRYPOINT [ "dotnet watch", "powerappsuivalues.dll" ]

# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

#1a: restore the project
# COPY ["PowerAppsUIValues.csproj", "PowerAppsUIValues/"]
COPY . .
RUN dotnet restore "PowerAppsUIValues.csproj"
RUN ls
#1b: build the project
RUN ls
RUN dotnet build 'PowerAppsUIValues.csproj' -c Release -o /app/build

#Stage 2: Publish Stage
FROM build AS publish
RUN ls
RUN dotnet publish 'PowerAppsUIValues.csproj' -c Release -o /app/publish

RUN ls
#Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerAppsUIValues.dll"]
