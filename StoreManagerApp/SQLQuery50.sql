CREATE TABLE [dbo].[Orders] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [CustomerId] INT NULL,
    [OrderAmount] DECIMAL(10,2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
