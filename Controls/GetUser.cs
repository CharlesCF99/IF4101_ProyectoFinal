using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class GetUser
    {
        public void AddAdmin(string Name, string LastName, string SecondLastName, string Email, string Adress, char Password, bool State, int PartyType)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_ADD_PLATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            cmd.Parameters.Add("@SecondLastName", SqlDbType.NVarChar).Value = SecondLastName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = Adress;
            cmd.Parameters.Add("@Password", SqlDbType.Char).Value = Password;
            cmd.Parameters.Add("@State", SqlDbType.Bit).Value = State;
            cmd.Parameters.Add("@PartyType", SqlDbType.SmallInt).Value = PartyType;

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

        }
        public void DeleteAdmin(int ID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_DELETE_USER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = ID;



            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

        }
        public List<string> SearchAdmin(string SearchArgument)
        {
            int UserID = 0;
            string name = "";
            string email = "";
            string status = "";
            string type = "";
            var data = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_SEARCH_USER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SearchArgument", SqlDbType.NVarChar).Value = SearchArgument;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UserID = int.Parse(reader["PartyID"].ToString());
                name = reader["PartyName"].ToString();
                email = reader["PartyEmail"].ToString();
                status = reader["PartyStatus"].ToString();
                type = reader["PartyType"].ToString();
                data.Add(UserID + "|" + name + "|" + email + "|" + status + "|" + type + "|");
            }
            connection.Close();
            return data;

        }
        public void ModifyAdmin(int UserID, string Name, string LastName, string SecondLastName, string Email, string Adress, char Password, bool State, int PartyType)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("A_MODIFY_USER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlateID", SqlDbType.Int).Value = UserID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            cmd.Parameters.Add("@SecondLastName", SqlDbType.NVarChar).Value = SecondLastName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = Adress;
            cmd.Parameters.Add("@Password", SqlDbType.Char).Value = Password;
            cmd.Parameters.Add("@State", SqlDbType.Bit).Value = State;
            cmd.Parameters.Add("@PartyType", SqlDbType.SmallInt).Value = PartyType;


            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}