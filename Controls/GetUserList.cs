using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetUserList
    {
        public List<string> GetUsersList()
        {
            int ID = 0;
            string name = "";
            string email = "";
            string status = "";
            string type = "";
            var data = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_GET_ALL_USERS", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ID = int.Parse(reader["PartyID"].ToString());
                name = reader["PartyName"].ToString();
                email = reader["PartyEmail"].ToString();
                status = reader["PartyStatus"].ToString();
                type = reader["PartyType"].ToString();
                data.Add(ID + "|" + name + "|" + email + "|" + status + "|" + type + "|");
            }
            connection.Close();
            return data;
        }
    }
}