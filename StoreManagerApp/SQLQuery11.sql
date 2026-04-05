CREATE TABLE [dbo].[Customers] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CustomerName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100),
    [PhoneNumber] NVARCHAR(20),
    [Address] NVARCHAR(200),
    [RegistrationDate] DATE
);
GO
