# Utilizamos la imagen base de SQL Server Express 2019
FROM mcr.microsoft.com/mssql/server:2019-latest

# Variables de entorno para configurar la instancia de SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Sistecredito2023*

# Copia los archivos SQL que deseas ejecutar en el contenedor

# Puerto en el que estará disponible SQL Server (personalizado)
EXPOSE 14330

# Configuración adicional de SQL Server para utilizar el puerto personalizado
ENV MSSQL_TCP_PORT=14330

# Comando de inicio de SQL Server
CMD [ "sqlservr" ]