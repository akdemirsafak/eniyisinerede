FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLibrary/*.csproj Shared/SharedLibrary/
COPY Services/Product/Product.API/*.csproj Services/Product/Product.API/
RUN dotnet restore Services/Product/Product.API/*.csproj
COPY . .
RUN dotnet publish Services/Product/Product.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Product.API.dll"]