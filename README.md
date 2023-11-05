# FormulaOne-BlazorWebApi

Welcome to the FormulaOne-BlazorWebApi project! This is a comprehensive CRUD application that empowers users to efficiently manage Formula One drivers, teams, and races. The application is built on a robust foundation, utilizing ASP.NET Core 6.0 for the web API and Blazor Server for the front-end. This README will provide you with an in-depth understanding of the project, its features, prerequisites, and how to get it up and running.

## Features

This application offers several key features that enable users to interact with Formula One data seamlessly:

1. **CRUD Operations:** You can Create, Read, Update, and Delete drivers, teams, and races through the web API, providing full control over your Formula One data.

2. **Web API Integration:** The Blazor Server app interacts with the web API through HttpClient and JSON helpers, ensuring efficient communication with the backend.

3. **Data Access and Persistence:** The application uses Entity Framework Core and SQL Server to manage data access and persistence, offering reliability and scalability.

4. **Data Mapping:** AutoMapper is employed to handle mapping between entities and Data Transfer Objects (DTOs), streamlining data transformation.

5. **User Input Validation:** FluentValidation is implemented to validate user input, enhancing data quality and security.

6. **Styling and Icons:** Bootstrap and Font Awesome are used for styling, ensuring an appealing and user-friendly interface.

7. **Notifications:** Blazored.Toast is integrated to display notifications, keeping users informed about important actions and events.

8. **Pagination and Modals:** Blazorise is utilized to incorporate pagination and modal dialogs, improving user experience.

## Prerequisites

To get started with FormulaOne-BlazorWebApi, make sure you have the following prerequisites in place:

- **Visual Studio 2022 or later:** You'll need Visual Studio to work with the project. If you don't have it, you can download and install it from the official website.

- **.NET 6.0 SDK or later:** Ensure you have the .NET SDK installed on your machine. You can download the latest version from the official .NET website.

- **SQL Server Express LocalDB or later:** The project relies on SQL Server for data storage. Make sure you have SQL Server Express LocalDB or a compatible version installed.

## How to Run

Follow these steps to run the FormulaOne-BlazorWebApi application:

1. **Clone or Download:** Start by cloning the repository or downloading it to your local machine.

2. **Open in Visual Studio:** Launch Visual Studio and open the solution file `FormulaOne-BlazorWebApi.sln`.

3. **Set Startup Project:** In Visual Studio, set the `FormulaOne-WebApi` project as the startup project. This is the backend of the application.

4. **Update Connection String:** Update the connection string in the `appsettings.json` file of the `FormulaOne-WebApi` project to point to your SQL Server instance.

5. **Run FormulaOne-WebApi:** Build and run the `FormulaOne-WebApi` project to create the database and seed it with sample data.

6. **Set Blazor Project:** In Visual Studio, set the `FormulaOne-Blazor` project as the startup project. This is the front-end of the application.

7. **Run FormulaOne-Blazor:** Build and run the `FormulaOne-Blazor` project to launch the Blazor app.

8. **Enjoy:** You're all set! You can now use the FormulaOne-BlazorWebApi application to manage Formula One drivers, teams, and races.

Feel free to explore, modify, and extend the application as needed. Happy coding!
