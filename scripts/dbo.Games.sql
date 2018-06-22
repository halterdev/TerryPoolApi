CREATE TABLE [dbo].[Games] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [AwayTeamId] INT NOT NULL,
    [HomeTeamId] INT NOT NULL,
    [WeekId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Games_Weeks] FOREIGN KEY ([WeekId]) REFERENCES [dbo].[Weeks] ([Id]),
    CONSTRAINT [FK_Games_Teams_Away] FOREIGN KEY ([AwayTeamId]) REFERENCES [dbo].[Teams] ([Id]),
    CONSTRAINT [FK_Games_Teams_Home] FOREIGN KEY ([HomeTeamId]) REFERENCES [dbo].[Teams] ([Id])
);

