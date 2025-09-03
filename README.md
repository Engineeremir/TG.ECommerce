# TG E-Commerce System

This repository contains the TG E-Commerce System, a microservices-based e-commerce solution built with modern technologies including Docker, HashiCorp Vault for secret management, and PostgreSQL database.

## Prerequisites

- Docker and Docker Compose installed on your system
- Git for cloning repositories
- Web browser to access the interfaces

## Installation Guide

Follow these steps to set up and run the TG E-Commerce System:

### Step 1: Clone the Repositories

First, clone both required repositories:

```bash
git clone https://github.com/Engineeremir/TG.ECommerce.System
git clone https://github.com/Engineeremir/TG.ECommerce
```

### Step 2: Start Core Services

Navigate to the `TG.ECommerce.System` directory and start the database and vault services:

```bash
cd TG.ECommerce.System
docker-compose up -d tg.shared.database tg.shared.vault
```

**Expected Output:**
```
✔ Container tg.shared.vault     Started
✔ Container tg.shared.database  Started
```

### Step 3: Configure HashiCorp Vault

1. **Access Vault UI**: Open your web browser and navigate to `http://localhost:8200/`

2. **Login**: 
   - Method: **Token**
   - Token: `myroottoken`

3. **Navigate to Secrets**:
   - Click on **Secrets Engine** in the left menu
   - Select **secret**

4. **Create Secret**:
   - Click the **Create secret** button on the right side
   - In the "Path for this secret" field, enter: `dev/product`

5. **Add Configuration**:
   - Click the **JSON toggle** button to switch to JSON mode
   - Enter the following JSON configuration:

   ```json
   {
     "DatabaseSettings": {
       "ProductDatabase": "Host=tg.shared.database;Port=5432;Database=postgres;Username=postgres;Password=postgres"
     }
   }
   ```

6. **Save**: Click the **Save** button to store the configuration

### Step 4: Start the API Service

Once Vault is configured, start the API service:

```bash
docker-compose up -d tg.ecommerce.api
```

**Expected Output:**
```
✔ Container tg.shared.vault     Healthy
✔ Container tg.shared.database  Healthy
✔ Container tg.ecommerce.api    Started
```

**Important Note:** The `tg.ecommerce.api` service requires both `tg.shared.vault` and `tg.shared.database` to be running and healthy before it can start successfully.

### Step 5: Verify Installation

The application should now be running successfully on port 8080.

**Access Swagger Documentation:**
Navigate to `http://localhost:8080/swagger/index.html` to explore and test the API endpoints through the interactive Swagger interface.

## Project Architecture

This project follows **Clean Architecture** and **Domain-Driven Design (DDD)** principles with the following layer structure:

- **Domain**: Core business entities and domain logic
- **Application**: Application services,Cross-cutting concerns, CQRS handlers and business workflows
- **Infrastructure.EFCore**: Data access layer with Entity Framework Core
- **API**: RESTful API controllers and presentation layer
- **SharedLayer**: Common utilities

### Design Patterns Used

- **Repository Pattern**: Data access abstraction
- **Specification Pattern**: Using Ardalis.Specification package
- **Unit of Work Pattern**: Transaction management
- **CQRS (Command Query Responsibility Segregation)**: Using MediatR
- **Pipeline Behaviors**: For cross-cutting concerns (logging, validation, exception handling)

### Key Features

- **Database**: PostgreSQL with Entity Framework Core
- **Automatic Migrations**: Database migrations run automatically on application startup
- **Seed Data**: Categories and products are automatically seeded
- **Validation**: FluentValidation with custom pipeline behaviors
- **Error Handling**: Comprehensive exception handling with ProblemDetails-compliant responses
- **Logging**: Microsoft.Extensions.Logging with custom pipeline behaviors
- **Domain Events**: Automatic domain event dispatching after entity changes

## Available Endpoints

The API provides the following functionality:

### Categories
- **POST** `/api/categories/add-category` - Create a new category
- **PUT** `/api/categories/update-category` - Update an existing category
- **DELETE** `/api/categories/{id}` - Delete a category

### Products
- **POST** `/api/products/add-product` - Create a new product
- **POST** `/api/products/get-list` - List products with pagination and filtering

All list endpoints support:
- **Pagination**: Page-based navigation
- **Filtering**: Query-based filtering options

## Service Architecture

- **tg.shared.database**: PostgreSQL database service (Port: 5432)
- **tg.shared.vault**: HashiCorp Vault for secure configuration management (Port: 8200)
- **tg.ecommerce.api**: Main API service for the e-commerce system (Port: 8080)

## Technical Implementation

### Database Management
- **Automatic Migrations**: The application automatically applies pending migrations on startup
- **Data Seeding**: Sample categories and products are seeded after successful migration
- **Connection Management**: Database connections are managed through HashiCorp Vault

### Error Handling
The application implements comprehensive error handling:
- **Custom Exceptions**: Domain-specific exceptions for business logic violations
- **Exception Pipeline Behavior**: Global exception handling in the MediatR pipeline
- **ProblemDetails Response**: Standardized error responses following RFC 7807
- **Development vs Production**: Detailed error information in development mode

### Validation
- **FluentValidation**: Robust input validation for all requests
- **Validation Pipeline Behavior**: Automatic validation before request processing
- **Structured Error Responses**: User-friendly validation error messages

### Logging & Monitoring
- **Request/Response Logging**: Complete HTTP request and response logging for debugging and monitoring
- **Pipeline Logging**: Custom logging behaviors in the MediatR pipeline
- **Structured Logging**: Consistent log formatting throughout the application
- **Performance Tracking**: Request processing time monitoring

### Domain Events
- **Event Dispatching**: Automatic publishing of domain events after database changes
- **MediatR Integration**: Seamless integration with the CQRS pattern
- **Clean Entity State**: Automatic cleanup of domain events after processing

## Environment Requirements

- **.NET 8.0** or later
- **Docker & Docker Compose**
- **PostgreSQL** (via Docker container)
- **HashiCorp Vault** (via Docker container)

## Troubleshooting

If you encounter issues:

1. **Container Health**: Ensure all containers are healthy using `docker-compose ps`
2. **Service Dependencies**: Verify that `tg.shared.vault` and `tg.shared.database` are running before starting the API
3. **Vault Configuration**: Check that the database connection secret is properly configured in Vault
4. **Database Connection**: Ensure PostgreSQL container is accessible on port 5432

## API Documentation

Once the system is running, you can access the complete API documentation and test endpoints at:
`http://localhost:8080/swagger/index.html`