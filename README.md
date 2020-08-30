# BB360 TestBrief

The project was developed as a recruitment exercise for Business Brace 360.

## Setup
1. This project is build with c# on the dotnet core framework. Ensure you have dotnet core installed and running on your machine. https://dotnet.microsoft.com/download/dotnet-core/3.1. To confirm dotnet core is installed correctly run the following command on the terminal of your machine `dotnet --info`
2. Run the following git command on the terminal to clone this repository `git clone https://github.com/ikeliec/BB360.git`
3. Setup your database server (MSSQL) and connect to the application. Change the database connection settings in the `appsettings.json` file
4. Run migration to create database tables and seed with initial records.
5. Run the `dotnet restore` command on the terminal to restore all package dependencies
6. Run the `dotnet clean && dotnet build` command to clean and build the solution
7. Run the `dotnet run` command to start the application. The application by default will be running on `http://localhost:5000`
8. Run visit `http://localhost:5000/swagger` on your favourite web browser to view BB360 TestBrief API documentation

## Demo
Authenticate with the below test users credential to test the API. Authentication endpoint is `/api/Authentication/Login`

**Email:** jamal.andre@mailinator.com  
**Password:** Password@1

**Email:** sly.odin@mailinator.com  
**Password:** Password@1

You can create new users using the following endpoint `/api/Recruitment/Register`

## Issues
If you encounter any issue setting up this project or you ran into an exception. Do not hesitate to create an Issue in the Issue Logs, I will be most glad to assist.

Cheers :)
