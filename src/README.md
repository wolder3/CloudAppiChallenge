## Acerca del proyecto

- Solucion elaborada bajo los conceptos de: 

    -  Arquitectura limpia para ASP.NET Core 6.0. 
    -  Construido con arquitectura cebolla/hexagonal.
    -  Construido con los patrones CQRS y MediatR.

- Pruebas unitarias utilizando XUnit

## Elaborado con

-   [ASP.NET Core 6.0 ](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core)
-   ASP.NET Core 6.0 WebAPI
-   [Entity Framework Core 6.0](https://docs.microsoft.com/en-us/ef/core/)
-   SQL SERVER

## Prerequisitos

  Asegúrese de estar ejecutando el SDK de .NET 6 más reciente (solo SDK 6.0 y superior). [Obten el ultimo aqui.](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

-   Visual Studio 2022 ([Visual Studio 2022 Community](https://visualstudio.microsoft.com/es/vs/) el cual es libre de uso.)

-   Instalar el ultimo [.NET & EF CLI Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) usando este comando :

    ```.NET Core CLI
    dotnet tool install --global dotnet-ef
    ```
- Crear la base de datos (```SQL SERVER```) en servidor OnPremise

    ```
    CREATE DATABASE dbChallengeBackend
    ```
-   Crear usuario para conexion

    ```
    CREATE LOGIN AdminChallenge WITH PASSWORD = '3BD8752L01L22BU1$'
    GO
    USE dbChallengeBackend
    GO
    CREATE USER AdminChallenge FOR LOGIN AdminChallenge
        WITH DEFAULT_SCHEMA = dbChallengeBackend;
    GO
    ALTER ROLE db_owner ADD MEMBER AdminChallenge;
    ```

## Modificacion de conexion a base de datos

- Ya realizado lo anterior debera cambiar la cadena de conexion en el archivo ```appsettings.json``` y en la seccion de ```ChallengeSQLConnection```.
- Luego debera utilizar ``` Package Manager Console``` para migrar las entidades a la base de datos, para ello debera utlizar el comando  ```Update-Database```

## Proyecto desplegado

- Este proyecto se encuentra desplegado en la siguiente ruta ```https://challengebackendapi2022.azurewebsites.net```
- Para ver la documentacion de Open API del proyecto debera ingresar a la siguiente ruta: ```https://challengebackendapi2022.azurewebsites.net/swagger/index.html```
    