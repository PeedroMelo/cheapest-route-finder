# 🛫 Cheapest Route-Cost Finder
A Restfull API that finds the cheapest route cost between two places.

## ⚙ This project was built with:
- **ASP.NET Core (5.0.0)**: The ASP.NET Core Runtime enables you to run existing web/server applications.
- **Microsoft.EntityFrameworkCore (5.0.17)**: Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations.
- **SQL Server 2019**: Microsoft® SQL Server® 2019 Express is a powerful and reliable free data management system.  
- **XUnit**: xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework.
- **Moq**: The most popular and friendly mocking library for .NET;
- **Swagger**: Swagger is an open source set of rules, specifications and tools for developing and describing RESTful APIs.
- **Docker Desktop**: Docker takes away repetitive, mundane configuration tasks and is used throughout the development lifecycle for fast, easy and portable application development – desktop and cloud.

## 💁🏾‍ How does it works?
This project have two major use cases: the *Route Operations* and the *Cheapest Route-Cost Finder*.

### Route Operator
The Route operator propouse is to manage the known routes, beeing able to do the basic operations of *Create*, *Select*, *Update* or *Delete* routes. 

#### Endpoints
The endpoints that can be used to use the *Route Operator* are:

| **Description** | **Endpoint** | **Http Method** | **Return** |
|---|---|---|---|
| Get Available Routes | /v1/route-operations/ | GET | A list of all stored routes. |
| Create Route | /v1/route-operations/ | POST | The created route. |
| Delete Route | /v1/route-operations/{{id}} | DELETE | void |
| Update Route | /v1/route-operations/{{id}} | PUT | The updated route. |

### Cheapest Route-Cost Finder
Beeing applications' core, the *Cheapest Route-Cost Finder* was made to, given the **origin** and **destiny** points, retreive the cheapest route option, regardless the number of connections between the known routes.

#### Endpoints
For this use case, we only have one endpoint:

| **Description** | **Endpoint** | **Http Method** | **Return** |
|:---:|:---:|:---:|:---:|
| Get Cheapest Route Cost | /v1/cheapest-route-cost/?origin={{origin}}&destiny={{destiny}} | GET | The list of routes combination with the cheapest cost. |

## ▶ How to run it?

To fully run the application, we have to do some steps:

### 1️.   Create the database using Docker
To avoid the installation of a SQL Server instance on the local machine, the tecnology chosed to use the database was Docker.
So, the step zero is to install Docker on your machine 😀, following [this tutorial](https://www.docker.com/products/docker-desktop/).

After the succesfully installation, we begin to setup our database.
Open your favorite Terminal (CMD, Windows Powershell, OhMyZsh, etc), and execute the following command:

`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=123@Password" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`

This will be starting the SQL Server-Docker-Instance execution.

	NOTE: The default **UserId** that will be used is "sa", and the password is "123@Password".

### 2. Execute the database migrations

Now, navigate until the root directory of the project (On Windows, the default directory is "C:/Users/{{your-user}}/source/repos/{project}"), and execute the following two commands:

* Create the migrations

	`dotnet ef migrations --project .\CheapestRouteFinder.Infrastructure\CheapestRouteFinder.Infrastructure.csproj add InitialCreation`

* Insert/update the migrations into the database

	`dotnet ef database --project .\CheapestRouteFinder.Infrastructure\CheapestRouteFinder.Infrastructure.csproj update`


### 3. Executing the project
With everything setted up, it is only necessary to execute the following command to run the application.
Still in project root, execute the command:

`dotnet run --project CheapestRouteFinder.API/CheapestRouteFinder.API.csproj`

After that, you can open up you browser in one of the following URLs:
- https://localhost:5001
- http://localhost:5000

If you see the Swagger home page, it means that everything worked out and you are ready to use the application 🚀
![image](https://user-images.githubusercontent.com/19916327/171126534-95c4bf41-9f55-4f3c-82c5-e61a2ba21cfb.png)

## ℹ Information
This project was builted by Pedro Vieira ([@vieirapcm](https://github.com/vieirapcm/)), for the application to the role of .NET Developer at [BancoMaster](https://www.bancomaster.com.br/).

**My contacts**
- E-mail: vieirapcm@gmail.com / pe-melo97@outlook.com
- Phone: (11) 9 7611-1799
- Github: [@vieirapcm](https://github.com/vieirapcm/)
- LinkedIn: [Pedro Vieira](https://www.linkedin.com/in/vieirapcm/)


-----
