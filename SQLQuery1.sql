USE MASTER;
GO
DROP DATABASE IF EXISTS devBlog;
GO
CREATE DATABASE devBlog;
GO
USE devBLog;
GO
CREATE TABLE Tag (Id int,Name nvarchar(50));
CREATE TABLE TagCloud(TagId int, PostId int);
CREATE TABLE Post (ID int, Title nvarchar(150),Content nvarchar(MAX),AutherId int);
CREATE TABLE Links (Id int,PostId int,Link nvarchar(500));
CREATE TABLE Files (Id int,PostId int, FileLocation nvarchar(300));
