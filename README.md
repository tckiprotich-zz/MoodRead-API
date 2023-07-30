# Book Recommendations API

**Authors:** Collins Tonui, Caroline Kimatu

## Description

The Book Recommendations API is a RESTful web service that provides book recommendations based on user input. It utilizes the OpenAI API to generate book recommendations and the Google Books API to retrieve book details. This API allows users to get personalized book suggestions and explore book information such as title, author, description, and image.

## Technologies Used

- Backend: C#, ASP.NET Core
- OpenAI API: Integration for generating book recommendations
- Google Books API: Integration for retrieving book details
- Database: ""
- Frontend: ""

## Getting Started

To run the Book Recommendations API locally, follow these steps:

1. Clone the repository:

```
git clone https://github.com/your-repo.git 

```
2. Navigate to the project directory:
``` 
cd BookRecommendationsAPI
```


3. Install the necessary dependencies:
```bash
dotnet add package Microsoft.AspNetCore.Http
dotnet add package Microsoft.AspNetCore.Mvc
dotnet add package Newtonsoft.Json
dotnet add package OpenAI_API
dotnet add package System.Net.Http
```
4. Run the API:
```bash
dotnet run
```
5. The API will be accessible at 
```bash
http://localhost:5000/api/BookRecommendations
```
## API Endpoints

### GET 
```bash 
/api/BookRecommendations
```

Retrieves book recommendations based on user input.

### POST 
```bash
/api/BookRecommendations/books
```

Retrieves book details from the Google Books API based on the book ID.

### `GET 
```bash 
/api/BookRecommendations/books/{bookId}
```

Retrieves detailed information for a specific book by its book ID.

## License

This project is licensed under the [MIT License](LICENSE).