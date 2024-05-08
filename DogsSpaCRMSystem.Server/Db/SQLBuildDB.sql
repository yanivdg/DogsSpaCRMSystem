-- Check if the database exists  
IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = 'DogsBarberShopManagmentDB')
BEGIN
  -- Create the database if it doesn't exist
  CREATE DATABASE DogsBarberShopManagmentDB;
END;

USE DogsBarberShopManagmentDB;

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
	BEGIN
		DROP TABLE Users;
	END;
ELSE
	CREATE TABLE Users (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		Username VARCHAR(50) NOT NULL UNIQUE,
		PasswordHash CHAR(64) NOT NULL,
		FirstName VARCHAR(50) NOT NULL
		);

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Appointments')
	BEGIN
		DROP TABLE Appointments;
	END;
ELSE
	CREATE TABLE Appointments (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		UserId INT FOREIGN KEY REFERENCES Users(Id),
		ArrivalTime DATETIME NOT NULL,
		CreatedAt DATETIME DEFAULT GETUTCDATE() NOT NULL
		);
