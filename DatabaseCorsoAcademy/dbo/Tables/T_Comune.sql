CREATE TABLE [dbo].[T_Comune] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (100) NULL,
    [IdProvincia] INT            NULL,
    [NumAbitanti] INT            NULL,
    CONSTRAINT [PK_T_Comune] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Comune_T_Provincia] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[T_Provincia] ([ID])
);

