using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Button = System.Web.UI.WebControls.Button;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _KitchenEmployeeMainView : System.Web.UI.Page
    {
        public List<string> activeOrders = new List<string> { };
        ManageOrders aOrders = new ManageOrders();
        public int ordenesOcultas = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (aOrders.GetActiveOrdersList().Count > 6)
            {
                ordenesOcultas = aOrders.GetActiveOrdersList().Count - 6;
            }

            if (Request.QueryString["id"] == null)
            {
                activeOrders = new List<string> { };
                activeOrders = aOrders.GetActiveOrdersList();
            }
            else
            {
                activeOrders = new List<string> { };
                aOrders.setOrderAsDelivered(Convert.ToInt32(Request.QueryString["id"].ToString()));
                activeOrders = aOrders.GetActiveOrdersList();
            }
        }

        protected void UndoButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                activeOrders = new List<string> { };
                aOrders.setOrderAsNoDelivered(Convert.ToInt32(Request.QueryString["id"].ToString()));
                Response.Redirect("../Views/_KitchenEmployeeMainView.aspx");
            }
        }
    }
}