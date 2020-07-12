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
            String temp = "";

            if (Session["client"] == null)
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
            if (ClientList.SelectedValue == "" || StatesList.SelectedValue == "")
            {
                Response.Write("<script>alert('Debe llenar al menos un espacio');</script>");
            }
            else if (InitialDate.Text == "" && EndDate.Text == "")
            {
                Response.Write("<script>alert('Debe llenar ambos espacios para las fechas');</script>");
            }
            else
            {
                Session["client"] = "$1" + ClientList.SelectedValue;
                Session["initialDate"] = "$2_" + InitialDate.Text;
                Session["endDate"] = "$3_" + EndDate.Text;
                Session["orderStates"] = "$4" + StatesList.SelectedValue;

                Response.Redirect("/Views/_AdminOrdersControl.aspx");
            }
        }
    }
}