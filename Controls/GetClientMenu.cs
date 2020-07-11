using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetClientMenu
    {
        public List<string> GetClientsMenu()
        {
            int ID = 0;
            string name = "";
            int price = 0;
            var data = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("C_GET_MENU", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                ID = int.Parse(reader["PlateID"].ToString());
                name = reader["PlateName"].ToString();
                price = int.Parse(reader["PlatePrice"].ToString());
                data.Add(ID+"|"+ name+"|"+ price+"|");
            }
            connection.Close();
            return data;
        }
    }
}