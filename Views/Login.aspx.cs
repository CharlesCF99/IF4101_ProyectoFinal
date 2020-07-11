using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace IF4101_ProyectoFinal.Views
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            LoginControl loControl = new LoginControl();

            Tuple<int, string, string, string, string, int> userData = loControl.checkUserData(email.Text, password.Text);

            if (userData.Item6 == 0) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se ha encontrado un usuario con dichos datos!')", true);
            }
            else
            {
                Session["ID"] = userData.Item1;
                Session["Name"] = userData.Item2;
                Session["LastName"] = userData.Item3;
                Session["SecondLastName"] = userData.Item4;
                Session["Adress"] = userData.Item5;
                Session["PartyTypeFK"] = userData.Item6;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bienvenid@!')", true);
                if (userData.Item6 == 1)
                {
                    Response.Redirect("../Views/_AdminMainView.aspx");
                } else if (userData.Item6 == 1) {
                    Response.Redirect("../Views/_KitchenMainView.aspx");
                } else
                {
                    Response.Redirect("../Views/_UserMainView.aspx");
                }
            }

            //if (suControl.checkEmailAvailability(email.Text) > 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El email ya se encuentra registrado!')", true);
            //}
            //else if (!suControl.checkPasswordEquality(firstPassword.Text, secondPassword.Text))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Las contraseñas no coinciden!')", true);
            //}
            //else
            //{
            //    Session["ClientID"] = suControl.saveToDB(fullName.Text, lastName.Text, secondLastName.Text, email.Text, adress.Text, firstPassword.Text);
            //}
        }
    }
}