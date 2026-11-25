using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class Bruger
    {
        public int BrugerId { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Brugernavn { get; set; }
        public string Adgangskode { get; set; }
        public string Telefonnummer { get; set; }
        public bool ErLeder { get; set; }
        public bool ErMedarbejder { get; set; }
        public bool ErKunde { get; set; }
    }
}
