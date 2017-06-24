--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
---------PRONTO-----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE FREQUENCY--

CREATE PROCEDURE spInsertFrequency
	@pDateFrequency	DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		INSERT
		INTO	Frequency
			(
				DateFrequency
			)
		VALUES 
			(
				@pDateFrequency
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
--------PRONTO------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteFrequency
	@pIdFrequency	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	Frequency
		WHERE	IdFrequency = @pIdFrequency;
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

CREATE PROCEDURE spUpdateFrequency	
		@pIdFrequency	TINYINT
	,	@pDateFrequency	DATETIME

AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	Frequency
		SET		DateFrequency = @pDateFrequency
		WHERE	IdFrequency = @pIdFrequency;
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
---------PRONTO-----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectFrequency
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	*
		FROM	Frequency;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO