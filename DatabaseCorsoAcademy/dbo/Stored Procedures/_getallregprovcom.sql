-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE _getallregprovcom
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	reg.[ID] AS [ID Regione]
	,reg.[NOME] AS [Regione]
	,reg.[isAutonoma]
	,reg.[NumAbitanti] AS [Abitanti Regione]
	,prov.ID AS [ID Provincia]
	,prov.isCapoluogo 
	,prov.Nome AS [Provincia]
	,prov.NumAbitanti AS [Abitanti Provincia]
	,com.ID AS [ID Comune]
	,com.Nome AS [Comune]
	,com.NumAbitanti AS [Abitanti Comune]
	FROM [dbo].[T_Regione] AS reg
	INNER JOIN [dbo].[T_Provincia] AS prov ON reg.id = prov.IdRegione
	INNER JOIN [dbo].[T_Comune] AS com ON prov.id = com.IdProvincia
END
