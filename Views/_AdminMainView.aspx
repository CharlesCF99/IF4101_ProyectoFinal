<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_AdminMainView.aspx.cs" Inherits="IF4101_ProyectoFinal.Views._AdminMainView" %>

<asp:Content ID="GeneralNavBar" ContentPlaceHolderID="NavBar" runat="server">
    <div class="row navbar navbar-inverse navbar-static-top">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" runat="server" href="/Views/_AdminMainView.aspx">Restaurante</a>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Administrar <span class="caret"></span></a>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="/Views/_AdminMainView.aspx">Platos</a></li>
                        <li><a href="/Views/LoadPlateView.aspx">Añadir plato</a></li>
                        <li><a href="/Views/_AdminUserControlView.aspx">Usuarios</a></li>
                        <li><a href="/Views/_AdminOrdersControl.aspx">Pedidos</a></li>
                        <li><a href="/Views/_AdminOrderStatus.aspx">Estados</a></li>
                    </ul>
                </li>
                <li><a runat="server" href="~/Views/_AdminUserBlockView">Bloquear clientes</a></li>
                <li><a runat="server" href="~/Views/_LogOut">Salir</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $("#tableSearch").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#myTable tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
</script>
    <div class="container-bg col-md-8 col-md-offset-2">
        <h1>Menu de platos</h1>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
              <%--  <div class="col-md-12 form-inline">
                    <input class="form-control col-md-6" type="text" placeholder="Search" aria-label="Search">
                    <button class="btn btn-elegant btn-rounded col-md-2" type="submit">Buscar</button>
                    <button class="btn btn-elegant btn-rounded col-md-2 offset-md-2" type="submit">Agregar</button>
                </div>--%>
             <%--   <input class="form-control mb-4" id="tableSearch" type="text"
                 placeholder="Type something to search list items">--%>
                <table class="table table-hover">
                    <thead class="thead-dark">
                        <tr class="header">
                            <th scope="col">ID</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Descripcion</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Estado</th>
                        </tr>
                    </thead>
                    <tbody id="myTable">
                        <%foreach (var item in menu)
                            {%>
                        <tr class="pointer" onclick="rowEvent(this)">
                            <td><%=item.Split('|')[0].ToString() %></td>
                            <td><%=item.Split('|')[1].ToString() %></td>
                            <td><%=item.Split('|')[2].ToString() %></td>
                            <td><%=item.Split('|')[4].ToString() %></td>
                            <td><%=item.Split('|')[3].ToString() %></td>
                            <%--<td>
                                <button type="button" class="btn btn-danger"><i class="far fa-trash-alt"></i></button>
                            </td>--%>
                        </tr>
                        <%}%>
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
