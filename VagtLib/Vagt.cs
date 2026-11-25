using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class Vagt
    {
        //properties
        public int VagtId { get; set; }
        public DateTime Dato { get; set; }
        public string StartTid { get; set; }
        public string SlutTid { get; set; }
        public string Adresse { get; set; }
        public string KundensOpgaveBeskrivelse { get; set; }
        public string Virksomhed { get; set; }
        public string LSSBeskrivelse { get; set; }

        public string Krav { get; set; }
        public int AntalMedarbejder { get; set; }

              
        public Vagt(int vagtId, DateTime dato, string startTid, string slutTid, string adresse, string kundensOpgaveBeskrivelse, string virksomhed, string lSSBeskrivelse, string krav, int antalMedarbejder)
        {
            //tildeling af værdier 
            VagtId = vagtId;
            Dato = dato;
            StartTid = startTid;
            SlutTid = slutTid;
            Adresse = adresse;
            KundensOpgaveBeskrivelse = kundensOpgaveBeskrivelse;
            Virksomhed = virksomhed; 
            LSSBeskrivelse = lSSBeskrivelse;
            Krav = krav;
            AntalMedarbejder = antalMedarbejder;
        }
    }
}

