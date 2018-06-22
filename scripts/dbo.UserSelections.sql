CREATE TABLE [dbo].[UserSelections]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [TeamId] INT NOT NULL, 
    [WeekId] INT NOT NULL, 
    CONSTRAINT [FK_UserSelections_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_UserSelections_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id]),
	CONSTRAINT [FK_UserSelections_Weeks] FOREIGN KEY ([WeekId]) REFERENCES [Weeks]([Id])
)
