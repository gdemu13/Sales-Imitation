if not exists (select * from sysobjects where name='Users' and xtype='U')
    create table Users (
		ID uniqueidentifier PRIMARY KEY,
		UserName nvarchar(100) NOT NULL,
		PasswordHash nvarchar(max) NOT NULL,
		LastUpdateDate DATETIME NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )
	IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Users_Ordering' AND object_id = OBJECT_ID('Users'))
    BEGIN
	CREATE UNIQUE INDEX Users_Ordering
	ON Users (Ordering);
	CREATE UNIQUE INDEX Users_UserName
	ON Users (UserName);
    END
go


if not exists (select * from sysobjects where name='Players' and xtype='U')
    create table Players (
		ID uniqueidentifier PRIMARY KEY,
		Username nvarchar(100) unique NOT NULL,
		FirstName nvarchar(100) NOT NULL,
		LastName nvarchar(100) NOT NULL,
		Email nvarchar(100) NOT NULL,
		Level int NOT NULL,
		Coins decimal(9,2) NOT NULL,
		PasswordHash nvarchar(max) NOT NULL,
		LastUpdateDate DATETIME NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )
	IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Players_Ordering' AND object_id = OBJECT_ID('Players'))
    BEGIN
	CREATE UNIQUE INDEX Players_Ordering
	ON Players (Ordering);
	CREATE UNIQUE INDEX Players_UserName
	ON Players (Username);
    END
go
if not exists (select * from sysobjects where name='SuperBonuses' and xtype='U')
    create table SuperBonuses (
		ID uniqueidentifier PRIMARY KEY,
		BaseAmount decimal(9,2) NOT NULL,
		Status TINYINT NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )
	IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'SuperBonuses_Ordering' AND object_id = OBJECT_ID('SuperBonuses'))
    BEGIN
	CREATE UNIQUE INDEX SuperBonuses_Ordering
	ON SuperBonuses (Ordering);
    END
go

if not exists (select * from sysobjects where name='SuperBonusIncreases' and xtype='U')
    create table SuperBonusIncreases (
		ID uniqueidentifier PRIMARY KEY,
		Amount decimal(9,2) NOT NULL,
		Source nvarchar(MAX) NOT NULL,
		SuperBonusID uniqueidentifier NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		FOREIGN KEY (SuperBonusID) REFERENCES SuperBonuses(ID)
    )
	IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'SuperBonusIncreases_Ordering' AND object_id = OBJECT_ID('SuperBonusIncreases'))
    BEGIN
		CREATE UNIQUE INDEX SuperBonusIncreases_Ordering
		ON SuperBonusIncreases (Ordering);
    END
go

if not exists (select * from sysobjects where name='Categories' and xtype='U')
    create table Categories (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(250) UNIQUE NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		IsActive bit NOT NULL,
    )
	IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Categories_Ordering' AND object_id = OBJECT_ID('Categories'))
    BEGIN
		CREATE UNIQUE INDEX Categories_Ordering
		ON Categories (Ordering);
    END
go

if not exists (select * from sysobjects where name='Partners' and xtype='U')
    create table Partners (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(250) UNIQUE NOT NULL,
		LogoUrl nvarchar(MAX) NOT NULL,
		Street nvarchar(MAX) NOT NULL,
		Number nvarchar(MAX) NOT NULL,
		Email nvarchar(MAX) NOT NULL,
		ContactPersonFirstName nvarchar(MAX) NOT NULL,
		ContactPersonLastName nvarchar(MAX) NOT NULL,
		ContactPersonNumber nvarchar(MAX) NOT NULL,
		ContactPersonEmail nvarchar(MAX) NOT NULL,
		WebSite nvarchar(MAX) NOT NULL,
		IsActive bit NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )

		IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Partners_Ordering' AND object_id = OBJECT_ID('Partners'))
    BEGIN
		CREATE UNIQUE INDEX Partners_Ordering
		ON Partners (Ordering);
    END
