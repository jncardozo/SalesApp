
/*
ALTER TABLE Customers DROP CONSTRAINT [PK_Customers];

ALTER TABLE InvoiceHeader DROP CONSTRAINT [PK_InvoiceHeader];

ALTER TABLE InvoiceItems DROP CONSTRAINT [PK_InvoiceItems];
*/
/*
ALTER TABLE InvoiceHeader
ADD FOREIGN KEY (CustomerId) REFERENCES Customers(Id);

ALTER TABLE InvoiceHeader
ADD FOREIGN KEY (EmployeeId) REFERENCES Employees(Id);

ALTER TABLE InvoiceItems
ADD FOREIGN KEY (ProductId) REFERENCES Products(Id);

ALTER TABLE InvoiceItems
ADD FOREIGN KEY (InvoiceId) REFERENCES InvoiceHeader(Id);

ALTER TABLE Employees 
ADD Age INT NULL;
*/
