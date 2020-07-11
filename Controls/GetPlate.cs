using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetPlate
    {

        public void GetPlateAdmin(string PlateName, string PlateDescription, int PlatePrice, string PlatePhoto, int PlateStatus)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_ADD_PLATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlateName", SqlDbType.NVarChar).Value = PlateName;
            cmd.Parameters.Add("@PlateDescription", SqlDbType.NVarChar).Value = PlateDescription;
            cmd.Parameters.Add("@PlatePrice", SqlDbType.Int).Value = PlatePrice;
            cmd.Parameters.Add("@PlatePhoto", SqlDbType.VarChar).Value = PlatePhoto;
            cmd.Parameters.Add("@PlateStatus", SqlDbType.Bit).Value = PlateStatus;


            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}