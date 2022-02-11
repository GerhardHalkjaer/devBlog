USE MASTER;
GO
DROP DATABASE IF EXISTS devBlog;
GO
CREATE DATABASE devBlog;
GO
USE devBLog;
GO
CREATE TABLE Tag (
Id int IDENTITY(1,1),
Topic nvarchar(50),
[Description] nvarchar(300),
PRIMARY KEY (Id)
);
CREATE TABLE [User] (
Id int IDENTITY(1,1),
ForNavn nvarchar(50),
EfterNavn nvarchar(50),
PRIMARY KEY (Id)
);
CREATE TABLE Forfatter (
Id int IDENTITY(1,1),
UserId int not null,
PostId int not null,
PRIMARY KEY (Id),
FOREIGN KEY (UserId) REFERENCES [User](Id)
);
CREATE TABLE Post (
Id int IDENTITY(1,1),
Title nvarchar(150),
Content nvarchar(MAX),
AutherId int,
PRIMARY KEY (Id),
FOREIGN KEY (AutherId) REFERENCES Forfatter(Id)
);
CREATE TABLE TagCloud (
TagId int not null,
PostId int not null
PRIMARY KEY(TagId,PostId),
FOREIGN KEY (TagId) REFERENCES Tag(Id),
FOREIGN KEY (PostId) REFERENCES Post(Id)
);
CREATE TABLE Links (
Id int IDENTITY(1,1),
PostId int not null,
Link nvarchar(500),
PRIMARY KEY (Id),
FOREIGN KEY (PostId) REFERENCES Post(Id)
);
CREATE TABLE Files (
Id int IDENTITY(1,1),
PostId int not null,
FileLocation nvarchar(300),
PRIMARY KEY (Id),
FOREIGN KEY (PostId) REFERENCES Post(Id)
);




