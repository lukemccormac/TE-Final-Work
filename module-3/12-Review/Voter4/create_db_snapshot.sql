USE master;
CREATE DATABASE voter_Snapshot ON
( 
    NAME = 'voter', 
    FILENAME = 'C:\Snapshots\voter_Snapshot.ss' 
)
AS SNAPSHOT OF [voter];

