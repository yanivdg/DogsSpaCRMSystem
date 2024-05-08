USE DogsBarberShopManagmentDB;
GO

IF OBJECT_ID('GetUserForValidation', 'P') IS NOT NULL
    DROP PROCEDURE GetUserForValidation;
GO

CREATE PROCEDURE GetUserForValidation 
    @username NVARCHAR(50), 
    @passwordHash NVARCHAR(MAX)
AS
BEGIN
    -- Find all users with the matching username and password hash
    SELECT Id, Username, PasswordHash
    FROM Users
    WHERE Username = @username
      AND PasswordHash = @passwordHash;
END;
