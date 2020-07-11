using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _UserMainView : Page
    {
        public List<string> menu = new List<string> { };
        protected void Page_Load(object sender, EventArgs e)
        {
            GetClientMenu cMenu = new GetClientMenu();
            menu = cMenu.GetClientsMenu();
        }
    }
}