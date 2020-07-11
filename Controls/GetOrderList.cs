using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetOrderList
    {
        public List<string> GetOrdersList()
        {
            int ID = 0;
            DateTime date = new DateTime();
            string status = "";
            string name = "";
            var data = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_GET_ALL_ORDERS", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ID = int.Parse(reader["OrderID"].ToString());
                name = reader["PartyName"].ToString();
                date = DateTime.Parse(reader["OrderDate"].ToString());
                status = reader["OrderStatusDescription"].ToString();
                data.Add(ID + "|" + name + "|" + date + "|" + status + "|");
            }
            connection.Close();
            return data;
        }
    }
}