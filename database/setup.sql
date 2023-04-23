CREATE LOGIN fitburger_webapp WITH PASSWORD = 'LIA?h6-UqkC/#o['
GO

CREATE USER fitburger_webapp FOR LOGIN fitburger_webapp
EXEC sp_addrolemember N'db_owner', N'fitburger_webapp'
GO

ALTER SERVER ROLE  dbcreator ADD MEMBER fitburger_webapp;
GO