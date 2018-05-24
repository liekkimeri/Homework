USE homework
CREATE TABLE dbo.Planet(
	ID int IDENTITY(1,1) NOT NULL,
	Name varchar(255) NOT NULL,
	PRIMARY KEY  (ID) )

CREATE TABLE dbo.Species(
	ID int IDENTITY(1,1) NOT NULL,
	Name varchar(255) NOT NULL,
	Planet_ID int NULL,
    PRIMARY KEY (ID),
	FOREIGN KEY (Planet_ID) REFERENCES Planet)
