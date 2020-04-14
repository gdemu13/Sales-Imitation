if not exists (select * from sysobjects where name='SuperBonuses' and xtype='U')
    create table SuperBonuses (
		ID uniqueidentifier PRIMARY KEY,
		BaseAmount decimal(9,2) NOT NULL,
		Status TINYINT NOT NULL,
    )
go

if not exists (select * from sysobjects where name='SuperBonusIncreases' and xtype='U')
    create table SuperBonusIncreases (
		ID uniqueidentifier PRIMARY KEY,
		Amount decimal(9,2) NOT NULL,
		Source nvarchar(MAX) NOT NULL,
		SuperBonusID uniqueidentifier NOT NULL,
		FOREIGN KEY (SuperBonusID) REFERENCES SuperBonuses(ID)
    )
go