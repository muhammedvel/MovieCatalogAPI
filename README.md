# Movie Catalog REST API 🎬

## Overview
The **Movie Catalog REST API** is a backend application built with **C#** and **ASP.NET Core**. It provides a robust architecture for managing a database of movies and user reviews. The project demonstrates backend development best practices, including relational database management, data validation, and optimized querying.

## Tech Stack
* **Language:** C#
* **Framework:** .NET 8 / ASP.NET Core Web API
* **ORM:** Entity Framework Core (EF Core)
* **Database:** PostgreSQL
* **Documentation:** Swagger / OpenAPI

## Key Features
* **Complete CRUD Operations:** Create, Read, Update, and Delete movies and reviews.
* **Relational Data:** Implements a One-to-Many relationship (One Movie -> Many Reviews).
* **Data Validation:** Strict encapsulation and business logic applied directly to properties (e.g., release year limits, star rating constraints, preventing empty fields) to handle bad requests gracefully.
* **Search & Filtering:** Dynamic querying to find movies by title or filter them by genre.
* **Pagination:** Optimized data fetching to prevent memory overload and reduce response times.

## Getting Started

### Prerequisites
To run this project locally, you need to have the following installed:
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (or later)
* [PostgreSQL](https://www.postgresql.org/download/)

### Installation & Setup

1. **Clone the repository:**
git clone https://github.com/muhammedvel/MovieCatalogAPI.git
cd MovieCatalogAPI

2. **Configure the Database Connection:**
Open appsettings.json and update the DefaultConnection string with your PostgreSQL credentials (username and password):
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=MovieCatalogDb;Username=postgres;Password=YOUR_PASSWORD"
}

3. **Apply Entity Framework Migrations:**
Run the following command to create the database and tables:
dotnet ef database update

4. **Run the Application:**
dotnet run

5. **Test the API:**
Once the server is running, open your browser and navigate to the Swagger UI to test the endpoints interactively:
http://localhost:5014/swagger (Note: The port number might vary depending on your local launch settings).

## API Endpoints Summary

### Movies
* GET /api/Movies - Retrieves a paginated list of all movies.
* GET /api/Movies/{id} - Retrieves a specific movie by its ID.
* POST /api/Movies - Adds a new movie to the catalog.
* PUT /api/Movies/{id} - Updates an existing movie.
* DELETE /api/Movies/{id} - Removes a movie from the catalog.

### Reviews
* GET /api/Reviews/movie/{movieId} - Retrieves all reviews associated with a specific movie.
* POST /api/Reviews - Posts a new review for a movie (requires a valid movie ID, 1-5 stars).
