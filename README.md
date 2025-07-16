# MuhasebeApp

MuhasebeApp is a modern accounting API built with .NET 8, Entity Framework Core, and PostgreSQL. It features a scalable, enterprise-grade architecture inspired by leading SaaS accounting solutions (like Paraşüt), and supports CQRS, MediatR, and robust user management.

---

## Features

- **User Management:**  
  - Phone number-based login (with area code separation)
  - Optional email and address fields
  - Secure password hashing (BCrypt)
- **Company Management:**  
  - Singular table naming convention
  - Tax office and tax number fields
- **Accounting Core:**  
  - Modern chart of accounts structure
  - Separate tables for Customers, Suppliers, and Bank Accounts
  - Flexible Account entity referencing Customer, Supplier, or BankAccount
  - Account categories seeded by default
- **CQRS Architecture:**  
  - Command/Query separation with MediatR
  - Service and repository layers for all master data
- **Database Management:**  
  - Automated migrations and seed data
  - PostgreSQL support

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- PostgreSQL database

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/muhasebeapp.git
   cd muhasebeapp
   ```

2. **Configure the database:**
   - Update your `appsettings.json` with your PostgreSQL connection string.

3. **Apply migrations and seed data:**
   ```bash
   dotnet ef database update --project MuhasebeAPI.Infrastructure/MuhasebeAPI.Infrastructure.csproj --startup-project MuhasebeAPI/MuhasebeAPI.API.csproj
   ```

4. **Run the application:**
   ```bash
   dotnet run --project MuhasebeAPI/MuhasebeAPI.API.csproj
   ```

5. **Access the API:**
   - Swagger UI: `https://localhost:5001/swagger`

---

## API Overview

- **User Endpoints:**  
  - Register, login, and manage users via phone number
- **Company Endpoints:**  
  - Create and manage companies, including tax office and tax number
- **Customer, Supplier, BankAccount Endpoints:**  
  - Full CRUD operations with CQRS
- **Account Endpoints:**  
  - Create accounts linked to customers, suppliers, or bank accounts

---

## Technologies Used

- .NET 8
- Entity Framework Core
- PostgreSQL
- MediatR (CQRS)
- BCrypt (Password Hashing)
- Swagger (API Documentation)

---

## Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

---

## License

[MIT](LICENSE.txt)
