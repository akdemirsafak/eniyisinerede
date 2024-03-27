FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLibrary/*.csproj Shared/SharedLibrary/
COPY Services/Location/Location.API/*.csproj Services/Location/Location.API/
RUN dotnet restore Services/Location/Location.API/*.csproj
COPY . .
RUN dotnet publish Services/Location/Location.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Location.API.dll"]