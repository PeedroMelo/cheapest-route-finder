CREATE DATABASE RouteFinder;

GO

USE RouteFinder;

GO

DROP TABLE IF EXISTS [Route]
CREATE TABLE [Route]
(
    Id INT NOT NULL IDENTITY(1,1),
    Origin CHAR(3) NOT NULL,
    Destiny CHAR(3) NOT NULL,
    Cost NUMERIC(18,2) NOT NULL,

    CONSTRAINT PK_Routes_Id             PRIMARY KEY CLUSTERED(Id),
    CONSTRAINT UQ_Routes_OriginDestiny  UNIQUE (Origin, Destiny)
)

GO

INSERT INTO [Route] (Origin, Destiny, Cost) VALUES
('GRU', 'BRC',  10),
('RBC', 'SCL',  5),
('GRU', 'CDG',  75),
('GRU', 'SCL',  20),
('GRU', 'ORL',  56),
('ORL', 'CDG',  5),
('SCL', 'ORL',  20)

GO