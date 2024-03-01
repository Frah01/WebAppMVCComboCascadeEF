-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE del_doppioni_Table_1 
	-- Add the parameters for the stored procedure here
	@Nome nvarchar(50),
	@Cognome nvarchar(100),
	@idDaTenere uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SELECT ID, Nome, Cognome FROM Table_1
	-- STEP 1 visualizzo tutti i Patrizio	Rossi
	-- SELECT ID, Nome, Cognome FROM Table_1 WHERE Nome = @Nome  AND Cognome = @Cognome
 
	-- STEP 2 Scelto un Patrizio	Rossi da tenere
	-- DECLARE @idDaTenere uniqueidentifier
	-- SET @idDaTenere = 'AEC0FD28-7D1D-4524-9ABF-7A0821259656'
 
	-- SELECT TOP 1 @idDaTenere = ID FROM Table_1 WHERE Nome = @Nome  AND Cognome = @Cognome 
	--print @idDaTenere
	-- 55D3C852-D5E7-45E6-90DF-087A3CC2BD0F
 
	-- STEP 3 elimino gli altri Patrizio	Rossi (doppioni)
		DELETE FROM Table_1 WHERE Nome = @Nome  AND Cognome = @Cognome  AND ID != @idDaTenere
 
	-- STEP 4 Ciclo per eliminare gli altri utenti doppioni
	-- SELECT DISTINCT Nome, Cognome FROM Table_1
END
