if not exists (select * from sysobjects where name='SuperBonuses' and xtype='U')
    create table SuperBonuses (
		ID uniqueidentifier PRIMARY KEY,
		BaseAmount decimal(9,2) NOT NULL,
		Status TINYINT NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL
    )

	CREATE UNIQUE INDEX SuperBonuses_Ordering
	ON SuperBonuses (Ordering);
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

	CREATE UNIQUE INDEX SuperBonusIncreases_Ordering
	ON SuperBonusIncreases (Ordering);
go

if not exists (select * from sysobjects where name='Categories' and xtype='U')
    create table Categories (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(MAX) NOT NULL,
		Ordering INT IDENTITY(1,1) NOT NULL,
		IsActive bit NOT NULL,
    )

	CREATE UNIQUE INDEX Categories_Ordering
	ON Categories (Ordering);
go

if not exists (select * from sysobjects where name='Partners' and xtype='U')
    create table Partners (
		ID uniqueidentifier PRIMARY KEY,
		Name nvarchar(MAX) NOT NULL,
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

	CREATE UNIQUE INDEX Partners_Ordering
	ON Partners (Ordering);
go