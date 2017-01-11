create table [EventLog]
(
	[EventLogID] int not null identity(1, 1),
	[EventType] int not null,
	[Key] varchar(255) not null,
	[Message] varchar(max) not null,
	[EntryDate] datetime not null
)

create table [ChangeLog]
(
	[ChangeLogID] int not null identity(1, 1),
	[ClassName] varchar(255) not null,
	[PropertyName] varchar(255) not null,
	[OriginalValue] varchar(max) null,
	[CurrentValue] varchar(max) null,
	[UserName] varchar(25) not null,
	[ChangeDate] datetime not null
)

create table [HumanResources].[Employee]
(
	[EmployeeID] int not null identity(1, 1),
	[FirstName] varchar(25) not null,
	[MiddleName] varchar(25) null,
	[LastName] varchar(25) not null,
	[BirthDate] datetime not null
)

create table [Production].[ProductCategory]
(
	[ProductCategoryID] int not null identity(1, 1),
	[ProductCategoryName] varchar(100) not null
)

create table [Production].[Product]
(
	[ProductID] int not null identity(1, 1),
	[ProductName] varchar(100) not null,
	[ProductCategoryID] int not null,
	[UnitPrice] decimal(8, 4) not null,
	[Description] varchar(255) null,
	[Discontinued] bit not null,
	[CreationUser] varchar(25) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] varchar(25) null,
	[LastUpdateDateTime] datetime null
)

create table [Production].[ProductInventory]
(
	[ProductInventoryID] int not null identity(1, 1),
	[ProductID] int not null,
	[EntryDate] datetime not null,
	[Quantity] int not null,
	[Stocks] int not null
)

create table [Sales].[Customer]
(
	[CustomerID] int not null identity(1, 1),
	[CompanyName] varchar(100) null,
	[ContactName] varchar(100) null
)

create table [Sales].[Shipper]
(
	[ShipperID] int not null identity(1, 1),
	[CompanyName] varchar(100) null,
	[ContactName] varchar(100) null
)

create table [Sales].[OrderStatus]
(
	[OrderStatusID] smallint not null identity(100, 100),
	[Description] varchar(100) not null
)

create table [Sales].[Order]
(
	[OrderID] int not null identity(1, 1),
	[OrderStatusID] smallint not null,
	[OrderDate] datetime not null,
	[CustomerID] int not null,
	[EmployeeID] int not null,
	[ShipperID] int not null,
	[Total] decimal(12, 4) not null,
	[Comments] varchar(255) null,
	[CreationUser] varchar(25) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] varchar(25) null,
	[LastUpdateDateTime] datetime null
)

create table [Sales].[OrderDetail]
(
	[OrderID] int not null,
	[ProductID] int not null,
	[ProductName] varchar(255) not null,
	[UnitPrice] decimal(8, 4) not null,
	[Quantity] int not null,
	[Total] decimal(8, 4) not null
)
go
