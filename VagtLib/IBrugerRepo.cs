using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public interface IBrugerRepo
    {
        public Bruger LavBruger(SqlDataReader r);
        List<Bruger> GetAll();
        Bruger? GetById(int brugerId);
        Bruger? Login(string brugernavn, string adgangskode);
        void Opret(Bruger bruger);
        void Update(Bruger bruger);
     

    }
}
