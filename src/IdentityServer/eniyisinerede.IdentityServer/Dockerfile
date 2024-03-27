FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLibrary/*.csproj Shared/SharedLibrary/
COPY IdentityServer/eniyisinerede.IdentityServer/*.csproj IdentityServer/eniyisinerede.IdentityServer/ 
RUN dotnet restore IdentityServer/eniyisinerede.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/eniyisinerede.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "eniyisinerede.IdentityServer.dll"]