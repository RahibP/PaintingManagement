# Gebruik de officiële .NET Core-runtime als basisimage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

# Kopieer alle csproj-bestanden en restore-as-NuGet-dependencies
ADD BL ./BL
ADD DAL ./DAL
ADD Domain ./Domain
ADD UI-MVC ./UI-MVC

# Restore NuGet packages
RUN dotnet restore ./UI-MVC/UI-MVC.csproj

# Kopieer de rest van de broncode en bouw de applicatie
COPY . ./
RUN dotnet publish -c Release -o out

# Gebruik de officiële .NET Core-runtime als basisimage
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Schilderij.UI.Web.MVC.dll"]
