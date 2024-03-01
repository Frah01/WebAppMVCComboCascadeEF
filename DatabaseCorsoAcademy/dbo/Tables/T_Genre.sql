CREATE TABLE [dbo].[T_Genre] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Genere]  NVARCHAR (100) NULL,
    [isAdult] BIT            NULL,
    CONSTRAINT [PK_T_Genre] PRIMARY KEY CLUSTERED ([ID] ASC)
);

