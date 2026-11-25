using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class Vagt
    { 
        public int VagtId { get; set; }
        public string Virksomhed {  get; set; }
        public DateTime Dato { get; set; }
        public string StartTid { get; set; }
        public string SlutTid { get; set; }
        public string Beskrivelse { get; set; }
        public string Status { get; set; }

        public Vagt (int vagtId, string virksomhed, DateTime dato, string startTid, string slutTid, string beskrivelse, string status)
        {
            VagtId = vagtId;
            Virksomhed = virksomhed;
            Dato = dato; 
            StartTid = startTid;
            SlutTid = slutTid;
            Beskrivelse = beskrivelse;
            Status = status; 
        }
    }
}
