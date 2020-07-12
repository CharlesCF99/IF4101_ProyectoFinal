using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetAdminMenu
    {
        public List<string> GetAdminsMenu()
        {
            int ID = 0;
            string name = "";
            string description = "";
            string status = "";
            int price = 0;
            var data = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_GET_ALL_PLATES", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ID = int.Parse(reader["PlateID"].ToString());
                name = reader["PlateName"].ToString();
                description = reader["PlateDescription"].ToString();
                status = reader["PlateStatus"].ToString();
                price = int.Parse(reader["PlatePrice"].ToString());
                data.Add(ID + "|" + name + "|" + description + "|" + status + "|" + price + "|");
            }
            connection.Close();
            return data;
        }
    }
}