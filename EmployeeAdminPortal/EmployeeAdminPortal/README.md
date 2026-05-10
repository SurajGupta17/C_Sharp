# Employee Admin Portal

A production-ready REST API built with ASP.NET Core 8.

## Features
- JWT Authentication with Role Based Authorization
- Employee & Task Management (CRUD)
- One to Many Relationships (EF Core)
- Repository + Service Layer Pattern
- Pagination & Filtering
- AI Chat Integration (Groq/LLaMA)

## Tech Stack
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Bearer Authentication
- Groq AI API

## Roles
- Admin → full access
- Manager → view employees, manage tasks
- Employee → view tasks only

## Endpoints
### Auth
- POST /api/Auth/register
- POST /api/Auth/login

### Employees (Admin/Manager)
- GET /api/Employees
- POST /api/Employees
- PUT /api/Employees/{id}
- DELETE /api/Employees/{id}

### Tasks
- GET /api/Task
- POST /api/Task
- DELETE /api/Task/{id}

### AI Chat
- POST /api/Chat