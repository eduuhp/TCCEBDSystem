--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------VERIFICAR--------------------------------------------------------------------------------------------------
----------------ASSOCIAÇÃO DA NOTICIA COM 1 OU MAIS DEPARTAMENTOS----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE NOTICE--

CREATE PROCEDURE spInsertDepartmentNotice
		@pIdNotice		TINYINT
	,	@pIdDepartment	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT

	BEGIN TRY
		INSERT
		  INTO DepartmentNotice
			(
				IdDepartment
			,	IdNotice
			)
		VALUES 
			(
				@pIdDepartment
			,	@pIdNotice
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
-------------VERIFICAR-------------------------------------------------------------------------------------------------
------------------DELETAR A NOTICIA E SUAS ASSOCIAÇÕES--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spDeleteDepartmentNotice
	@pIdNotice	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	DepartmentNotice
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
------------VERIFICAR--------------------------------------------------------------------------------------------------
----------------COMO ATUALIZAR OS DEPARTAMENTOS VINCULADOS A NOTICIA----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spUpdateDepartmentNotice
		@pIdNotice		TINYINT
	,	@pIdDepartment	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	DepartmentNotice
	 	SET		IdDepartment = @pIdDepartment
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
------------VERIFICAR--------------------------------------------------------------------------------------------------
----------------COMO MOSTRAR SE TIVER MAIS DE 1 DEPARTAMENTO VINCULADO----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectDepartmentNoticeForNotice
		@pIdNotice	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT		DN.IdDepartment
			,		D.NameDepartment
		FROM		DepartmentNotice DN
		INNER JOIN	Department D ON  DN.IdDepartment = D.IdDepartment
		WHERE		DN.IdNotice = @pIdNotice
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
------------VERIFICAR--------------------------------------------------------------------------------------------------
----------------COMO MOSTRAR SE TIVER MAIS DE 1 DEPARTAMENTO VINCULADO----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectDepartmentNoticeForDepartment
		@pIdDepartment	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT		DN.IdNotice
			,		N.TitleNotice
		FROM		DepartmentNotice DN
		INNER JOIN	Notice N ON  DN.IdNotice = N.IdNotice
		WHERE		DN.IdDepartment = @pIdDepartment
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO