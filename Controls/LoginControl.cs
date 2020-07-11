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
    public class LoginControl
    {

        Encryption encrypt = new Encryption();

        public Tuple<int, string, string, string, string, int> checkUserData(String email, String password)
        {
            int ID = 0;
            string name = "";
            string lastName = "";
            string secondLastName = "";
            string adress = "";
            int partyType = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("A_LOG_USER", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = encrypt.ComputeSha256Hash(password);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add("@SecondLastName", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add("@Adress", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@PartyTypeFK", SqlDbType.TinyInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Name"].Direction = ParameterDirection.Output;
                cmd.Parameters["@LastName"].Direction = ParameterDirection.Output;
                cmd.Parameters["@SecondLastName"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Adress"].Direction = ParameterDirection.Output;
                cmd.Parameters["@PartyTypeFK"].Direction = ParameterDirection.Output;
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                    name = Convert.ToString(cmd.Parameters["@Name"].Value);
                    lastName = Convert.ToString(cmd.Parameters["@LastName"].Value);
                    secondLastName = Convert.ToString(cmd.Parameters["@SecondLastName"].Value);
                    adress = Convert.ToString(cmd.Parameters["@Adress"].Value);
                    partyType = Convert.ToInt32(cmd.Parameters["@PartyTypeFK"].Value);
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    connection.Close();
                }

            }
            return new Tuple<int, string, string, string, string, int>(ID, name, lastName, secondLastName, adress, partyType);
        }
    }
}