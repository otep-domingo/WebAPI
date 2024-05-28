# JWT
## Part 1: Understanding JWT
-	Reference: JWT Authentication and Authorization: A Detailed Introduction - DZone
## Part 2: Setting .Net Core 6 JWT Authentication and Authorization Server
-	Reference: https://dzone.com/articles/jwt-token-authentication-using-the-net-core-6-web 
### Some changes
1.	We use MySql as database instead of SQL Server. We follow the link how to setup the MySql.
.NET 6.0 - Connect to MySQL Database with Entity Framework Core | Jason Watmore's Blog
•	Adding package “Pomelo.EntityFrameworkCore.MySql”
•	Setting the “appsettings.json” for the connection string
•	Setting the DbContext (DataContext in other references but means the same thing. It is just a class name convention).
•	Setup the database and table manually.
2.	You can use this link to generate a 256 JWT Secret as the Part 2 references uses only 128 bits.
JwtSecret.com - Generate JWT Secrets Online
3.	We remove the implementation of REDIS in Part 2 reference. Here you have to listen carefully as I will show how you remove it and align it based on MVC demo the previous term.
4.	Skip the steps 6,7,9
## Part 3: Implement the username and password database validation
-	.NET 6.0 - Basic Authentication Tutorial with Example API | Jason Watmore's Blog
-	GitHub - cornflourblue/dotnet-6-basic-authentication-api: .NET 6.0 - Basic HTTP Authentication API
## Part 4: JWT Token Authentication in Angular and .Net Core 6 Web API
Reference: JWT Token Authentication - DZone
•	Creating the UI for login
•	Creating the UI for registration/forgot password
•	Resolving the CORS issue
•	Implementing the CRUD with JWT Token authentication
Part 5: [Advance] REDIS Cache in .NET Core API
Reference: Implementation of the REDIS Cache in the .NET Core API - DZone

