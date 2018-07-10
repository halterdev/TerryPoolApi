CREATE TABLE [dbo].[GameResults]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GameId] INT NOT NULL, 
    [AwayScore] INT NOT NULL, 
    [HomeScore] INT NOT NULL, 
    CONSTRAINT [FK_GameResults_Games] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id])
)
