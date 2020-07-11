using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _KitchenEmployeeMainView : System.Web.UI.Page
    {
        public List<string> activeOrders = new List<string> { };
        int dbID = -1;
        Controls.ManageOrders aOrders = new Controls.ManageOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderCompleted"] == null)
            {
                activeOrders = aOrders.GetActiveOrdersList();
            }
            else
            {
                IDConverter idConverter = new IDConverter();
                dbID = idConverter.convertRowIDToDbID(activeOrders, (int)Session["OrderCompleted"]);
                aOrders.setOrderAsDelivered(dbID);
                activeOrders = aOrders.GetActiveOrdersList();
            }
        }

        protected void UndoButton_Click(object sender, EventArgs e)
        {
            if (dbID != 1)
            {
                aOrders.setOrderAsNoDelivered(dbID);
                Response.Redirect("../Views/_KitchenEmployeeMainView.aspx");
            }
        }
    }
}