using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace IF4101_ProyectoFinal.Controls
{
    public class SignUpControl
    {

        Encryption encrypt = new Encryption();

        public Boolean checkPasswordEquality(String firstPassword, String secondPassword)
        {
            return firstPassword.Equals(secondPassword);
        }

        public int checkEmailAvailability(String email)
        {
            int ID = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("A_CHECK_EMAIL", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value); 
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
            return ID;
        }

    public int saveToDB(String fullName, String lastName, String secondLastName, String email, String adress, String firstPassword)
        {
            int ID = 0;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            using (SqlCommand cmd = new SqlCommand("A_ADD_USER", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fullName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                cmd.Parameters.Add("@SecondLastName", SqlDbType.NVarChar).Value = secondLastName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = adress;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = encrypt.ComputeSha256Hash(firstPassword);
                cmd.Parameters.Add("@State", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@PartyType", SqlDbType.TinyInt).Value = 3;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Convert.ToInt32(cmd.Parameters["@ID"].Value);
            }
        }

    }
}