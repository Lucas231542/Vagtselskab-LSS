CREATE TABLE Vagter
(
    VagtId INT IDENTITY(1,1) PRIMARY KEY,
    Virksomhed NVARCHAR(100),
    Dato DATE,
    StartTid NVARCHAR(20),
    SlutTid NVARCHAR(20),
    Adresse NVARCHAR(200),
    KundensOpgaveBeskrivelse NVARCHAR(MAX),
    LSSBeskrivelse NVARCHAR(MAX),
    Krav NVARCHAR(MAX),
    AntalMedarbejder INT
);