CREATE TABLE [dbo].[Users] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Email] VARCHAR (100) NOT NULL,
    [Password] VARCHAR(MAX) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

