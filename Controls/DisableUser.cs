using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class DisableUser
    {
        public void DeleteAdmin(int ID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_DISABLE_CLIENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = ID;



            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}