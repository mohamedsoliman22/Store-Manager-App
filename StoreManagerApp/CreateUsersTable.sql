-- Create Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    IsAdmin BIT NOT NULL DEFAULT 0,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);

-- Insert admin user (password: admin123)
INSERT INTO Users (Username, Password, Email, IsAdmin)
VALUES ('admin', 'admin123', 'admin@store.com', 1); 