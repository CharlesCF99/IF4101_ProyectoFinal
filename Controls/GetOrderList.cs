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
        public List<string> GetOrdersList(String filterSettings)
        {
            int ID = 0;
            DateTime date = new DateTime();
            string status = "";
            string name = "";
            var data = new List<string>();
            var tempList1 = new List<string>();
            var tempList2 = new List<string>();
            var result = new List<string>();

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

            if (filterSettings != "")
            {
                String[] tempString = filterSettings.Split('$');
                Boolean flag1 = false;

                if (tempString[1] != "1")
                {
                    foreach (var item in data)
                    {
                        if (item.Split('|')[1].ToString().Contains(tempString[1].Replace("1", "")))
                        {
                            tempList1.Add(item);
                            flag1 = true;
                        }
                    }
                }

                if (tempString[2] != "2_")
                {
                    if (flag1)
                    {
                        foreach (var item in tempList1)
                        {
                            DateTime initialDate = DateTime.Parse(tempString[2].Replace("2_", ""));
                            DateTime endDate = DateTime.Parse(tempString[3].Replace("3_", ""));
                            DateTime tempDate = DateTime.Parse(item.Split('|')[2].ToString());

                            if (initialDate <= tempDate && tempDate <= endDate)
                            {
                                tempList2.Add(item);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in data)
                        {
                            DateTime initialDate = DateTime.Parse(tempString[2].Replace("2_", ""));
                            DateTime endDate = DateTime.Parse(tempString[3].Replace("3_", ""));
                            DateTime tempDate = DateTime.Parse(item.Split('|')[2].ToString());

                            if (initialDate <= tempDate && tempDate <= endDate)
                            {
                                tempList2.Add(item);
                            }
                        }
                    }
                }

                if (tempString[4] != "4")
                {
                    foreach (var item in tempList2)
                    {
                        if (item.Split('|')[3].ToString().Contains(tempString[4].Replace("4", "")))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            else
            {
                result = data;
            }
            return result;
        }
    }
}