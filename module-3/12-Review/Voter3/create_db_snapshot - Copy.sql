/* Create a database snapshot */

USE master;
CREATE DATABASE Your_Database_Snapshot ON
( 
    NAME = voter, 
    FILENAME = 'C:\Snapshots\Your_Database_Snapshot.ss' 
)
AS SNAPSHOT OF Your_Database;
GO
