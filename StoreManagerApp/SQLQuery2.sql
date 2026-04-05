-- 1. حذف الـ FK لو موجود
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Orders_Customers')
BEGIN
    ALTER TABLE Orders DROP CONSTRAINT FK_Orders_Customers;
END

-- 2. استخراج CustomerId المفقود
SELECT DISTINCT CustomerId
INTO #MissingCustomers
FROM Orders
WHERE CustomerId IS NOT NULL
AND CustomerId NOT IN (SELECT Id FROM Customers);

-- 3. إدخال العملاء الوهميين بنفس الـ Id
SET IDENTITY_INSERT Customers ON;

INSERT INTO Customers (Id, CustomerName)
SELECT CustomerId, 'TempCustomer_' + CAST(CustomerId AS NVARCHAR)
FROM #MissingCustomers;

SET IDENTITY_INSERT Customers OFF;

DROP TABLE #MissingCustomers;

-- 4. إنشاء الـ Foreign Key
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerId) REFERENCES Customers(Id);

PRINT '✅ Foreign key added successfully.';
