CREATE TABLE [dbo].[Shows]
(
    [ShowMovieID] INT NOT NULL, 
    [ShowTheatreID] INT NOT NULL, 
    [MovieTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_Shows_Movies] FOREIGN KEY ([ShowMovieID]) REFERENCES [Movies]([MovieID]), 
    CONSTRAINT [FK_Shows_Theatres] FOREIGN KEY ([ShowTheatreID]) REFERENCES [Theatres]([TheatreID]) 
)
