using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class VagtService
    {
        private List<Vagt> vagter = new List<Vagt>();
        public void OpretVagt ( Vagt vagt)
        {
            vagter.Add(vagt);
            Console.WriteLine("Vagten er oprettet");
        }
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
