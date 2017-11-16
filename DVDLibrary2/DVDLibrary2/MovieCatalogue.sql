USE master
GO
if exists(SELECT * From sysdatabases where name = 'MovieCatalogue')
			drop database MovieCatalogue
CREATE DATABASE MovieCatalogue;

USE MovieCatalogue
GO

CREATE TABLE "Genre" (
	"GenreID" int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	"GenreName" nvarchar(30) NOT NULL,
	);

CREATE TABLE "Director"(
	"DirectorID" int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	"FirstName" nvarchar(30) NOT NULL,
	"LastName" nvarchar(30) NOT NULL,
	"BirthDate" nvarchar(20)
	);

CREATE TABLE "Rating"(
	"RatingID" int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	"RatingName" nvarchar(5) NOT NULL
	);

CREATE TABLE "Actor"(
	"ActorID" int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	"FirstName" nvarchar(30) NOT NULL,
	"LastName" nvarchar(30) NOT NULL,
	"BirthDate" nvarchar(30)
	);

CREATE TABLE "Movie" (
	"MovieID" int IDENTITY (1, 1) NOT NULL ,
	"GenreID" int FOREIGN KEY REFERENCES Genre(GenreID) NOT NULL , 
	"DirectorID" int FOREIGN KEY REFERENCES Director(DirectorID) ,
	"RatingID" int FOREIGN KEY REFERENCES Rating(RatingID) ,
	"Title" nvarchar (128) NOT NULL,
	"Release Date" nvarchar (20) ,
	PRIMARY KEY (MovieID),
	);

CREATE TABLE "CastMembers"(
	"CastMemberID" int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	"ActorID" int FOREIGN KEY REFERENCES Actor(ActorID)  NOT NULL,
	"MovieID" int FOREIGN KEY REFERENCES Movie(MovieID) NOT NULL,
	"Role" nvarchar(50) NOT NULL
	);


