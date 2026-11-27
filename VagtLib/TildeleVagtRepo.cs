using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class TildeleVagtRepo
    {
        private readonly DBConnecter _db = new DBConnecter();
        public List<Vagt> HentMineVagter(int brugerId)
        {
            List<Vagt> liste = new List<Vagt>();
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT v.VagtId, v.StartTid, v.SlutTid, v.Adresse, v. Virksomhed, v.Kundebeskrivelse, v.LSSbeskrivelse, v.Krav, v.AntalMedarbejdere
                             FROM Vagt v
                             JOIN Tilmelding t ON v.VagtId = t.VagtId
                             WHERE t.BrugerId = @BrugerId
                             ORDER BY v.startTid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BrugerId", brugerId);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    liste.Add(new Vagt
                    {
                        VagtId = r.GetInt32(0),
                        Starttid = r.GetInt32(1),
                        SlutTid = r.GetDateTime(2),
                        Adresse = r.GetDateTime(3),
                        Virksomhed = r.IsDBNull(4) ? "" : r.GetString(4),
                        Kundebeskrivelse = r.IsDBNull(5) ? "" : r.GetString(5),
                        LSSbeskrivelse = r.IsDBNull(6) ? "" : r.GetString(6),
                        Krav = r.IsDBNull(7) ? "" : r.GetString(7),
                        AntalMedarbejdere = r.IsDBNull(8) ? 0 : r.GetInt32(8)
                    });
                }
            }

            return liste;
        }
    }
}
