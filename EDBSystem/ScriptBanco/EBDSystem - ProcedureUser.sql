--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-------------VERIFICAR-------------------------------------------------------------------------------------------------
-----------------VERIFICAR SE JÁ EXISTE ESSE LOGIN---------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE USER--

CREATE PROCEDURE spInsertUser
		@pFirstNameUser		VARCHAR(25)
	,	@pLastNameUser		VARCHAR(75)
	,	@pDateBirthUser		DATETIME
	,	@pLoginUser			VARCHAR(25)
	,	@pPasswordUser		VARCHAR(25) = "abcd12345"
	,	@pIdProfile			TINYINT
	,	@pIdClassEBD		TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		IF NOT EXISTS(SELECT LoginUser FROM [User] WHERE LoginUser = @pLoginUser)
		BEGIN
			INSERT
			INTO	[User]
			(
					FirstNameUser
				,	LastNameUser
				,	DateBirthUser
				,	LoginUser
				,	PasswordUser
				,	IdProfile
				,	IdClassEBD
			)
			VALUES 
			(
					@pFirstNameUser
				,	@pLastNameUser
				,	@pDateBirthUser
				,	@pLoginUser
				,	@pPasswordUser
				,	@pIdProfile
				,	@pIdClassEBD
			 );

			SELECT 1;
		END
		ELSE
		BEGIN
			SELECT 0;
		END
		
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END; 
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------PRONTO--------------------------------------------------------------------------------------------------
---------------VERIFICAR COMO DELETAR SUAS ASSOCIAÇÕES-----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteUser 
		@pIdUser TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	[User]
		WHERE	IdUser = @pIdUser;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END; 
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------VERIFICAR--------------------------------------------------------------------------------------------------
---------------COMO ATUALIZAREMOS O USUARIO?-----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdateUser
		@pIdUser			TINYINT
	,	@pFirstNameUser     VARCHAR(25)
	,	@pLastNameUser		VARCHAR(75)
	,	@pDateBirthUser		DATETIME
	,	@pIdProfile			TINYINT
	,	@pIdClassEBD		TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	[User]
		   SET	FirstNameUser	=	@pFirstNameUser
		   ,	LastNameUser	=	@pLastNameUser
		   ,	DateBirthUser	=	@pDateBirthUser
		   ,	IdProfile		=	@pIdProfile
		   ,	IdClassEBD		=	@pIdClassEBD
		 WHERE	IdUser			=	@pIdUser;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END; 
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-------------VERIFICAR-------------------------------------------------------------------------------------------------
-----------------COMO SELECIONAR O USUARIO?---------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectUserById
	@pIdUser	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	U.IdUser
			,	U.FirstNameUser
			,	U.LastNameUser
			,	U.DateBirthUser
			,	U.LoginUser
			,	U.IdProfile
			,	P.NameProfile
			,	U.IdClassEBD
			,	C.NameClassEBD
		  FROM [User] U
		  INNER JOIN [Profile] P ON P.IdProfile = U.IdProfile
		  INNER JOIN ClassEBD C ON C.IdClassEBD = U.IdClassEBD
		 WHERE IdUser	=	@pIdUser;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END;
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-------------VERIFICAR-------------------------------------------------------------------------------------------------
-----------------COMO SELECIONAR O USUARIO?---------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectUser
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	U.IdUser
			,	U.FirstNameUser
			,	U.LastNameUser
			,	U.DateBirthUser
			,	U.LoginUser
			,	U.IdProfile
			,	P.NameProfile
			,	U.IdClassEBD
			,	C.NameClassEBD
		  FROM [User] U
		  INNER JOIN [Profile] P ON P.IdProfile = U.IdProfile
		  INNER JOIN ClassEBD C ON C.IdClassEBD = U.IdClassEBD;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END;
GO