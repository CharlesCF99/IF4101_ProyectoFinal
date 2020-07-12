<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_UserMainView.aspx.cs" Inherits="IF4101_ProyectoFinal.Views._UserMainView" %>

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
                <li><a runat="server" href="~/Views/_UserMainView">Menú principal</a></li>
                <li><a runat="server" href="~/Views/_UserOrderView">Revisar pedido</a></li>
                <li><a runat="server" href="~/Views/_ModifyUserView">Administrar datos personales</a></li>
                <li><a runat="server" href="~/Views/_LogOut">Salir</a></li>
            </ul>
        </div>
    </div>
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function rowEvent(x) {
            alert("Page is loaded" + x.rowIndex);
            location.href = "../Views/_KitchenEmployeeMainView";

        }
    </script>

    <div class="container-bg col-md-8 col-md-offset-2">
        <h1 align="justify">Menu principal</h1>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <table class="table table-hover" id="myTable">
                    <thead class="thead-dark">
                        <tr class="header">
                            <th scope="col">ID</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var item in menu)
                            {%>
                        <tr class="pointer" onclick="rowEvent(this)">
                            <td><%=item.Split('|')[0].ToString() %></td>
                            <td><%=item.Split('|')[1].ToString() %></td>
                            <td><%=item.Split('|')[2].ToString() %></td>
                            <td>
                                <button type="button" class="btn btn-danger"><i class="far fa-trash-alt"></i></button>
                            </td>
                        </tr>
                        <%}%>
                        <%--                        <script type="text/javascript">
                            function createRows() {

                               menu.

                                for (var i = 0; i < 5; i++) {
                                
                                    alert("Page is loaded");
                               
                                }
                                
                            }
                            window.onload = createRows;
                        </script>--%>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <h4></h4>
            <%--<asp:Button ID="submitButton" runat="server" Text="Ingresar &raquo;" OnClick="Submit_Click" />--%>
        </div>
    </div>
</asp:Content>
