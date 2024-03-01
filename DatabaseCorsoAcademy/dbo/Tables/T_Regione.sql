CREATE TABLE [dbo].[T_Regione] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (50) NULL,
    [isAutonoma]  BIT           NULL,
    [NumAbitanti] INT           NULL,
    CONSTRAINT [PK_T_Regione] PRIMARY KEY CLUSTERED ([ID] ASC)
);

