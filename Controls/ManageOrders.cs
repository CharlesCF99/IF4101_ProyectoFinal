using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IF4101_ProyectoFinal.Controls
{
    public class ManageOrders
    {
        public List<string> GetActiveOrdersList()
        {
            int ID = 0;
            string name = "";
            string orderDescription = "";
            var data = new List<string>();
            var depuratedData = new List<string>();
            int idHolder = 0;
            string nameHolder = "";
            string orderDescriptionHolder = "";

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("K_GET_ORDERS_DETAILS", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ID = int.Parse(reader["OrderID"].ToString());
                name = reader["PartyName"].ToString();
                orderDescription = reader["OrderDescription"].ToString();
                data.Add(ID + "|" + name + "|" + orderDescription);
            }
            connection.Close();

            int lastIndex = 1;
            foreach (var item in data)
            {
                if (lastIndex == Convert.ToInt32(item.Split('|')[0].ToString()))
                {
                    idHolder = Convert.ToInt32(item.Split('|')[0].ToString());
                    nameHolder = item.Split('|')[1].ToString();
                    orderDescriptionHolder += item.Split('|')[2].ToString() + ". ";
                }
                else
                {
                    depuratedData.Add(idHolder + "|" + nameHolder + "|" + orderDescriptionHolder);
                    orderDescriptionHolder = "";
                    lastIndex++;
                    idHolder = Convert.ToInt32(item.Split('|')[0].ToString());
                    nameHolder = item.Split('|')[1].ToString();
                    orderDescriptionHolder += item.Split('|')[2].ToString() + ".";
                }
            }
            depuratedData.Add(idHolder + "|" + nameHolder + "|" + orderDescriptionHolder);
            return depuratedData;
        }

        public void setOrderAsDelivered(int orderID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("K_SET_ORDER_AS_DELIVERED", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            connection.Close();
        }

        public void setOrderAsNoDelivered(int orderID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("K_SET_ORDER_AS_NO_DELIVERED", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            connection.Close();
        }
    }
}