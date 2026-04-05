-- حذف العلاقة لو كانت موجودة مسبقاً
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Orders_Customers')
BEGIN
    ALTER TABLE Orders DROP CONSTRAINT FK_Orders_Customers;
END

-- إنشاء العلاقة بين Orders.CustomerId و Customers.Id
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerId) REFERENCES Customers(Id);

PRINT '✅ Foreign key FK_Orders_Customers created successfully.';
