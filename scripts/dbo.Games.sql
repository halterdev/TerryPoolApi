CREATE TABLE [dbo].[Games]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SeasonId] INT NOT NULL, 
    [AwayTeamId] INT NOT NULL, 
    [HomeTeamId] INT NOT NULL, 
    [Week] INT NOT NULL, 
    CONSTRAINT [FK_Games_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [Seasons]([Id]),
	CONSTRAINT [FK_Games_Teams_Away] FOREIGN KEY ([AwayTeamId]) REFERENCES [Teams]([Id]),
	CONSTRAINT [FK_Games_Teams_Home] FOREIGN KEY ([HomeTeamId]) REFERENCES [Teams]([Id])
)
