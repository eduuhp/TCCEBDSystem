--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE PERIOD--

CREATE PROCEDURE spInsertPeriod
		@pNamePeriod	VARCHAR(50)
	,	@pStartDate		DATETIME
	,	@pEndDate		DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		INSERT
		INTO	[Period]
			(
				NamePeriod
			,	StartDate
			,	EndDate
			)
		VALUES
			(
				@pNamePeriod
			,	@pStartDate
			,	@pEndDate
			)
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
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeletePeriod
	@pIdPeriod	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	[Period]
		WHERE	IdPeriod = @pIdPeriod;
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
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdatePeriod
		@pIdPeriod		TINYINT
	,	@pNamePeriod	VARCHAR(50)
	,	@pStartDate		DATETIME
	,	@pEndDate		DATETIME
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	[Period]
		SET		NamePeriod = @pNamePeriod
			 ,	StartDate = @pStartDate
			 ,	EndDate = @pEndDate
		WHERE	IdPeriod = @pIdPeriod;
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
------------PRONTO--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectPeriod
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	*
		FROM	[Period];
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
------------PRONTO--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectPeriodById
	@pIdPeriod TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	*
		FROM	[Period]
		WHERE	IdPeriod = @pIdPeriod;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO