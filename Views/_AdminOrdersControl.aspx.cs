using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _AdminOrdersControl : System.Web.UI.Page
    {
        public List<string> menu = new List<string> { };
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientList.Items.Insert(0, new ListItem("--Select--", "0"));

            String temp = "";

            if (Session["client"] == "")
            {
                Session["client"] = "";
                Session["initialDate"] = "";
                Session["endDate"] = "";
                Session["orderStates"] = "";
            }

            temp = Session["client"].ToString() + Session["initialDate"].ToString() + Session["endDate"].ToString() + Session["orderStates"].ToString();

            Controls.GetOrderList aMenu = new Controls.GetOrderList();
            menu = aMenu.GetOrdersList(temp);

            Session.Contents.Remove("client");
            Session.Contents.Remove("initialDate");
            Session.Contents.Remove("endDate");
            Session.Contents.Remove("orderStates");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String orderStates = "";

            for (int i = 0; i < StatesList.Items.Count; i++)
            {
                if (StatesList.Items[i].Selected == true)
                {
                    orderStates += StatesList.Items[i].Text + "|";
                }
            }

            Session["client"] = "$1_" + ClientList.SelectedIndex;
            Session["initialDate"] = "$2_" + InitialDate.Text;
            Session["endDate"] = "$3_" + EndDate.Text;
            Session["orderStates"] = "$4_" + orderStates;

            Response.Redirect("/Views/_AdminOrdersControl.aspx");
        }
    }
}