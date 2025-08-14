CREATE DATABASE TestTaskShortener

USE TestTaskShortener

--user
CREATE TABLE Users(
UserId INT IDENTITY PRIMARY KEY,
UserName VARCHAR(50) NOT NULL Unique,
UserPassword Varchar(50) NOT NULL,
Token Varchar(50)
RoleId INT FOREIGN KEY REFERENCES Roles(RoleId) NOT NULL
)

CREATE TABLE Roles (
    RoleId INT IDENTITY PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE
);

--
CREATE TABLE ShortUrl(
 ShortUrlId INT IDENTITY PRIMARY KEY,
 CreatedBy INT FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
 CreatedDate DATETIME,
 MainUrl Varchar(100) NOT NULL UNIQUE,
 ShortUrl Varchar(100) NOT NULL UNIQUE,
)

CREATE TABLE AboutDescriptionTable(
AboutId INT IDENTITY PRIMARY KEY,
AboutDescriptionNew Varchar(150),
AboutDescriptionOld Varchar(150)
)