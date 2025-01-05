# Car Rental Web API

This is the backend for a Car Rental Web Application, built using ASP.NET Core Web API. The application allows users to browse available cars, make and manage their reservations.

## Technologies

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **Swagger**

## Installation

### Prerequisites

Make sure the following software is installed on your machine:
- [.NET SDK](https://dotnet.microsoft.com/download)
- A SQL Server instance or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for local development)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/)

### Setting Up the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/dominikdlubala/wypozyczalnia_samochodow-back
   cd wypozyczalnia_samochodow-back
   ```

2. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```

3. Create the database:
   - In the `appsettings.json` file, update the `ConnectionStrings` section with your SQL Server connection string:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=WypozyczalniaDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```
   - Once the connection string is set, run the following command to create the database and apply migrations:
     ```bash
     dotnet ef database update
     ```

   This will create the necessary tables and set up the database schema for your application.

4. Run the project:
   ```bash
   dotnet run
   ```

   The API will start and be accessible at `http://localhost:5009`.
