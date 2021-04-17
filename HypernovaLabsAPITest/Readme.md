## RESTful API para el alquiler de vehículos

#### Tecnologias
* ASP .net core 5.0
* Entity Framework core (Code First)
* Token JWT
* SQL Server para la base de datos
* Visual Studio 2019

#### Instalacion
* Instalar .net core 5.0 en caso de no tenerlo instalado https://dotnet.microsoft.com/download/dotnet/5.0
* Configurar el connection string CarRentalDB en appsettings.json para que apunte a un servidor de SQL Server, el usuario debe poseer permisos para crear base de datos.
* Abrir una consola de comando en la carpeta del proyecto HypernovaLabsAPITest y ejecutar "dotnet ef database update", esto creara la base de datos CarRentalDB, junto con sus tablas y datos de ejemplo.
* Ejecutar el proyecto con la configuracion por defecto "IIS Express".

Al ejecutar el proyecto, se cargara el API en el navegador por defecto, por default se carga la documentacion Swagger donde estan todos los endpoints junto con sus descripciones.