Drop Table if exists VagtRapport
Drop Table if exists Tilmelding
Drop Table if exists VagtOpgave
Drop Table if exists Vagter
Drop Table if exists Bruger

Create Table vagter(
vagtId int primary key identity(1,1),
Dato dateTime not null,
starttid datetime not null,
sluttid datetime not null,
adresse nvarchar(50) not null,
KundensOpgaveBeskrivelse nvarchar(100) not null,
Virksomhed nvarchar(50) not null,
LSSbeskrivelse nvarchar(100) not null,
Krav nvarchar(100) not null,
AntalMedarbejder int not null
)
Create Table Bruger(
BrugerId int primary key identity(1,1),
Navn varchar(255) not null,
Email varchar(255) not null,
Brugernavn varchar(255) not null,
Adgangskode varchar(255) not null,
Telefonnummer varchar(20) not null,
ErLeder bit not null,
ErMedarbejder bit not null,
ErKunde bit not null
)

Create Table vagtRapport(
VagtRapportId int primary key identity(1,1),
vagtId int not null,
BrugerId int not null,
Rapport varchar(500) not null,
Foreign Key (BrugerId) references Bruger(BrugerId),
Foreign Key (vagtId) references vagter(vagtId),

)

CREATE TABLE Tilmelding
(
    VagtId INT NOT NULL,
    BrugerId INT NOT NULL,

    FOREIGN KEY (VagtId) REFERENCES Vagter(VagtId),
    FOREIGN KEY (BrugerId) REFERENCES Bruger(BrugerId),
);
