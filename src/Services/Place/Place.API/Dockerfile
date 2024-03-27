FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLibrary/*.csproj Shared/SharedLibrary/
COPY Services/Place/Place.API/*.csproj Services/Place/Place.API/
RUN dotnet restore Services/Place/Place.API/*.csproj
COPY . .
RUN dotnet publish Services/Place/Place.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Place.API.dll"]