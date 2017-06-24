--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
----------PRONTO----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE CLASS EBD--

CREATE PROCEDURE spInsertClassEBD
		@pNameClassEBD	VARCHAR(50)
	,	@pIdPeriod		TINYINT
	,	@pIdDepartment	TINYINT	
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		INSERT
		INTO	ClassEBD
			(
				NameClassEBD
			,	IdPeriod
			,	IdDepartment
			)
		VALUES 
			(
				@pNameClassEBD
			,	@pIdPeriod
			,	@pIdDepartment
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
-------------VERIFICAR AS DEPENDENCIAS-------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteClassEBD
	@pIdClassEBD	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	ClassEBD
		WHERE	IdClassEBD = @pIdClassEBD;
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

CREATE PROCEDURE spUpdateClassEBD	
		@pIdClassEBD	TINYINT
	,	@pNameClassEBD	VARCHAR(50)
	,	@pIdPeriod		TINYINT
	,	@pIdDepartment	TINYINT	

AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	ClassEBD
		   SET	NameClassEBD = @pNameClassEBD
		   ,	IdPeriod = @pIdPeriod
		   ,	IdDepartment = @pIdDepartment
		 WHERE	IdClassEBD	=	@pIdClassEBD;
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

CREATE PROCEDURE spSelectClassEBD
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	C.IdClassEBD, C.NameClassEBD, C.IdPeriod, P.NamePeriod, C.IdDepartment, D.NameDepartment
		FROM	ClassEBD C
		INNER JOIN	[Period] P ON P.IdPeriod = C.IdPeriod
		INNER JOIN	Department D ON D.IdDepartment = C.IdDepartment
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

CREATE PROCEDURE spSelectClassEBDById
	@pIdClassEBD	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT	C.IdClassEBD, C.NameClassEBD, C.IdPeriod, P.NamePeriod, C.IdDepartment, D.NameDepartment
		FROM	ClassEBD C
		INNER JOIN	[Period] P ON P.IdPeriod = C.IdPeriod
		INNER JOIN	Department D ON D.IdDepartment = C.IdDepartment
		WHERE C.IdClassEBD = @pIdClassEBD
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO