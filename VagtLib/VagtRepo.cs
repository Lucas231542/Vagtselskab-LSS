using System;
using System.Collections.Generic;
using System.Text;
using VagtLib;
using Microsoft.EntityFrameworkCore;
using VagtLib.Lib;
using Microsoft.Data.SqlClient;

namespace Razor.Vagtselskab.Repositories
{
    public class VagtRepo
    {
        private readonly DBConnecter _dbConnecter;

        public VagtRepo(DBConnecter dbConnecter)
        {
            _dbConnecter = dbConnecter;
        }
        

        // Opret vagt
        public int Add(Vagt vagt)
        {
            using (SqlConnection conn = _dbConnecter.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Vagter
        (Virksomhed, Dato, StartTid, SlutTid, Adresse,
        KundensOpgaveBeskrivelse, LSSBeskrivelse, Krav,
        AntalMedarbejder)
        VALUES
        (@Virksomhed, @Dato, @StartTid, @SlutTid, @Adresse,
        @KundensOpgaveBeskrivelse, @LSSBeskrivelse, @Krav,
        @AntalMedarbejder);

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Virksomhed", vagt.Virksomhed);
                    cmd.Parameters.AddWithValue("@Dato", vagt.Dato);
                    cmd.Parameters.AddWithValue("@StartTid", vagt.StartTid);
                    cmd.Parameters.AddWithValue("@SlutTid", vagt.SlutTid);
                    cmd.Parameters.AddWithValue("@Adresse", vagt.Adresse);
                    cmd.Parameters.AddWithValue("@KundensOpgaveBeskrivelse", vagt.KundensOpgaveBeskrivelse);
                    cmd.Parameters.AddWithValue("@LSSBeskrivelse", vagt.LSSBeskrivelse);
                    cmd.Parameters.AddWithValue("@Krav", vagt.Krav);
                    cmd.Parameters.AddWithValue("@AntalMedarbejder", vagt.AntalMedarbejder);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        // Find vagt
        public Vagt GetById(int id)
        {
            using (SqlConnection conn = _dbConnecter.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Vagter WHERE VagtId = @VagtId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VagtId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vagt(
                                (int)reader["VagtId"],
                                (DateTime)reader["Dato"],
                                reader["StartTid"].ToString(),
                                reader["SlutTid"].ToString(),
                                reader["Adresse"].ToString(),
                                reader["KundensOpgaveBeskrivelse"].ToString(),
                                reader["Virksomhed"].ToString(),
                                reader["LSSBeskrivelse"].ToString(),
                                reader["Krav"].ToString(),
                                (int)reader["AntalMedarbejder"]

                            );
                        }
                    }
                }
            }

            return null;
        }

        // Rediger vagt
        public void Update(Vagt vagt)
        {
            using (SqlConnection conn = _dbConnecter.GetConnection())
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
                AntalMedarbejder = @AntalMedarbejde 
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
            using (SqlConnection conn = _dbConnecter.GetConnection())
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

