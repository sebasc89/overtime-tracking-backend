# Usamos la imagen base de .net 6 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

WORKDIR /app

# Copiamos los archivos de cada proyecto 
COPY . ./

# Restauramos las dependencias de los proyectos 
RUN dotnet restore
RUN dotnet publish -c Release -o out


# Utilizamos una imagen base más ligera para la API web
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copiar los archivos publicados del Api 
COPY --from=build /app/Sistecredito.OvertimeTracking.Web/publish .

# Exponer el puerto en el que se ejecuta la API
EXPOSE 80

# Establecer el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Sistecredito.OvertimeTracking.Web.dll"]
