using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VagtLib
{
    public class VagtRapportRepo : IVagtRapportRepo
    {
        private readonly DBConnecter _db = new DBConnecter();

        public List<VagtRapport> GetAllVagtRapport()
        {
            List<VagtRapport> vagtRapporter = new List<VagtRapport>();
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM VagtRapport";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    VagtRapport vagtRapport = new VagtRapport
                    {
                        VagtRapportId = reader.GetInt32(0),
                        Rapport = reader.GetString(1)
                    };
                    vagtRapporter.Add(vagtRapport);
                }

                return vagtRapporter;


            }
        }

        public VagtRapport GetVagtRapportById(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM VagtRapport WHERE VagtRapportId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    VagtRapport vagtRapport = new VagtRapport
                    {
                        VagtRapportId = reader.GetInt32(0),
                        Rapport = reader.GetString(1)
                    };
                    return vagtRapport;
                }

            }
            return null;

        }

        public void CreateVagtRapport(VagtRapport vagtRapport)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO VagtRapport (Rapport) VALUES (@rapport)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rapport", vagtRapport.Rapport);
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateVagtRapport(VagtRapport vagtRapport)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE VagtRapport SET Rapport = @rapport WHERE VagtRapportId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rapport", vagtRapport.Rapport);
                cmd.Parameters.AddWithValue("@id", vagtRapport.VagtRapportId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVagtRapport(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM VagtRapport WHERE VagtRapportId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
