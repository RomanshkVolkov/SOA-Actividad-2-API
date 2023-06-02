# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copia los archivos csproj y restaura las dependencias
COPY SOAP1-29AV/SOAP1-29AV.csproj .
RUN dotnet restore

# Copia el resto de los archivos de la aplicación
COPY . .

# Publica la aplicación
RUN dotnet publish -c Release -o /app

# Establece la imagen base para la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .

# Establece el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "SOAP1-29AV.dll"]
