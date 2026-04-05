CREATE TABLE [dbo].[Customers] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CustomerName] NVARCHAR(100) NOT NULL
);
GO

-- بيانات تجريبية
INSERT INTO Customers (CustomerName) VALUES ('Ahmed Soliman');
GO

INSERT INTO Customers (CustomerName) VALUES ('Mona Khaled');
GO

INSERT INTO Customers (CustomerName) VALUES ('Youssef Amin');
GO
