<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="_UserOrderView.aspx.cs" inherits="IF4101_ProyectoFinal.Views._UserMainView" %>

<asp:Content ID="GeneralNavBar" ContentPlaceHolderID="NavBar" runat="server">
    <div class="row navbar navbar-inverse navbar-static-top">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" runat="server" href="~/">Restaurante</a>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li><a runat="server" href="~/Views/_UserMainView">Menu principal</a></li>
                <li><a runat="server" href="~/Views/_UserOrderView">Revisar pedido</a></li>
                <li><a runat="server" href="~/Views/_UserPersonalDataView">Datos personales</a></li>
                <li><a runat="server" href="~/Views/_LogOut">Salir</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-bg col-md-8 col-md-offset-2">
        <h1 align="justify">Descripción de la órden</h1>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <table class="table table-hover" id="myTable">
                    <thead class="thead-dark">
                        <tr class="header">
                            <th scope="col">Nombre</th>
                            <th scope="col">Precio</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Mark</td>
                            <td>1000</td>
                        </tr>
                        <tr>
                            <td>Fred</td>
                            <td>2000</td>
                        </tr>
                        <%--{userListVisual}--%>
                    </tbody>
                </table>
            </div>
        </div>
        <div classname="row">
            <h4></h4>
            <%--<asp:Button ID="submitButton" runat="server" Text="Ingresar &raquo;" OnClick="Submit_Click" />--%>
        </div>
    </div>
</asp:Content>
