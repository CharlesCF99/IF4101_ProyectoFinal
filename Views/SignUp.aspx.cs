using IF4101_ProyectoFinal.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace IF4101_ProyectoFinal.Views
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SignUpControl suControl = new SignUpControl();

            if (suControl.checkEmailAvailability(email.Text) > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El email ya se encuentra registrado!')", true);
            }
            else if (!suControl.checkPasswordEquality(firstPassword.Text, secondPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Las contraseñas no coinciden!')", true);
            }
            else {
                Session["ClientID"] = suControl.saveToDB(fullName.Text, lastName.Text, secondLastName.Text, email.Text, adress.Text, firstPassword.Text);

            }
        }
    }
}