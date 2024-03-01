-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE _getMovieGenre
	-- Add the parameters for the stored procedure here
	@MovieName AS nvarchar(100)
AS
BEGIN
	DECLARE @genID AS int
	SELECT @genID = ID FROM [dbo].[T_Movie] WHERE Film = @MovieName
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	
	gen.[ID] AS [ID Genere]
	,gen.[Genere] AS [Genere]
	,gen.[isAdult]
	,mov.ID AS [ID Provincia]
	,mov.Film AS [Nome Film]
	,mov.Data AS [Data]
	,mov.idGenre AS [Genere Appartenenza]
	FROM [dbo].[T_Movie] AS mov
	INNER JOIN [dbo].[T_Genre] AS gen ON mov.idGenre = gen.ID AND gen.ID = @genID

END
