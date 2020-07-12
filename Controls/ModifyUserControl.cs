using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace IF4101_ProyectoFinal.Controls
{
    public class ModifyUserControl
    {

        Encryption encrypt = new Encryption();

        public Boolean checkPasswordEquality(String firstPassword, String secondPassword)
        {
            return firstPassword.Equals(secondPassword);
        }

        public void saveModifyUser(String name, String adress, String firstPassword)
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(stringConnection);
            using (SqlCommand cmd = new SqlCommand("A_MODIFY_USER", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = adress;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = encrypt.ComputeSha256Hash(firstPassword);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}