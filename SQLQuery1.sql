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
GO

-- CREATE --

CREATE PROCEDURE CreateTag
@topic nvarchar(50),
@descrip nvarchar(300)
AS
INSERT INTO Tag (Topic,[Description]) 
OUTPUT inserted.Id
VALUES (@topic,@descrip);
GO

CREATE PROCEDURE CreateUser
@fornavn nvarchar(50),
@efternavn nvarchar(50)
AS
INSERT INTO [User] (ForNavn,EfterNavn) 
OUTPUT inserted.Id
VALUES (@fornavn,@efternavn);
GO

CREATE PROCEDURE CreateAuther
@userId int
AS
INSERT INTO Forfatter (UserId)
OUTPUT inserted.Id
VALUES (@userId);
GO
CREATE PROCEDURE CreatePost
@title nvarchar(150),
@content nvarchar(MAX),
@autherId int
AS
INSERT INTO Post(Title,Content,AutherId)
OUTPUT inserted.Id
VALUES(@title,@content,@autherId)
GO

CREATE PROCEDURE CreateFiles
@postId int,
@fileLocation nvarchar(300)
AS
INSERT INTO Files(PostId,FileLocation)
OUTPUT inserted.Id
VALUES(@postId,@fileLocation)
GO

CREATE PROCEDURE CreateLinks
@postId int,
@link nvarchar(500)
AS
INSERT INTO Links(PostId,Link)
OUTPUT inserted.Id
VALUES(@postId,@link)
GO

CREATE PROCEDURE CreateTagCloud
@tagId int,
@postId int
AS
INSERT INTO TagCloud(TagId,PostId)
VALUES(@tagId,@postId)
GO

-- GET --

CREATE PROCEDURE GetAllPosts
AS
SELECT Post.Id AS PostId,Post.Title,Post.Content,Post.AutherId,[User].Id AS UserId,ForNavn,EfterNavn
FROM Post
INNER JOIN Forfatter ON Post.AutherId = Forfatter.Id
INNER JOIN [User] ON Forfatter.UserId = [User].Id;
GO

CREATE PROCEDURE GetTags
@postId int
AS
SELECT Tag.Id AS TagId,Tag.Topic,Tag.Description
FROM TagCloud
INNER JOIN Tag ON TagCloud.TagId = Tag.Id
WHERE TagCloud.PostId = @postId;
GO

CREATE PROCEDURE GetFiles
@postId int
AS
SELECT *
FROM Files
WHERE Files.PostId = @postId;
GO

CREATE PROCEDURE GetLinks
@postId int
AS
SELECT *
FROM Links
WHERE Links.PostId = @postId;
GO