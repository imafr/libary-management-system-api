Overview
--------

The LibaryManagement solution is a structured ASP.NET Core Web API project, combined by several supportive sub-project to
enable a robust architectural framework that expedites API development. The solution includes the following projects
housed in the `src` directory:

1. LibaryManagement.WebAPI
2. LibaryManagement.BL
3. LibaryManagement.DL
4. LibaryManagement.Shared

`LibaryManagement.WebAPI` functions as the main entry point, while `LibaryManagement.BL` 
contain the business logic. Shared utilities and models are stored in `LibaryManagement.Shared`,
and `LibaryManagement.DatabaseMigration` manages database schema modifications using Entity Framework Core.


Requirements
------------

Ensure the following are installed before you begin:

* .NET 8.0
* MSSQL Server

Installation Steps
------------------

1. Clone the repository:

bash

```bash
git clone https://github.com/imafr/libary-management-system-api.git
```

2. Change to the project directory:

bash

```bash
cd libary-management-system-api
```

3. Restore the .NET solution:

bash

```bash
dotnet restore
```

4. Compile the solution:

bash

```bash
dotnet build
```

Configuration
-------------

Adjust the `appsettings.json` in `LibaryManagement.WebAPI` with your MSSQL Server details.

json

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "data-source"
    }
}
```

Database Migrations with Entity Framework Core
----------------------------------------------
Entity Framework Core is a .NET library that helps manage database changes by tracking 
executed scripts and applying necessary updates to the database.

Steps to Run Migrations Locally
        
  1. Using Package Manager Console or PowerShell- 
      i. Open Package Manager Console or Developer PowerShell in your IDE.
      ii. Navigate to the LibraryManagement.DL project.
bash

```bash
cd LibaryMangement.DL
```

      iii. Run the following command to apply the latest migration and see detailed output:
bash

```bash
update-database -verbose
```

  2. Using .NET Core CLI
    1. Open your terminal or command prompt.
    2. Navigate to the root directory of your project.

      Run the following command:
bash

```bash
dotnet ef database update
```
This will apply all pending migrations and update your database schema to match the latest model changes.

Usage
-----

To initiate the `WebAPI` project:

bash

```bash
dotnet run --project ./src/LibaryManagement/LibaryManagement.csproj
```

The API will start at `https://localhost:7053`.

API Documentation
-----------------

Swagger furnishes API documentation. Access the Swagger UI at `https://localhost:7053/swagger/index.html` once the
application is running.
