--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
------------VERIFICAR--------------------------------------------------------------------------------------------------
----------------ASSOCIAÇÃO DA NOTICIA COM 1 OU MAIS DEPARTAMENTOS----------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

--PROCEDURE NOTICE--

CREATE PROCEDURE spInsertProfileRestriction
		@pIdProfile		TINYINT
	,	@pIdRestriction	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		,	@ErrorSeverity  TINYINT
		,	@ErrorState     TINYINT

	BEGIN TRY
		INSERT
		  INTO ProfileRestriction
			(
				IdProfile
			,	IdRestriction
			)
		VALUES 
			(
				@pIdProfile
			,	@pIdRestriction
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

CREATE PROCEDURE spDeleteProfileRestriction
	@pIdProfile	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		DELETE
		FROM	ProfileRestriction
		WHERE	IdProfile = @pIdProfile;
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

CREATE PROCEDURE spInsertProfileRestriction
		@pIdProfile		TINYINT
	,	@pIdRestriction	TINYINT
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		UPDATE	ProfileRestriction
	 	SET		IdRestriction = @pIdRestriction
		WHERE	IdProfile = @pIdProfile;
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

CREATE PROCEDURE spSelectProfileRestrictionForProfile
		@pIdProfile	TINYINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT

	BEGIN TRY
		SELECT		PR.IdRestriction
			,		R.NameRestriction
		FROM		ProfileRestriction PR
		INNER JOIN	Restriction R ON  PR.IdRestriction = R.IdRestriction
		WHERE		PR.IdProfile = @pIdProfile
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO