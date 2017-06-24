
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
-----------PRONTO---------------------------------------------------------------------------------------------------
-------------FAZER NA MÃO POIS VAI COM O SCRIPT-------------------------------------------------------------------------------------------------
--------------SERA FIXO DO BANCO------------------------------------------------------------------------------------------------

CREATE PROCEDURE spSelectRestriction
AS
BEGIN
		SET NOCOUNT ON;
		DECLARE @ErrorMessage   VARCHAR(2000)
		  , @ErrorSeverity  TINYINT
		  , @ErrorState     TINYINT
		BEGIN TRY
		SELECT	*
		FROM	Restriction;
	END TRY
	BEGIN CATCH
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState    = ERROR_STATE()
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END; 
GO