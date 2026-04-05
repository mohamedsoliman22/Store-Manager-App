DROP TABLE IF EXISTS Products;
GO
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL
);
GO

INSERT INTO Products (ProductName, Price, Quantity)
VALUES ('Pen', 10.5, 50);
GO

INSERT INTO Products (ProductName, Price, Quantity)
VALUES ('Notebook', 25.0, 30);
GO
