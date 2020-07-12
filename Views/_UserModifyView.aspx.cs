using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _UserModifyView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Modify_Click(object sender, EventArgs e)
        {
            ModifyUserControl userModify = new ModifyUserControl();

            //if (!userModify.checkPasswordEquality(firstPassword.Text, secondPassword.Text))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Las contraseñas no coinciden!')", true);
            //}
            //else
            //{
            //    Session["ClientID"] = userModify.saveModifyUser(name.Text, adress.Text, firstPassword.Text);
            //}
        }
    }
}