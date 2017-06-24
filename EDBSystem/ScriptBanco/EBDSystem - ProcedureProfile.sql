--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-----------PRONTO---------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE PROFILE--

CREATE PROCEDURE spInsertProfile
	@pNameProfile	VARCHAR(25)
AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		INSERT
		  INTO [Profile]
			 (
					NameProfile
			 )
			 OUTPUT inserted.IdProfile
	  VALUES (
					@pNameProfile
			 )
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
-----------PRONTO---------------------------------------------------------------------------------------------------
--------------COMO RETIRAR SUAS ASSOCIAÇÕES------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteProfile 
	@pIdProfile TINYINT
AS
BEGIN
		SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		DELETE
		  FROM [Profile]
		 WHERE IdProfile = @pIdProfile;
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
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdateProfile
		@pIdProfile		TINYINT
	,	@pNameProfile	VARCHAR(25)
AS
BEGIN
		SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		UPDATE	[Profile]
		   SET	NameProfile	=	@pNameProfile
		 WHERE	IdProfile	=	@pIdProfile;
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
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectProfile
AS
BEGIN
		SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		SELECT	*
		FROM	[Profile];
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
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectProfileById
		@pIdProfile		TINYINT
AS
BEGIN
		SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		SELECT	*
		FROM	[Profile]
		WHERE	IdProfile = @pIdProfile;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END; 
GO