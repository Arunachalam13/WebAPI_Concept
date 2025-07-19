# ASP.NET Core Web API Project

## Introduction
Welcome to the ASP.NET Core Web API project! This project is a simple web application that provides a set of endpoints (URLs) to manage a collection of books. It’s built using **ASP.NET Core**, a powerful framework by Microsoft for creating modern, scalable web APIs that can run on Windows, macOS, or Linux.

This README is designed for beginners to understand the project, set it up, and run it locally. It’s also a handy reference for revisiting the project later.

## What is a Web API?
A Web API (Application Programming Interface) allows different applications to communicate with each other over the internet. For example, a mobile app can use a Web API to fetch data from a server or send data to it. This project uses ASP.NET Core to create APIs that handle book-related operations, responding to HTTP requests (like GET, POST, PUT, DELETE) with data in JSON format.

## Prerequisites
To work with this project, you’ll need the following installed on your computer:
- **.NET SDK**: Version 6.0 or later (download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)).
- **Code Editor**: Visual Studio, Visual Studio Code, or any editor you prefer.
- **Git**: To clone and manage the repository (download from [git-scm.com](https://git-scm.com/)).
- **Database**: A database compatible with Entity Framework Core (e.g., SQL Server, SQLite). Ensure it’s configured in `appsettings.json`.
- (Optional) **Postman** or **cURL**: To test the API endpoints.

## Project Structure
Here’s an overview of the key files and folders in this project:
- **Program.cs**: The entry point of the application, where the app is configured and started.
- **Controllers/BooksController.cs**: Defines the API endpoints for managing books (e.g., retrieving, adding, updating, or deleting books).
- **Models/Book.cs**: Defines the `Book` class, which represents a book with properties like `Id`, `Title`, `Author`, and `YearPublished`.
- **appsettings.json**: Stores configuration settings, such as the database connection string.

## Book Model Explanation
The `Book` class (located in `Models/Book.cs`) defines the structure of a book in the API. It’s a simple data model that represents a book with the following properties:
- **Id**: An integer that uniquely identifies each book (e.g., 1, 2, 3).
- **Title**: A string that holds the book’s title (e.g., "The Great Gatsby"). Defaults to an empty string if not set.
- **Author**: A string that holds the author’s name (e.g., "F. Scott Fitzgerald"). Defaults to an empty string if not set.
- **YearPublished**: An integer that holds the year the book was published (e.g., 1925).

This model is used by the `BooksController` to handle book data in requests and responses, ensuring data is structured consistently in JSON format and stored in the database.

## BooksController Explanation
The `BooksController` class (located in `Controllers/BooksController.cs`) is the core of this API. It handles HTTP requests to manage a collection of books stored in a database using **Entity Framework Core**. The controller uses a `FirstAPIContext` (a database context) to interact with the database asynchronously, ensuring efficient and scalable operations. Below is a beginner-friendly explanation of its main methods:

- **Purpose**: The `BooksController` provides endpoints to perform CRUD operations (Create, Read, Update, Delete) on books stored in a database.
- **Database Integration**: It uses a `FirstAPIContext` to connect to a database, where books are stored in a table (or collection) called `Books`. Changes are saved to the database using `SaveChangesAsync`.
- **Endpoints**:
  - **GET /api/books** (`GetBooks`):
    - **What it does**: Retrieves the full list of books from the database.
    - **How it works**: Queries the `Books` table using `_context.Books.ToListAsync()` and returns the results in JSON format.
    - **Response**: Returns a 200 OK status with the list of books, or an empty list if no books exist.
  - **GET /api/books/{id}** (`GetBookById`):
    - **What it does**: Retrieves a specific book by its `Id`.
    - **How it works**: Searches the database for a book with the specified `Id` using `_context.Books.FindAsync(id)`. If the book is not found, it returns a 404 (Not Found).
    - **Response**: Returns a 200 OK with the book’s details in JSON, or a 404 if the book doesn’t exist.
  - **POST /api/books** (`AddBook`):
    - **What it does**: Adds a new book to the database.
    - **How it works**: Accepts a `Book` object in the request body (JSON format). If the input is valid, it adds the book to the `Books` table using `_context.Books.Add` and saves changes with `SaveChangesAsync`.
    - **Response**: Returns a 201 Created status with the new book’s details and a URL to access it (via `GetBookById`). Returns a 400 Bad Request if the input is invalid (e.g., null).
  - **PUT /api/books/{id}** (`UpdateBook`):
    - **What it does**: Updates an existing book’s details (title, author, year) by its `Id`.
    - **How it works**: Finds the book by `Id` using `_context.Books.FindAsync(id)`. If found, updates its properties with the new values from the request body and saves changes with `SaveChangesAsync`. If not found, returns a 404.
    - **Response**: Returns a 204 No Content status on success, or a 404 if the book doesn’t exist.
  - **DELETE /api/books/{id}** (`DeleteBook`):
    - **What it does**: Deletes a book from the database by its `Id`.
    - **How it works**: Finds the book by `Id` using `_context.Books.FindAsync(id)`. If found, removes it from the `Books` table using `_context.Books.Remove` and saves changes with `SaveChangesAsync`. If not found, returns a 404.
    - **Response**: Returns a 204 No Content status on success, or a 404 if the book doesn’t exist.

Unlike the previous version, this controller stores data in a database, so book data persists between application restarts.

## Setup Instructions
Follow these steps to get the project running on your local machine:

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd <repository-folder-name>
   ```
   Replace `<repository-url>` with the URL of your GitHub repository.

2. **Configure the Database**
   - Ensure a database (e.g., SQL Server, SQLite) is set up and accessible.
   - Update the connection string in `appsettings.json` to point to your database. For example:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=FirstAPI;Trusted_Connection=True;"
       }
     }
     ```
   - Run database migrations (if applicable) to create the `Books` table:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```
     Ensure the `Microsoft.EntityFrameworkCore.Tools` package is installed for these commands.

3. **Restore Dependencies**
   Run the following command to install the required .NET packages, including Entity Framework Core:
   ```bash
   dotnet restore
   ```

4. **Build the Project**
   Compile the project to check for errors:
   ```bash
   dotnet build
   ```

5. **Run the Project**
   Start the API locally:
   ```bash
   dotnet run
   ```
   The API will typically run at `http://localhost:5000` or `https://localhost:5001`. Check the terminal output for the exact URL.

6. **Test the API**
   - Use Postman, cURL, or a browser to test the endpoints.
   - Example: Navigate to `http://localhost:5000/api/books` to see the list of books in JSON format.
   - Example: Send a POST request to `http://localhost:5000/api/books` with a JSON body like:
     ```json
     {
         "id": 1,
         "title": "New Book",
         "author": "John Doe",
         "yearPublished": 2023
     }
     ```

## Example Endpoints
Here are the specific endpoints provided by the `BooksController`:
- **GET /api/books**: Retrieves all books from the database.
- **GET /api/books/1**: Retrieves the book with `Id=1`.
- **POST /api/books**: Creates a new book. Send a JSON object with `id`, `title`, `author`, and `yearPublished`.
- **PUT /api/books/1**: Updates the book with `Id=1`. Send updated book details in the request body.
- **DELETE /api/books/1**: Deletes the book with `Id=1`.

## Troubleshooting
- **Database Connection Issues**: Verify the connection string in `appsettings.json` and ensure the database server is running.
- **Missing Dependencies**: Run `dotnet restore` to install packages like `Microsoft.EntityFrameworkCore`.
- **404 Errors**: Ensure the book `Id` exists when testing GET, PUT, or DELETE endpoints.
- **Invalid JSON**: When sending POST or PUT requests, ensure the JSON format matches the `Book` model (e.g., include all required fields like `id`, `title`, `author`, and `yearPublished`).
- **Migration Errors**: Ensure Entity Framework Core tools are installed (`dotnet tool install --global dotnet-ef`) and run migrations as described above.

## Next Steps
- Explore the `BooksController.cs` and `Book.cs` files to understand how the API and model work with the database.
- Add more endpoints or features, like searching books by author or year.
- Seed the database with initial book data (e.g., classics like *The Great Gatsby*) using migrations or a seeding method.

## Resources
- [Official ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Postman for API Testing](https://www.postman.com/)

Feel free to reach out with questions or contribute to this project!