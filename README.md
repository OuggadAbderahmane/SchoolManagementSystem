# School Management System API

## Overview

This ASP.NET Web API facilitates the management of a school's administrative and academic processes. The system allows administrators to handle student enrollment, evaluation, attendance, and class schedules efficiently.

## Features

- **CQRS Pattern**: Separates the read and write operations to optimize performance and scalability.
- **Mediator Pattern**: Enables decoupled communication between different parts of the application.
- **Fluent Validation**: Implements custom error handling middleware for robust input validation.
- **Filters**: Provides a mechanism to intercept and modify the request and response pipeline.
- **Localization**: Supports Arabic to English localization and vice versa.
- **Database Operations**: Utilizes stored procedures for efficient database interaction.
- **Pagination Schema**: Implements pagination for large datasets.
- **Identity Management**: Supports user and role management.
- **Role Manipulation**: Facilitates role-based access control.
- **Fluent API**: Uses a fluent interface for configuration and querying.
- **JWT Token and Refresh Tokens**: Implements secure authentication with token management.
- **Token Activation and Validation**: Checks the health of tokens and allows activation of expired tokens.
- **Generic Repository and Unit of Work**: Follows best practices for data access and manipulation.
- **Routing Schema**: Defines custom routing for better API organization.
- **Readable Response Schema**: Ensures responses are easy to understand for clients.
- **Dependency Injection**: Utilizes DI for better modularity and testability.

## Database Backup

The project includes a backup of its database named `SchoolManagementSystemDB.bak`, which can be used to restore the database for testing or further development.

### Authentication

Use the following credentials to log in as an admin:

- **Username**: Mani
- **Password**: Passw0rd#
