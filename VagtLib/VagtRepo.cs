using System;
using System.Collections.Generic;
using System.Text;
using VagtLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Razor.Vagtselskab.Repositories
{
    public class VagtRepo : IVagtRepo
    {
        private readonly DBConnecter _db = new DBConnecter();

        public VagtRepo(DBConnecter dbConnecter)
        {
            _db = dbConnecter;
        }

        // Opret vagt
        public void Add(Vagt vagt)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Vagter
                (Virksomhed, Dato, StartTid,
                SlutTid, Adresse, KundensOpgaveBeskrivelse, LSSBeskrivelse, Krav, AntalMedarbejder)
                VALUES
                (@Virksomhed, @Dato, @StartTid,
                @SlutTid, @Adresse, @KundensOpgaveBeskrivelse, @LSSBeskrivelse, @Krav, @AntalMedarbejder)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VagtId", vagt.VagtId);
                    cmd.Parameters.AddWithValue("@Virksomhed", vagt.Virksomhed);
                    cmd.Parameters.AddWithValue("@Dato", vagt.Dato);
                    cmd.Parameters.AddWithValue("@StartTid", vagt.StartTid);
                    cmd.Parameters.AddWithValue("@SlutTid", vagt.SlutTid);
                    cmd.Parameters.AddWithValue("@Adresse", vagt.Adresse);
                    cmd.Parameters.AddWithValue("@KundensOpgaveBeskrivelse", vagt.KundensOpgaveBeskrivelse);
                    cmd.Parameters.AddWithValue("@LSSBeskrivelse", vagt.LSSBeskrivelse);
                    cmd.Parameters.AddWithValue("@Krav", vagt.Krav);
                    cmd.Parameters.AddWithValue("@AntalMedarbejder", vagt.AntalMedarbejder);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Find vagt
        public Vagt GetById(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Vagter WHERE VagtId = @VagtId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                
                    cmd.Parameters.AddWithValue("@VagtId", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Vagt vagt = new Vagt
                        {
                            VagtId = reader.GetInt32(0),
                            Dato = reader.GetDateTime(1),
                            StartTid = reader.GetDateTime(2),
                            SlutTid = reader.GetDateTime(3),
                            Adresse = reader.GetString(4),
                            KundensOpgaveBeskrivelse = reader.GetString(5),
                            Virksomhed = reader.GetString(6),
                            LSSBeskrivelse = reader.GetString(7),
                            Krav = reader.GetString(8),
                            AntalMedarbejder = reader.GetInt32(9)
                        };
                        return vagt;
                    
                }
            }

            return null;
        }

        // Rediger vagt
        public void Update(Vagt vagt)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE Vagter SET
                Virksomhed = @Virksomhed,
                Dato = @Dato,
                StartTid = @StartTid,
                SlutTid = @SlutTid,
                Adresse = @Adresse,
                KundensOpgaveBeskrivelse = @KundensOpgaveBeskrivelse,
                LSSBeskrivelse = @LSSBeskrivelse,
                Krav = @Krav,
                AntalMedarbejder = @AntalMedarbejder
                Status = @Status
                WHERE VagtId = @VagtId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VagtId", vagt.VagtId);
                    cmd.Parameters.AddWithValue("@Virksomhed", vagt.Virksomhed);
                    cmd.Parameters.AddWithValue("@Dato", vagt.Dato);
                    cmd.Parameters.AddWithValue("@StartTid", vagt.StartTid);
                    cmd.Parameters.AddWithValue("@SlutTid", vagt.SlutTid);
                    cmd.Parameters.AddWithValue("@Adresse", vagt.Adresse);
                    cmd.Parameters.AddWithValue("@KundensOpgaveBeskrivelse", vagt.KundensOpgaveBeskrivelse);
                    cmd.Parameters.AddWithValue("@LSSBeskrivelse", vagt.LSSBeskrivelse);
                    cmd.Parameters.AddWithValue("@Krav", vagt.Krav);
                    cmd.Parameters.AddWithValue("@AntalMedarbejder", vagt.AntalMedarbejder);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Slet vagt
        public void Delete(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Vagter WHERE VagtId = @VagtId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VagtId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

