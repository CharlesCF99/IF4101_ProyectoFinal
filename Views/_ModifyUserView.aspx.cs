using IF4101_ProyectoFinal.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _ModifyUserView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            ModifyUserControl userModify = new ModifyUserControl();

            if (!userModify.checkPasswordEquality(firstPassword.Text, secondPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Las contraseñas no coinciden!')", true);
            }
            else
            {
                userModify.saveModifyUser(name.Text, address.Text, firstPassword.Text);
            }
        }

    }
}