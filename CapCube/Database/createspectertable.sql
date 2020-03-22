DROP TABLE IF EXISTS Specter 

CREATE TABLE Specter (
	SpecterID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
	HP int,
	PP int,
	Attack int,
	Defense int,
	SpAtk int,
	SpDef int,
	Speed int,
	Element1ID int,
	Element2ID int
)

DROP TABLE IF EXISTS Element 

CREATE TABLE Element (
	ElementID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255)
)