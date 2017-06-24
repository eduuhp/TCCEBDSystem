USE [EBDSystem]
GO

INSERT INTO Department
           (NameDepartment
           ,DescriptionDepartment)
     VALUES
           ('Adultos'
           ,'Entre 30 e 59 anos')
GO


INSERT INTO Notice
           (TitleNotice
           ,ContentNotice)
     VALUES
           ('Batismo'
           ,'Dia 24/04/2004')
GO

INSERT INTO [Period]
           (NamePeriod
           ,StartDate
           ,EndDate)
     VALUES
           ('Primeiro'
           ,N'01-01-2012'
           ,N'12-11-2012')
GO

INSERT INTO ClassEBD
           (NameClassEBD
           ,IdDepartment
           ,IdPeriod)
     VALUES
           ('Leões de Jesus'
           ,1
           ,1)
GO

INSERT INTO Restriction (IdRestriction, NameRestriction)
	VALUES	(1, 'Visualizar Restrição')
		,	(2, 'Cadastrar Perfil')
		,	(3, 'Editar Perfil')
		,	(4, 'Excluir Perfil')
		,	(5, 'Visualizar Perfil')
		,	(6, 'Cadastrar Usuario')
		,	(7, 'Editar Usuario')
		,	(8, 'Excluir Usuario')
		,	(10, 'Visualizar Usuario')
		,	(11, 'Cadastrar Classe')
		,	(12, 'Editar Classe')
		,	(13, 'Excluir Classe')
		,	(14, 'Visualizar Classe')
		,	(15, 'Cadastrar Notícia')
		,	(16, 'Editar Notícia')
		,	(17, 'Excluir Notícia')
		,	(18, 'Visualizar Notícia')
		,	(19, 'Cadastrar Período')
		,	(20, 'Editar Período')
		,	(21, 'Excluir Período')
		,	(22, 'Visualizar Período')
		,	(23, 'Cadastrar Departamento')
		,	(24, 'Editar Departamento')
		,	(25, 'Excluir Departamento')
		,	(26, 'Visualizar Departamento')
		,	(27, 'Cadastrar Aluno')
		,	(28, 'Editar Aluno')
		,	(29, 'Excluir Aluno')
		,	(30, 'Visualizar Aluno')
		,	(31, 'Visualizar Relatório')
		,	(32, 'Visualizar Raking')
		,	(33, 'Visualizar Presença')
		,	(34, 'Realizar Chamada');
GO

INSERT INTO [Profile]
           (NameProfile)
     VALUES
           ('Administradores')
GO

INSERT INTO ProfileRestriction
           (IdProfile
           ,IdRestriction)
     VALUES (1,1)
	 ,		(1,2)
	 ,		(1,3)
	 ,		(1,4)
	 ,		(1,5)
	 ,		(1,6)
	 ,		(1,7)
	 ,		(1,8)
	 ,		(1,9)
	 ,		(1,10)
	 ,		(1,11)
	 ,		(1,12)
	 ,		(1,13)
	 ,		(1,14)
	 ,		(1,15)
	 ,		(1,16)
	 ,		(1,17)
	 ,		(1,18)
	 ,		(1,19)
	 ,		(1,20)
	 ,		(1,21)
	 ,		(1,22)
	 ,		(1,23)
	 ,		(1,24)
	 ,		(1,25)
	 ,		(1,26)
	 ,		(1,27)
	 ,		(1,28)
	 ,		(1,29)
	 ,		(1,30)
	 ,		(1,31)
	 ,		(1,32)
	 ,		(1,33)
	 ,		(1,34)
GO

INSERT INTO [User]
           (FirstNameUser
           ,LastNameUser
           ,DateBirthUser
           ,LoginUser
           ,PasswordUser
           ,IdProfile
           ,IdClassEBD)
     VALUES
           ('Administrador'
           ,'Principal'
           ,N'01-01-2012'
           ,'admin'
           ,'admin'
           ,1
           ,1)
GO

INSERT INTO Frequency
           (DateFrequency)
     VALUES
           (N'01-01-2012')
GO

INSERT INTO UserFrequency
           (IdFrequency
           ,IdUser
           ,Frequent)
     VALUES
           (1
           ,1
           ,1)
GO














INSERT INTO [dbo].[DepartmentNotice]
           ([IdDepartment]
           ,[IdNotice])
     VALUES
           (<IdDepartment, tinyint,>
           ,<IdNotice, tinyint,>)
GO





