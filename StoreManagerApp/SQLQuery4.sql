CREATE TABLE [dbo].[Customers] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerName]     NVARCHAR (100) NOT NULL,
    [Email]            NVARCHAR (100) NULL,
    [PhoneNumber]      NVARCHAR (20)  NULL,
    [Address]          NVARCHAR (200) NULL,
    [RegistrationDate] DATE           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

