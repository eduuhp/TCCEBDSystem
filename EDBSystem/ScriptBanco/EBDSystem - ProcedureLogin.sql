--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-----------------VERIFICAR---------------------------------------------------------------------------------------------
---------------------FAZER VERIFICAÇÃO EM 2 ETAPAS-----------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE LOGIN--

CREATE PROCEDURE spConfirmLogin
			@pLoginUser		VARCHAR(25)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	DECLARE		@ErrorMessage		VARCHAR(2000)
			,	@ErrorState			TINYINT
			,	@ErrorSeverity		TINYINT
		
	BEGIN	TRY
		IF EXISTS (SELECT * FROM [User] WHERE LoginUser = @pLoginUser)
		BEGIN
			SELECT idUser FROM [User] WHERE LoginUser = @pLoginUser
		END
		ELSE
		BEGIN
			RETURN 0
		END				
	END		TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE();
		SET @ErrorState	=	ERROR_STATE();
		SET @ErrorSeverity = ERROR_SEVERITY();
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorSeverity)
	END CATCH
END;
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-----------------VERIFICAR---------------------------------------------------------------------------------------------
---------------------FAZER VERIFICAÇÃO EM 2 ETAPAS-----------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE LOGIN--

CREATE PROCEDURE spConfirmPassword
			@pIdUser		TINYINT
		,	@pPasswordUser	VARCHAR(25)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	DECLARE		@ErrorMessage		VARCHAR(2000)
			,	@ErrorState			TINYINT
			,	@ErrorSeverity		TINYINT
		
	BEGIN	TRY
		SELECT	IdUser
		,		FirstNameUser
		,		LastNameUser
		,		IdProfile
		,		IdClassEBD
		FROM	[User]
		WHERE	IdUser = @pIdUser AND PasswordUser = @pPasswordUser;
	END		TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE();
		SET @ErrorState	=	ERROR_STATE();
		SET @ErrorSeverity = ERROR_SEVERITY();
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorSeverity)
	END CATCH
END;
GO