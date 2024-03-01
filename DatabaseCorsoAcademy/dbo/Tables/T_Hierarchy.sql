CREATE TABLE [dbo].[T_Hierarchy] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [IdMgr]           INT            NULL,
    [Nome]            NVARCHAR (100) NULL,
    [Cognome]         NVARCHAR (100) NULL,
    [TitoloAziendale] NVARCHAR (100) NULL,
    [Livello]         NVARCHAR (100) NULL,
    CONSTRAINT [PK_T_Gerarchy] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_T_Gerarchy_T_Gerarchy] FOREIGN KEY ([IdMgr]) REFERENCES [dbo].[T_Hierarchy] ([Id])
);

