CREATE TABLE [dbo].[T_Movie] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Film]    NVARCHAR (100) NULL,
    [Data]    DATE           NULL,
    [isAdult] BIT            NULL,
    [idGenre] INT            NULL,
    CONSTRAINT [PK_T_Movie] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Movie_T_Genre] FOREIGN KEY ([idGenre]) REFERENCES [dbo].[T_Genre] ([ID])
);

