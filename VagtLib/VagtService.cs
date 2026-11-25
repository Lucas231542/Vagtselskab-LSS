using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class VagtService
    {
        // Liste til opbevaring af alle oprettede vagter
        private List<Vagt> vagter = new List<Vagt>();
        public void OpretVagt ( Vagt vagt)
        {
            vagter.Add(vagt);
            Console.WriteLine("Vagten er oprettet");
        }
        // Metode til visning af alle oprettede vagter
        public void VisVagter()
        {
            foreach (Vagt vagt in vagter)
            {
                Console.WriteLine("Vagt ID: " + vagt.VagtId);
                Console.WriteLine("Virksomhed: " + vagt.Virksomhed);
                Console.WriteLine("Dato: " + vagt.Dato.ToShortDateString());
                Console.WriteLine("Tid: " + vagt.StartTid + " - " + vagt.SlutTid);
                Console.WriteLine("Beskrivelse: " + vagt.Beskrivelse);
                Console.WriteLine("Status: " + vagt.Status); 
            }
        }
    }
}
