# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish MyWebApi.csproj -c Release -o out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Đừng hardcode 8080 nữa, đọc từ $PORT
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}
ENTRYPOINT ["dotnet", "MyWebApi.dll"]
