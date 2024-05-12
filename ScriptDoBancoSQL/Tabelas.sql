CREATE TABLE CD (
	Id bigint not null identity(1,1),
	Titulo varchar(40) not null,
	ArtistaId bigint not null,
	GeneroMusicalId bigint not null
)
go
CREATE TABLE Artista (
	Id bigint not null identity(1,1),
	Nome varchar(40) not null
)
go
CREATE TABLE GeneroMusical (
	Id bigint not null identity(1,1),
	Nome varchar(40) not null
)
go
alter table CD
add constraint CD_Id_PK primary key ( Id )
go
alter table GeneroMusical
add constraint GeneroMusical_Id_PK primary key ( Id )
go
alter table CD
add constraint CD_GeneroMusical_FK FOREIGN KEY ( GeneroMusicalId ) references GeneroMusical(Id)
go
alter table Artista
add constraint Artista_Id_PK primary key ( Id )
go
alter table CD
add constraint CD_Artista_FK FOREIGN KEY ( ArtistaId ) references Artista(Id)
go
CREATE TABLE Musicas (
	Id bigint not null identity(1,1),
	CDId bigint not null,
	Nome varchar(40) not null,
	Tempo bigint not null,
)
go
alter table Musicas
add constraint Musicas_Id_PK primary key ( Id )
go
alter table Musicas
add constraint Musicas_CD_FK FOREIGN KEY ( CDId ) references CD(Id)
go
alter table CD
add constraint CD_Artista_FK FOREIGN KEY ( ArtistaId ) references Artista(Id)
go
INSERT INTO Artista ( Nome ) VALUES ( 'Artista1' )
go
INSERT INTO Artista ( Nome ) VALUES ( 'Artista2' )
go
INSERT INTO GeneroMusical ( Nome ) VALUES ( 'GeneroMusical1' )
go
INSERT INTO GeneroMusical( Nome ) VALUES ( 'GeneroMusical2' )
go
INSERT INTO CD (Titulo, ArtistaId, GeneroMusicalId)
VALUES('CD1', 1, 1)
GO
INSERT INTO Musicas(CDId, Nome, Tempo)
VALUES(1, 'Musica1', 5)
GO
INSERT INTO Musicas(CDId, Nome, Tempo)
VALUES(1, 'Musica2', 3)
GO


	
