CREATE TABLE [dbo].[T_Spinoff] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Spinoff]     NVARCHAR (100) NULL,
    [Data]        DATE           NULL,
    [isCanonical] BIT            NULL,
    [idMovie]     INT            NULL,
    CONSTRAINT [PK_T_Spinoff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Spinoff_T_Movie] FOREIGN KEY ([idMovie]) REFERENCES [dbo].[T_Movie] ([ID])
);

