# Store Manager App

A Windows Forms application for managing a store's inventory, customers, orders, and users. Built with C# and .NET 9.0, using SQL Server LocalDB for data storage.

## Features

- **User Authentication**: Login and signup functionality with role-based access (admin/user)
- **Product Management**: Add, edit, view, and manage store products with pricing and inventory tracking
- **Customer Management**: Maintain customer database with contact information and registration details
- **Order Management**: Track customer orders and order amounts
- **Query System**: Complex query forms for data analysis and reporting
- **User Management**: Admin panel for managing user accounts and permissions

## Prerequisites

- **.NET 9.0 SDK** - Download from [Microsoft .NET](https://dotnet.microsoft.com/download/dotnet/9.0)
- **SQL Server LocalDB** - Usually installed with Visual Studio, or download from [Microsoft SQL Server](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

## Database Setup

1. Ensure SQL Server LocalDB is installed and running
2. Open SQL Server Management Studio or Visual Studio SQL Server Object Explorer
3. Create a new database named `ECommerceDB`
4. Run the following SQL scripts in order to set up the database schema:

   - `CreateUsersTable.sql` - Creates the Users table and inserts an admin user
   - `SQLQuery4.sql` - Creates the Customers table
   - `SQLQuery5.sql` - Creates the Products table
   - `SQLQuery6.sql` - Creates the Orders table (if not already created)
   - `InsertTestData.sql` or `SQLQuery3.sql` - Inserts sample data

   **Default Admin Credentials:**
   - Username: `admin`
   - Password: `admin123`

## Installation and Running

1. Clone or download the project
2. Open the solution file `StoreManagerApp.sln` in Visual Studio
3. Restore NuGet packages (should happen automatically)
4. Build the solution
5. Run the application

The application will start with the login form. Use the admin credentials above to log in initially.

## Project Structure

- `Program.cs` - Application entry point
- `LoginForm.cs` - User authentication
- `MainForm.cs` - Main application dashboard
- `ProductForm.cs` - Product management interface
- `CustomerForm.cs` - Customer management interface
- `OrderForm.cs` - Order management interface
- `QueryForm.cs` - Complex query interface
- `ManageUsersForm.cs` - User management (admin only)
- `DatabaseHelper.cs` - Database connection and query utilities
- `UserSession.cs` - User session management

## Dependencies

- Microsoft.Data.SqlClient (6.0.2) - Modern SQL Server data access
- System.Data.SqlClient (4.9.0) - Legacy SQL Server data access
- .NET 9.0 Windows Forms

## Database Schema

### Users Table
- Id (INT, Primary Key)
- Username (NVARCHAR(50), Unique)
- Password (NVARCHAR(100))
- Email (NVARCHAR(100), Unique)
- IsAdmin (BIT)
- CreatedDate (DATETIME)

### Customers Table
- Id (INT, Primary Key)
- CustomerName (NVARCHAR(100))
- Email (NVARCHAR(100))
- PhoneNumber (NVARCHAR(20))
- Address (NVARCHAR(200))
- RegistrationDate (DATE)

### Products Table
- Id (INT, Primary Key)
- ProductName (NVARCHAR(100))
- Price (DECIMAL(10,2))
- Quantity (INT)

### Orders Table
- Id (INT, Primary Key)
- CustomerId (INT, Foreign Key to Customers)
- OrderAmount (DECIMAL(10,2))

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License

This project is for educational purposes. Please check individual file licenses if any.</content>
<parameter name="filePath">c:\StoreManagerApp\StoreManagerApp orignal\README.md
