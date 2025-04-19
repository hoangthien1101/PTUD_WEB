# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY MyWebApi/*.csproj ./MyWebApi/
RUN dotnet restore

COPY MyWebApi/. ./MyWebApi/
WORKDIR /app/MyWebApi
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/MyWebApi/out ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyWebApi.dll"]
