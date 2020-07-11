using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _AdminMainView : System.Web.UI.Page
    {

        public List<string> menu = new List<string> { };
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAdminMenu aMenu = new GetAdminMenu();
            menu = aMenu.GetAdminsMenu();
        }
    }
}