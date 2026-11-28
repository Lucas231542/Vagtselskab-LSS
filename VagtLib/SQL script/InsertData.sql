


DELETE FROM Tilmelding;
DELETE FROM VagtRapport;
DELETE FROM Vagter;
DELETE FROM Bruger;
DBCC CHECKIDENT ('Bruger', RESEED, 0);
DBCC CHECKIDENT ('Vagter', RESEED, 0);

INSERT INTO Bruger
(Navn, Email, Brugernavn, Adgangskode, Telefonnummer, ErLeder, ErMedarbejder, ErKunde)
VALUES
('Lars Jensen', 'lars@lss.dk', 'larsj', '1234', '28112233', 1, 0, 0),

('Mikkel Hansen', 'mikkel@lss.dk', 'mikkelh', '1234', '29113344', 0, 1, 0),

('Emma Nielsen', 'emma@lss.dk', 'emman', '1234', '30114455', 0, 1, 0),

('Jonas Petersen', 'jonas@lss.dk', 'jonasp', '1234', '31115566', 0, 1, 0),

('Dansk Industri', 'kontakt@danskindustri.dk', 'kunde1', '1234', '32116677', 0, 0, 1);
INSERT INTO Vagter
(Dato, StartTid, SlutTid, Adresse, KundensOpgaveBeskrivelse, Virksomhed, LSSbeskrivelse, Krav, AntalMedarbejder)
VALUES
(
'2026-12-01',
'2026-12-01 08:00:00',
'2026-12-01 16:00:00',
'Nørregade 15, Næstved',
'fs',
'Adgangskontrol ved indgang',
'Modtag gæster og kontrollér adgangskort',
'Serviceorienteret og mødestabil',
2
),

(
'2026-12-05',
'2026-12-05 16:00:00',
'2026-12-05 23:00:00',
'Arena Næstved',
'ws',
'Sikkerhed ved koncert',
'Patruljering og billetkontrol',
'Erfaring med arrangementer',
4
),

(
'2026-12-10',
'2026-12-10 18:00:00',
'2026-12-11 02:00:00',
'Grønnegade 8, Næstved',
'ews',
'Dørmand ved firmafest',
'Kontrol af gæster ved indgang',
'Konflikthåndtering',
2
);
INSERT INTO VagtRapport
(VagtId, BrugerId, Rapport)
VALUES
(
1,
2,
'Vagten forløb uden problemer. Alle adgangskort blev kontrolleret, og der var ingen hændelser.'
),

(
2,
3,
'Koncerten forløb roligt. To gæster blev bortvist på grund af beruselse. Ingen øvrige problemer.'
),

(
3,
4,
'Firmafesten forløb tilfredsstillende. Enkelte gæster blev vejledt ved indgangen. Ingen konflikter.'
);


INSERT INTO Tilmelding
(VagtId, BrugerId)
VALUES
(1,2),
(1,3),
(2,3),
(2,4),
(3,2);
