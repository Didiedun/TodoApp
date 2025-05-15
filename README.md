# Todo Application
## This is a Technical Assessment Junior .NET Backend Developer (Mohammad Arif Daniel bin Muhamaddun)
A modern Todo application built with .NET Web API backend and React frontend, following clean architecture principles.

## Features

- Create, read, update, and delete todo items
- Mark todos as complete/incomplete
- UI design
- RESTful API with Swagger documentation
- Follows clean architecture principles

## Technologies Used

### Backend
- .NET 7 Web API
- Entity Framework Core with SQLite
- MediatR for CQRS pattern
- FluentValidation for input validation
- Swagger for API documentation

### Frontend
- React with Hooks
- Vite for fast development
- Axios for API communication
- Modern CSS design

## Project Structure

The solution follows clean architecture principles with these layers:
- **Core**: Domain entities and interfaces
- **Application**: Business logic and services
- **Infrastructure**: Database access and external services
- **API**: Controllers and middleware
- **Web**: React frontend

### Running the Backend
```bash
cd src/TodoApp.Api
dotnet run
