CREATE TABLE [dbo].[T_Provincia] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (50) NULL,
    [idRegione]   INT           NULL,
    [NumAbitanti] INT           NULL,
    [isCapoluogo] BIT           NULL,
    CONSTRAINT [PK_T_Provincia] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Provincia_T_Regione] FOREIGN KEY ([idRegione]) REFERENCES [dbo].[T_Regione] ([ID])
);

