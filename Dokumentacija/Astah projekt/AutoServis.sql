CREATE TABLE Administrator (
 id INT NOT NULL,
 email VARCHAR(10),
 ime CHAR(10),
 prezime VARCHAR(30),
 lozinka VARCHAR(30) NOT NULL,
 brTel CHAR(20)
);

ALTER TABLE Administrator ADD CONSTRAINT PK_Administrator PRIMARY KEY (id);


CREATE TABLE Korisnik (
 id INT NOT NULL,
 eMail VARCHAR(30) NOT NULL,
 ime VARCHAR(30),
 prezime VARCHAR(30),
 lozinka VARCHAR(30) NOT NULL,
 brTel CHAR(20)
);

ALTER TABLE Korisnik ADD CONSTRAINT PK_Korisnik PRIMARY KEY (id);


CREATE TABLE Serviser (
 id INT NOT NULL,
 eMail VARCHAR(30),
 lozinka VARCHAR(30) NOT NULL,
 ime VARCHAR(30),
 prezime VARCHAR(30),
 brTel CHAR(20)
);

ALTER TABLE Serviser ADD CONSTRAINT PK_Serviser PRIMARY KEY (id);


CREATE TABLE Usluga (
 id INT NOT NULL,
 opis VARCHAR(100)
);

ALTER TABLE Usluga ADD CONSTRAINT PK_Usluga PRIMARY KEY (id);


CREATE TABLE Vozilo (
 id INT NOT NULL,
 godProizv DATE,
 regOznaka VARCHAR(10),
 id_korisnik INT NOT NULL
);

ALTER TABLE Vozilo ADD CONSTRAINT PK_Vozilo PRIMARY KEY (id);


CREATE TABLE ZamjenskoVozilo (
 id INT NOT NULL,
 regOznaka VARCHAR(10) NOT NULL,
 dostupno BIT NOT NULL
);

ALTER TABLE ZamjenskoVozilo ADD CONSTRAINT PK_ZamjenskoVozilo PRIMARY KEY (id);


CREATE TABLE Popravak (
 id INT NOT NULL,
 datumVrijeme DATE NOT NULL,
 dodatniOpis VARCHAR(500),
 id_korisnik INT NOT NULL,
 id_Vozilo INT NOT NULL,
 id_serviser INT NOT NULL
);

ALTER TABLE Popravak ADD CONSTRAINT PK_Popravak PRIMARY KEY (id);


CREATE TABLE PopravakUsluga (
 id_popravak INT NOT NULL,
 id_usluga INT NOT NULL
);

ALTER TABLE PopravakUsluga ADD CONSTRAINT PK_PopravakUsluga PRIMARY KEY (id_popravak,id_usluga);


CREATE TABLE PopravakVozilo (
 id_zamj_vozilo INT NOT NULL,
 id_popravak INT NOT NULL
);

ALTER TABLE PopravakVozilo ADD CONSTRAINT PK_PopravakVozilo PRIMARY KEY (id_zamj_vozilo,id_popravak);


CREATE TABLE DodatnaUsluga (
 id INT NOT NULL,
 id_popravak INT NOT NULL,
 opis VARCHAR(500)
);

ALTER TABLE DodatnaUsluga ADD CONSTRAINT PK_DodatnaUsluga PRIMARY KEY (id,id_popravak);


ALTER TABLE Vozilo ADD CONSTRAINT FK_Vozilo_0 FOREIGN KEY (id_korisnik) REFERENCES Korisnik (id);


ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_0 FOREIGN KEY (id_korisnik) REFERENCES Korisnik (id);
ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_1 FOREIGN KEY (id_Vozilo) REFERENCES Vozilo (id);
ALTER TABLE Popravak ADD CONSTRAINT FK_Popravak_2 FOREIGN KEY (id_serviser) REFERENCES Serviser (id);


ALTER TABLE PopravakUsluga ADD CONSTRAINT FK_PopravakUsluga_0 FOREIGN KEY (id_popravak) REFERENCES Popravak (id);
ALTER TABLE PopravakUsluga ADD CONSTRAINT FK_PopravakUsluga_1 FOREIGN KEY (id_usluga) REFERENCES Usluga (id);


ALTER TABLE PopravakVozilo ADD CONSTRAINT FK_PopravakVozilo_0 FOREIGN KEY (id_zamj_vozilo) REFERENCES ZamjenskoVozilo (id);
ALTER TABLE PopravakVozilo ADD CONSTRAINT FK_PopravakVozilo_1 FOREIGN KEY (id_popravak) REFERENCES Popravak (id);


ALTER TABLE DodatnaUsluga ADD CONSTRAINT FK_DodatnaUsluga_0 FOREIGN KEY (id_popravak) REFERENCES Popravak (id);


