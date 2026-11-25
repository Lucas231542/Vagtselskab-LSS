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
        public void Add(Vagt vagt)
        {
            using (SqlConnection conn = _dbConnecter.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Vagter
                (Medarbejder, Virksomhed, Dato, StartTid,
                SlutTid, Beskrivelse, Status)
                VALUES
                (@Medarbejder, @Virksomhed, @Dato, @StartTid,
                @SlutTid, @Beskrivelse, @Status)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Medarbejder", vagt.Medarbejder);
                    cmd.Parameters.AddWithValue("@Virksomhed", vagt.Virksomhed);
                    cmd.Parameters.AddWithValue("@Dato", vagt.Dato);
                    cmd.Parameters.AddWithValue("@StartTid", vagt.StartTid);
                    cmd.Parameters.AddWithValue("@SlutTid", vagt.SlutTid);
                    cmd.Parameters.AddWithValue("@Beskrivelse", vagt.Beskrivelse);
                    cmd.Parameters.AddWithValue("@Status", vagt.Status);

                    cmd.ExecuteNonQuery();
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
                                reader["Medarbejder"].ToString(),
                                reader["Virksomhed"].ToString(),
                                (DateTime)reader["Dato"],
                                reader["StartTid"].ToString(),
                                reader["SlutTid"].ToString(),
                                reader["Beskrivelse"].ToString(),
                                reader["Status"].ToString()
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
                Medarbejder = @Medarbejder,
                Virksomhed = @Virksomhed,
                Dato = @Dato,
                StartTid = @StartTid,
                SlutTid = @SlutTid,
                Beskrivelse = @Beskrivelse,
                Status = @Status
                WHERE VagtId = @VagtId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VagtId", vagt.VagtId);
                    cmd.Parameters.AddWithValue("@Medarbejder", vagt.Medarbejder);
                    cmd.Parameters.AddWithValue("@Virksomhed", vagt.Virksomhed);
                    cmd.Parameters.AddWithValue("@Dato", vagt.Dato);
                    cmd.Parameters.AddWithValue("@StartTid", vagt.StartTid);
                    cmd.Parameters.AddWithValue("@SlutTid", vagt.SlutTid);
                    cmd.Parameters.AddWithValue("@Beskrivelse", vagt.Beskrivelse);
                    cmd.Parameters.AddWithValue("@Status", vagt.Status);

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

