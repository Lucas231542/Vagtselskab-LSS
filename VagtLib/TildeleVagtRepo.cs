using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public class TildeleVagtRepo : ITildeleVagtRepo
    {
        private readonly DBConnecter _db = new DBConnecter();
        public List<Vagt> HentMineVagter(int brugerId)
        {
            List<Vagt> liste = new List<Vagt>();
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT v.VagtId, v.Dato, v.StartTid, v.SlutTid, v.Adresse, v.KundensOpgaveBeskrivelse, v.Virksomhed, v.LSSbeskrivelse, v.Krav, v.AntalMedarbejder
                             FROM Vagter v
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
                        Dato = r.GetDateTime(1).Date,
                        StartTid = r.GetDateTime(2),
                        SlutTid = r.GetDateTime(3),
                        Adresse = r.GetString(4),
                        KundensOpgaveBeskrivelse = r.GetString(5),
                        Virksomhed = r.GetString(6),
                        LSSBeskrivelse = r.GetString(7),
                        Krav = r.GetString(8),
                        AntalMedarbejder = r.GetInt32(9)
                    });
                }
            }

            return liste;
        }
    }
}
