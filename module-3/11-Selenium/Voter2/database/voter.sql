USE master;
GO

DROP DATABASE IF EXISTS [voter];
GO

CREATE DATABASE [voter];
GO

USE [voter];
GO

DROP TABLE IF EXISTS users;

CREATE TABLE users (
  id INT IDENTITY PRIMARY KEY,
  username VARCHAR(255) NOT NULL UNIQUE, -- Username
  password VARCHAR(48) NOT NULL, -- Password (in plain-text)
  salt VARCHAR(256) NOT NULL,  -- Password Salt
  role INT NOT NULL -- 0 for user, 1 for admin
);

GO
