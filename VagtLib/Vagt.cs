using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{

    public class Vagt
    {
    public Vagt()
        {
        }
        //properties
        public int VagtId { get; set; }
        public DateTime Dato { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public string Adresse { get; set; }
        public string KundensOpgaveBeskrivelse { get; set; }
        public string Virksomhed { get; set; }
        public string LSSBeskrivelse { get; set; }

        public string Krav { get; set; }
        public int AntalMedarbejder { get; set; }


        public Vagt(int vagtId, DateTime dato, DateTime startTid, DateTime slutTid, string adresse, string kundensOpgaveBeskrivelse, string virksomhed, string lSSBeskrivelse, string krav, int antalMedarbejder)
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

