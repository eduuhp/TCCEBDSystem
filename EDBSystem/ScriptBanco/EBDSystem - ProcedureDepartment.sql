--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------PRONTO--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE DEPARTMENT--

CREATE PROCEDURE spInsertDepartment
		@pNameDepartment		VARCHAR(50)
	,	@pDescriptionDepartment	VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE	@ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT
	BEGIN TRY
	INSERT
	INTO Department
		(
			NameDepartment
		,	DescriptionDepartment
		)
	  VALUES
	  	(
			@pNameDepartment
		,	@pDescriptionDepartment
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

CREATE PROCEDURE spDeleteDepartment
	@pIdDepartment TINYINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE	@ErrorMessage   VARCHAR(2000)
	  ,		@ErrorSeverity  TINYINT
	  ,		@ErrorState     TINYINT
	BEGIN TRY
		DELETE
		FROM	Department
		WHERE	IdDepartment = @pIdDepartment;
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
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdateDepartment
		@pIdDepartment			TINYINT
	,	@pNameDepartment		VARCHAR(50)
	,	@pDescriptionDepartment	VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE	@ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT
	BEGIN TRY
		UPDATE	Department
		SET		NameDepartment = @pNameDepartment
			,	DescriptionDepartment = @pDescriptionDepartment	
		WHERE	IdDepartment = @pIdDepartment;
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
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectDepartment
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT
	BEGIN TRY
		SELECT	*
		FROM	Department;
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
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectDepartmentById
	@pIdDepartment	TINYINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT
	BEGIN TRY
		SELECT	*
		FROM	Department
		WHERE	IdDepartment = @pIdDepartment;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END;
GO