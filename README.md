# globank-management-cristian-builes

# instalación
Este projecto se desarrollo usando .net core 5.0
Para la base de datos se uso Sql server y entity framework core para la conexion a esta.
BaseDatos.sql

Antes de correr el proyecto, se debe crear la base de datos en el entorno usando el script "BaseDatos.sql" y posteriormente crear los datos maestros usando el script "Data.sql"

Una vez se encuentre lista la base de datos, se debe cambiar el string de conexión en el archivo "BancoBuiles/appsettings.json" con los datos correspondientes.

# pruebas
En el archivo "BancoBuiles.postman_collection.json" se encuentra la colección de los request utilizados en postman para la ejecución del servicio.
