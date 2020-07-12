using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _UserOrderView : System.Web.UI.Page
    {
        public List<string> orders = new List<string> { };
        ManageOrders cOrders = new ManageOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            orders = cOrders.GetUserOrderList((int)Session["ID"]);
        }
    }
}