-- Insert sample data into Customers (without SET IDENTITY_INSERT)
INSERT INTO Customers (CustomerName, Email, PhoneNumber, Address, RegistrationDate)
VALUES 
('Ahmed Ali', 'ahmed@example.com', '0100000001', 'Nasr City', '2023-05-01'),
('Sara Mahmoud', 'sara@example.com', '0100000002', 'Maadi', '2023-05-03'),
('Mohamed Salah', 'm.salah@example.com', '0100000003', 'Zamalek', '2023-06-01'),
('Nour El-Din', 'nour@example.com', '0100000004', 'Heliopolis', '2023-06-05'),
('Alaa Farouk', 'alaa@example.com', '0100000005', '6th October', '2023-06-10');

-- Insert sample orders
INSERT INTO Orders (CustomerId, OrderAmount)
VALUES 
(1, 950.00),
(2, 1100.00),
(3, 450.00),
(1, 800.00),
(2, 500.00),
(4, 600.00),
(5, 700.00);

-- Insert sample products
INSERT INTO Products (ProductName, Price, Quantity)
VALUES 
('T-Shirt', 250.00, 50),
('Shoes', 450.00, 20),
('Smartwatch', 1500.00, 10),
('Backpack', 300.00, 25),
('Sunglasses', 600.00, 8),
('Headphones', 850.00, 6),
('Water Bottle', 100.00, 100);
