
using System;
using VagtLib;
using VagtLib.Lib;
using Razor.Vagtselskab.Repositories;

class Program 
{
    static void Main(string[] args)
    {
        DBConnecter db = new DBConnecter();
        VagtRepo repo = new VagtRepo(db);

        Console.WriteLine("===== LSS VAGT TEST =====");

        int vagtId = 0;

        try
        {
            // TEST 1 - OPRET VAGT
            Console.WriteLine("\nTEST 1: Opretter vagt");

            Vagt vagt = new Vagt(
                0,
                DateTime.Now,
                "08:00",
                "16:00",
                "København",
                "Almindelig vagtservice",
                "LSS Test ApS",
                "Kontrol og overvågning",
                "Mødestabil",
                2
            );

            vagtId = repo.Add(vagt);

            Console.WriteLine("Vagt oprettet med ID: " + vagtId);


            // TEST 2 - FIND VAGT
            Console.WriteLine("\nTEST 2: Finder vagt");

            Vagt fundetVagt = repo.GetById(vagtId);

            if (fundetVagt != null)
            {
                Console.WriteLine("Vagt fundet!");
                Console.WriteLine("ID: " + fundetVagt.VagtId);
                Console.WriteLine("Virksomhed: " + fundetVagt.Virksomhed);
                Console.WriteLine("Adresse: " + fundetVagt.Adresse);
                Console.WriteLine("Starttid: " + fundetVagt.StartTid);
                Console.WriteLine("Sluttid: " + fundetVagt.SlutTid);
            }
            else
            {
                throw new Exception("Vagt blev ikke fundet!");
            }


            // TEST 3 - OPDATER VAGT
            Console.WriteLine("\nTEST 3: Opdaterer vagt");

            fundetVagt.Adresse = "Roskilde";
            fundetVagt.AntalMedarbejder = 3;

            repo.Update(fundetVagt);

            Console.WriteLine("Vagt opdateret!");


            // Kontroller opdateringen
            Vagt opdateretVagt = repo.GetById(vagtId);

            Console.WriteLine("Ny adresse: " + opdateretVagt.Adresse);
            Console.WriteLine("Antal medarbejdere: " + opdateretVagt.AntalMedarbejder);


            // TEST 4 - SLET VAGT
            Console.WriteLine("\nTEST 4: Sletter vagt");

            repo.Delete(vagtId);

            Console.WriteLine("Vagt slettet!");

            vagtId = 0;


            // Kontroller sletningen
            Vagt slettetVagt = repo.GetById(
                opdateretVagt.VagtId
            );

            if (slettetVagt == null)
            {
                Console.WriteLine("Sletning bekræftet!");
            }
            else
            {
                throw new Exception("Vagt blev ikke slettet!");
            }


            Console.WriteLine("\n==========================");
            Console.WriteLine("ALLE TESTS BESTÅET!");
            Console.WriteLine("==========================");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nDER OPSTOD EN FEJL:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nTryk på en tast for at afslutte...");
        Console.ReadKey();
    }
}
