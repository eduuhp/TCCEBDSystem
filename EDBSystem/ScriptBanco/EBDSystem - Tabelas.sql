CREATE DATABASE EBDSystem;
GO

USE EBDSystem;
GO

--TABELAS--

CREATE TABLE [Restriction]
(
		IdRestriction		TINYINT
	,	NameRestriction		VARCHAR(30)
	,	CONSTRAINT PK_Restriction PRIMARY KEY (IdRestriction)
);
GO

CREATE TABLE [Profile]
(
		IdProfile		TINYINT IDENTITY(1,1)
	,	NameProfile		VARCHAR(25)
	,	CONSTRAINT PK_Profile PRIMARY KEY (IdProfile)
);
GO

CREATE TABLE ProfileRestriction
(
		IdProfile		TINYINT
	,	IdRestriction	TINYINT
	,	CONSTRAINT PK_ProfileRestriction PRIMARY KEY (IdProfile, IdRestriction)
	,	CONSTRAINT FK_Profile FOREIGN KEY (IdProfile) REFERENCES [Profile](IdProfile)
	,	CONSTRAINT FK_Restriction FOREIGN KEY (IdRestriction) REFERENCES [Restriction](IdRestriction)
);
GO

CREATE TABLE Department
(
		IdDepartment			TINYINT IDENTITY(1,1)
	,	NameDepartment			VARCHAR(50)
	,	DescriptionDepartment	VARCHAR(200)
	,	CONSTRAINT PK_IdDepartment PRIMARY KEY (IdDepartment)
);
GO

CREATE TABLE Notice
(
		IdNotice		TINYINT IDENTITY(1,1)
	,	TitleNotice		VARCHAR(50)
	,	ContentNotice	VARCHAR(200)
	,	CONSTRAINT PK_Notice PRIMARY KEY (IdNotice)
	
);
GO

CREATE TABLE DepartmentNotice
(
		IdDepartment	TINYINT 
	,	IdNotice		TINYINT
	,	CONSTRAINT PK_DepartmentNotice	PRIMARY KEY (IdDepartment, IdNotice)
	,	CONSTRAINT FK_Department FOREIGN KEY (IdDepartment) REFERENCES Department(IdDepartment)
	,	CONSTRAINT FK_Notice FOREIGN KEY (IdNotice) REFERENCES Notice(IdNotice)
);
GO

CREATE TABLE [Period]
(
		IdPeriod	TINYINT IDENTITY(1,1)
	,	NamePeriod	VARCHAR(50)
	,	StartDate	DATETIME
	,	EndDate		DATETIME
	,	CONSTRAINT PK_Period PRIMARY KEY (IdPeriod)
);
GO

CREATE TABLE ClassEBD
(
		IdClassEBD		TINYINT IDENTITY(1,1)
	,	NameClassEBD	VARCHAR(50)
	,	IdDepartment	TINYINT
	,	IdPeriod		TINYINT
	,	CONSTRAINT PK_ClassEBD PRIMARY KEY (IdClassEBD)
	,	CONSTRAINT FK_DepartmentClassEBD FOREIGN KEY (IdDepartment) REFERENCES Department(IdDepartment)
	,	CONSTRAINT FK_PeriodClassEBD FOREIGN KEY (IdPeriod) REFERENCES [Period](IdPeriod)
);
GO

CREATE TABLE [User]
(
		IdUser			TINYINT IDENTITY(1,1)
	,	FirstNameUser	VARCHAR(25)
	,	LastNameUser	VARCHAR(75)
	,	DateBirthUser	DATETIME
	,	LoginUser		VARCHAR(25)
	,	PasswordUser	VARCHAR(25)
	,	IdProfile		TINYINT 
	,	IdClassEBD		TINYINT 
	,	CONSTRAINT PK_User PRIMARY KEY (IdUser)
	,	CONSTRAINT FK_ProfileUser FOREIGN KEY (IdProfile) REFERENCES [Profile](IdProfile)
	,	CONSTRAINT FK_ClassEBDUser FOREIGN KEY (IdClassEBD) REFERENCES ClassEBD(IdClassEBD)
);
GO

CREATE TABLE Frequency
(
		IdFrequency		TINYINT IDENTITY(1,1)
	,	DateFrequency	DATETIME
	,	CONSTRAINT PK_Frenquency PRIMARY KEY (IdFrequency)
);
GO

CREATE TABLE UserFrequency
(
		IdFrequency		TINYINT
	,	IdUser			TINYINT
	,	Frequent		BIT
	,	CONSTRAINT PK_UserFrenquency PRIMARY KEY (IdFrequency)
	,	CONSTRAINT FK_Frequency FOREIGN KEY (IdFrequency) REFERENCES Frequency(IdFrequency)
	,	CONSTRAINT FK_User FOREIGN KEY (IdUser) REFERENCES [User](IdUser)
);
GO

CREATE TABLE RelatoryClass
(
		IdRelatoryClass				INT IDENTITY(1,1)
	,	VisitorsRelatoryClass		TINYINT
	,	TotalBiblesRelatoryClass	TINYINT
	,	TotalMagazinesRelatoryClass	TINYINT
	,	TotalOffersRelatoryClass	TINYINT
	,	CommentsRelatoryClass		VARCHAR(200)
	,	CONSTRAINT PK_RelatoryClass PRIMARY KEY (IdRelatoryClass)
);
GO