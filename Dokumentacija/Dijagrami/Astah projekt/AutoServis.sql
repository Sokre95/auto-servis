CREATE TABLE Korisnik (
 id_Korisnik INT NOT NULL,
 eMail VARCHAR(30) NOT NULL,
 lozinka VARCHAR(30) NOT NULL,
 ime VARCHAR(30),
 prezime VARCHAR(30),
 brTel CHAR(20)
);

ALTER TABLE Korisnik ADD CONSTRAINT PK_Korisnik PRIMARY KEY (id_Korisnik);


CREATE TABLE Serviser (
 id_Serviser INT NOT NULL,
 eMail VARCHAR(30),
 lozinka VARCHAR(30) NOT NULL,
 ime VARCHAR(30),
 prezime VARCHAR(30),
 brTel CHAR(20)
);

ALTER TABLE Serviser ADD CONSTRAINT PK_Serviser PRIMARY KEY (id_Serviser);


CREATE TABLE Usluga (
 id_Usluga INT NOT NULL,
 opis VARCHAR(100)
);

ALTER TABLE Usluga ADD CONSTRAINT PK_Usluga PRIMARY KEY (id_Usluga);


CREATE TABLE Vozilo (
 id_Vozilo INT NOT NULL,
 tipVozila VARCHAR(50),
 godProizv DATE,
 regOznaka VARCHAR(10),
 id_Korisnik INT NOT NULL
);

ALTER TABLE Vozilo ADD CONSTRAINT PK_Vozilo PRIMARY KEY (id_Vozilo);


CREATE TABLE ZamjenskoVozilo (
 id_Zamjensko INT NOT NULL,
 regOznaka VARCHAR(10) NOT NULL,
 dostupno BIT NOT NULL
);

ALTER TABLE ZamjenskoVozilo ADD CONSTRAINT PK_ZamjenskoVozilo PRIMARY KEY (id_Zamjensko);


CREATE TABLE Popravak (
 id_Popravak INT NOT NULL,
 datumVrijeme DATE NOT NULL,
 id_Korisnik INT NOT NULL,
 id_Vozilo INT NOT NULL,
 id_Serviser INT NOT NULL,
 id_Zamjensko INT,
 dodatniOpis VARCHAR(500)
);

ALTER TABLE Popravak ADD CONSTRAINT PK_Popravak PRIMARY KEY (id_Popravak);


CREATE TABLE PopravakUsluga (
 id_Popravak INT NOT NULL,
 id_Usluga INT NOT NULL
);

ALTER TABLE PopravakUsluga ADD CONSTRAINT PK_PopravakUsluga PRIMARY KEY (id_Popravak,id_Usluga);


ALTER TABLE Vozilo ADD CONSTRAINT FK_Vozilo_0 FOREIGN KEY (id_Korisnik) REFERENCES Korisnik (id_Korisnik);


ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_0 FOREIGN KEY (id_Korisnik) REFERENCES Korisnik (id_Korisnik);
ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_1 FOREIGN KEY (id_Vozilo) REFERENCES Vozilo (id_Vozilo);
ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_2 FOREIGN KEY (id_Serviser) REFERENCES Serviser (id_Serviser);
ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_3 FOREIGN KEY (id_Zamjensko) REFERENCES ZamjenskoVozilo (id_Zamjensko);


ALTER TABLE PopravakUsluga ADD CONSTRAINT FK_PopravakUsluga_0 FOREIGN KEY (id_Popravak) REFERENCES Popravak (id_Popravak);
ALTER TABLE PopravakUsluga ADD CONSTRAINT FK_PopravakUsluga_1 FOREIGN KEY (id_Usluga) REFERENCES Usluga (id_Usluga);


