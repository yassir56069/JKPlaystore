# JKPlaystore Backoffice

## Overview
The **JKPlaystore Backoffice** is a Blazor-based application designed to streamline administrative operations for the JKPlaystore database hosted on Microsoft SQL Server Management Studio (SSMS). This system provides an intuitive and secure interface for managing tokens and customer keys, ensuring seamless integration with business processes.

## Features
- **Token Management**: Generate, view, and manage authentication tokens for system users.
- **Customer Key Generation**: Create unique keys for customers, facilitating secure identification and access.
- **Data Security**: Built with modern security best practices to safeguard sensitive information.

## Prerequisites
To run and maintain the JKPlaystore Backoffice, ensure the following requirements are met:

### System Requirements
- **Operating System**: Windows 10 or higher
- **Database**: Microsoft SQL Server (SSMS) 2019 or later
- **Development Environment**: Visual Studio 2022 with .NET 7.0 SDK

### Database Configuration
The application connects to the **JKPlaystore** database. Ensure the database includes the following key tables:

- **BCO_Users**: Manages user authentication credentials.
- **Customers**: Stores customer information and related keys.
- **Tokens**: Manages authentication tokens.

## Installation and Setup
### 1. Clone the Repository
Clone the project repository to your local machine:
```bash
git clone https://github.com/your-repo/jkplaystore-backoffice.git
```

### 2. Configure the Database Connection
Set up the database connection string in the `secrets.json` file:
```json
{
  "ConnectionStrings": {
    "DatabaseConnection": "Your_SQL_Server_Connection_String"
  }
}
```
Ensure the connection string includes appropriate credentials and points to the JKPlaystore database.

### 3. Run the Application
Open the solution in Visual Studio, build the project, and run the application:
```bash
dotnet run
```
Access the application through your local development server, typically at `https://localhost:5001`.

## Usage Instructions
### 1. Logging In
Use the provided administrator credentials to log in to the backoffice.

### 2. Managing Tokens
- Navigate to the **Token Management** section.
- Click **Create Token** to generate a new token.
- View and revoke tokens as necessary to maintain system security.

### 3. Generating Customer Keys
- Navigate to the **Customer Management** section.
- Select a customer from the list or add a new customer.
- Click **Generate Key** to create a unique key for the selected customer.

## Security Measures
- **Connection Strings**: Secured using the `secrets.json` file and encrypted storage mechanisms.
- **User Authentication**: Implements role-based access control to restrict access to administrative functions.
- **Data Validation**: Ensures integrity by validating user inputs before processing.

## Maintenance
### Updating the Application
To update the backoffice application:
1. Pull the latest changes from the repository:
   ```bash
   git pull origin main
   ```
2. Rebuild and restart the application.

### Database Maintenance
Regularly back up the JKPlaystore database and monitor token expiration policies to ensure consistent performance and security.
