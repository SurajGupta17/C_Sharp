# Employee Admin Portal

A REST API built with ASP.NET Core for managing employees.

## Features
- CRUD Operations for Employees
- JWT Authentication (Register/Login)
- Entity Framework Core with SQL Server

## Tech Stack
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Bearer Authentication

## Endpoints
### Auth
- POST /api/Auth/register
- POST /api/Auth/login

### Employees (requires JWT token)
- GET /api/Employees
- GET /api/Employees/{id}
- POST /api/Employees
- PUT /api/Employees/{id}
- DELETE /api/Employees/{id}
