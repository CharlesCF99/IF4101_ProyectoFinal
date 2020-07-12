using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class A_ADD_PLATE
    {
        public void addPlate(LoadPlateControl plate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("A_ADD_PLATE", connection);
            connection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PlateName", plate.PlateName1);
            sqlCommand.Parameters.AddWithValue("@PlateDescription", plate.PlateDescription1);
            sqlCommand.Parameters.AddWithValue("@PlatePrice", plate.PlatePrice1);
            sqlCommand.Parameters.AddWithValue("@PlatePhoto", plate.getImage());
            sqlCommand.Parameters.AddWithValue("@PlateStatus", plate.PlateStatus1);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public LoadPlateControl getPlate(int ID)
        {
            LoadPlateControl plate;
            DataSet MiDataSet = new DataSet();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("A_GET_PLATE_BY_ID", connection);
            connection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PlateID", ID);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(MiDataSet, "Plate");
            connection.Close();
            plate = new LoadPlateControl();
            foreach (DataTable table in MiDataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    // plato = new CargarImagen();
                    plate.PlateID1 = Convert.ToInt32(row["PlateID"].ToString());
                    plate.PlateName1 = row["PlateName"].ToString();
                    plate.PlateDescription1 = row["PlateDescription"].ToString();
                    plate.PlatePrice1 = (int)row["PlatePrice"];
                    plate.setImageAndURL((byte[])row["PlatePhoto"]);
                    System.Diagnostics.Debug.WriteLine(row["PlateName"].ToString());
                }
            }
            return plate;
        }


    }
}