go

if not exists (select * from sysobjects where name='Products' and xtype='U')
    create table Products (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(250) UNIQUE NOT NULL,
		Description nvarchar(MAX) NOT NULL,
		Price decimal(9,2) NOT NULL,
		Point INT NOT NULL,
		PartnerID uniqueidentifier NOT NULL,
		CategoryID uniqueidentifier,
		ProductGroupID uniqueidentifier NOT NULL,
		IsActive BIT NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		FOREIGN KEY (PartnerID) REFERENCES Partners(ID),
		FOREIGN KEY (CategoryID) REFERENCES Categories(ID)
    )
		IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Products_Ordering' AND object_id = OBJECT_ID('Products'))
    BEGIN
		CREATE UNIQUE INDEX Products_Ordering
		ON Products (Ordering);
    END
go

if not exists (select * from sysobjects where name='ProductImages' and xtype='U')
    create table ProductImages (
		ID uniqueidentifier PRIMARY KEY,
		Url nvarchar(MAX) NOT NULL,
		ProductID uniqueidentifier NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		FOREIGN KEY (ProductID) REFERENCES Products(ID),
    )

		IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'ProductImages_Ordering' AND object_id = OBJECT_ID('ProductImages'))
    BEGIN
		CREATE UNIQUE INDEX ProductImages_Ordering
		ON ProductImages (Ordering);
    END
go

if not exists (select * from sysobjects where name='Missions' and xtype='U')
    create table Missions (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(250) UNIQUE NOT NULL,
		Description nvarchar(MAX) NOT NULL,
		Level INT NOT NULL UNIQUE,
		PriceFrom decimal(9,2) NOT NULL,
		PriceTo decimal(9,2) NOT NULL,
		LastUpdateDate DATETIME NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )

		IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'Missions_Ordering' AND object_id = OBJECT_ID('Missions'))
    BEGIN
		CREATE UNIQUE INDEX Missions_Ordering
		ON Missions (Ordering);
    END
go

if not exists (select * from sysobjects where name='CurrentMissions' and xtype='U')
    create table CurrentMissions (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(250) NOT NULL,
		Description nvarchar(MAX) NOT NULL,
		Level INT NOT NULL UNIQUE,
		Point decimal(9,2) NOT NULL,
		PlayerID uniqueidentifier,
		Prod1ID uniqueidentifier,
		Prod1Name nvarchar(250) NOT NULL,
		Prod1Desc nvarchar(250) NOT NULL,
		Prod1PartnerName nvarchar(250) NOT NULL,
		Prod1PartnerAddress nvarchar(250) NOT NULL,
		Prod1Benefits nvarchar(250) NOT NULL,
		Prod2ID uniqueidentifier,
		Prod2Name nvarchar(250) NOT NULL,
		Prod2Desc nvarchar(250) NOT NULL,
		Prod2PartnerName nvarchar(250) NOT NULL,
		Prod2PartnerAddress nvarchar(250) NOT NULL,
		Prod2Benefits nvarchar(250) NOT NULL,
		CategoryID uniqueidentifier NOT NULL,
		CategoryName nvarchar(250) NOT NULL,
		PromoCode nvarchar(12) NOT NULL,
		Status int NOT NULL,
		Duration int NOT NULL,
		StartedDate DATETIME,
		FinishedDate DATETIME,
		LastUpdateDate DATETIME NOT NULL,
		AddedHours int NOT NULL,
		EarnedCoints decimal(9,2) NOT NULL,
		CategoryUpdated int NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		FOREIGN KEY (PlayerID) REFERENCES Players(ID),
    )

		IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'CurrentMissions_Ordering' AND object_id = OBJECT_ID('CurrentMissions'))
    BEGIN
		CREATE UNIQUE INDEX CurrentMissions_Ordering
		ON CurrentMissions (Ordering);
    END
go
