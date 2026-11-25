using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public interface IVagtRapportRepo
    {
        public interface IAktivitetRepo
        {
            public List<VagtRapport> GetAllVagtRapporter();
            public VagtRapport GetVagtRapportById(int vagtRapportId);
            public void CreateVagtRapport(VagtRapport vagtRapport);
            public void UpdateVagtRapport(VagtRapport vagtRapport);
            public void DeleteVagtRapport(int vagtRapportId);


        }
    }
}
