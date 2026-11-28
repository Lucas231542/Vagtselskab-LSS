using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public interface IVagtRapportRepo
    {

            public List<VagtRapport> GetAllVagtRapport();

            public VagtRapport GetVagtRapportById(int vagtRapportId);
            public void CreateVagtRapport(VagtRapport vagtRapport);
            public void UpdateVagtRapport(VagtRapport vagtRapport);
            public void DeleteVagtRapport(int vagtRapportId);
    }
}
