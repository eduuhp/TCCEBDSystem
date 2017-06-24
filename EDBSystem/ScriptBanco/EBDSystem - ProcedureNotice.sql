--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------Pronto--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE NOTICE--

CREATE PROCEDURE spInsertNotice
		@pTitleNotice		VARCHAR(50)
	,	@pContentNotice		VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT

	BEGIN TRY
		INSERT
		  INTO Notice
			(
				TitleNotice
			,	ContentNotice
			)
			OUTPUT inserted.IdNotice
		VALUES 
			(
				@pTitleNotice
			,	@pContentNotice
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
------------Pronto--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteNotice
	@pIdNotice	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	Notice
		WHERE	IdNotice = @pIdNotice;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------Pronto--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdateNotice
		@pIdNotice		TINYINT
	,	@pTitleNotice	VARCHAR(50)
	,	@pContentNotice	VARCHAR(200)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	Notice
	 	SET		TitleNotice = @pTitleNotice
			,	ContentNotice = @pContentNotice
		WHERE	IdNotice = @pIdNotice;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------Pronto--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectNotice
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	*
		FROM	Notice
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------Pronto--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectNoticeById
	@pIdNotice	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	*
		FROM	Notice 
		WHERE	IdNotice = @pIdNotice;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO