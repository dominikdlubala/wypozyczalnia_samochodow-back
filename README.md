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

The following instructions have been proved to be working on a Windows machine. It should also work on a Linux/Mac machine, though it has not been checked.

1. Check if you have git installed
   ```bash
   git --version
   ```
   If it's not installed visit https://git-scm.com/book/en/v2/Getting-Started-Installing-Git and follow the steps to installing git on your machine 

2. Clone the repository:
   ```bash
   git clone https://github.com/dominikdlubala/wypozyczalnia_samochodow-back
   cd wypozyczalnia_samochodow-back
   ```

3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```

4. Create the database:
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

5. Run the project:
   ```bash
   dotnet run
   ```

   The API will start and be accessible at `http://localhost:5009`.
