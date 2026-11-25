using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class Vagt
    {
        public int VagtId { get; set; }
        public string Medarbejder { get; set; }
        public string Virksomhed { get; set; }
        public DateTime Dato { get; set; }
        public string StartTid { get; set; }
        public string SlutTid { get; set; }
        public string Beskrivelse { get; set; }
        public string Status { get; set; }

        public Vagt(int vagtId, string medarbejder, string virksomhed, DateTime dato, string startTid, string slutTid, string beskrivelse, string status)
        {
            VagtId = vagtId;
            Medarbejder = medarbejder;
            Virksomhed = virksomhed;
            Dato = dato;
            StartTid = startTid;
            SlutTid = slutTid;
            Beskrivelse = beskrivelse;
            Status = status;
        }
    }
}

