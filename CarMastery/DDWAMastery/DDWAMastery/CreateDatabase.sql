USE master
IF EXISTS(select * from sys.databases where name='GuildCars')
DROP DATABASE GuildCars

CREATE DATABASE GuildCars