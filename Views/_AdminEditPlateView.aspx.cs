﻿using System;
using IF4101_ProyectoFinal.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class _AdminEditPlateView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add_Click(object sender, EventArgs e)
        {
            GetPlate addPlate = new GetPlate();
            Response.Redirect("../Views/_AdminMainView.aspx");
        }
    }
}