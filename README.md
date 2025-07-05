# MuhasebeApp API

**Under active development**
> **Note:** This project is currently under active development and may undergo significant changes.

MuhasebeApp is an accounting application API developed with .NET 8, featuring JWT-based user authentication and PostgreSQL integration.

---

## Features

- User registration and login (secure sessions with JWT)
- Password hashing and verification with BCrypt
- PostgreSQL database integration (Entity Framework Core)
- Layered architecture: Controller, Service, Repository
- Invoice and stock management modules
- API documentation with Swagger

---

## Getting Started

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- PostgreSQL database
- Visual Studio / VS Code or another IDE

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/muhasebeapp.git
    cd muhasebeapp/API
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Update the database connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "WebApiDatabase": "Host=localhost;Database=muhasebe;Username=postgres;Password=yourpassword"
    }
    ```

4. Configure JWT settings in `appsettings.json`:
    ```json
    "JwtSettings": {
        "Key": "this-is-a-very-secret-key-123456",
        "Issuer": "muhasebeapp",
        "Audience": "muhasebeappusers",
        "ExpireMinutes": 60
    }
    ```

5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

---

## Usage

- Access API documentation at `https://localhost:5001/swagger`.
- Register a user via `/api/user/register`.
- Login and obtain JWT token via `/api/user/login`.
- Manage invoices and related stock quantities with dedicated endpoints.
- Only authorized users can create invoices for their own companies.

---

## Architecture

- **Controller:** Handles HTTP requests and calls services.
- **Service:** Contains business logic and uses repositories.
- **Repository:** Handles data access operations.
- **Invoice Management:** Create, read, and delete invoices; updates stock quantities accordingly.
- **Stock Management:** Track product quantities and update inventory based on invoices.
- **JWT:** Uses JSON Web Token for user authentication.
- **Password Hashing:** Ensures security with BCrypt hashing.

---

## Notes

- Passwords are always stored hashed, never in plain text.
- JWT keys and other secrets should be securely stored in `appsettings.json` or environment variables.
- Services are registered using dependency injection.
- Invoice creation is restricted to the company owners only.
- Stock levels are automatically updated when invoices are created or deleted.
- Please open issues for bugs or feature requests.

---

## License

MIT License © 2025 Utku Berki
