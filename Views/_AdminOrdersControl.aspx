<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_AdminOrdersControl.aspx.cs" Inherits="IF4101_ProyectoFinal.Views._AdminOrdersControl" %>

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
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Administrar <span class="caret"></span></a>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="/Views/_AdminMainView.aspx">Platos</a></li>
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
        <h1 align="justify">Menú de pedidos</h1>
        <h2 align="justify">¿Desea filtrar los resultados?</h2>
        <p align="justify">&nbsp;</p>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <table class="table table-hover">
                    <thead class="thead-dark">
                        <tr class="header">
                            <th scope="col">Cliente</th>
                            <th scope="col">Fecha</th>
                            <th scope="col">Estado</th>
                        </tr>
                    </thead>
                    <tbody id="myTable">
                        <%foreach (var item in menu)
                            {%>
                        <tr class="pointer" onclick="rowEvent(this)">
                            <td style="height: 36px"><%=item.Split('|')[1].ToString() %></td>
                            <td style="height: 36px"><%=item.Split('|')[2].ToString() %></td>
                            <td style="height: 36px"><%=item.Split('|')[3].ToString() %></td>
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
            <div style="text-align: justify;">
                <h3>¿Desea filtrar los resultados?</h3>
                <h4>Por cliente: </h4>
                <asp:RadioButtonList ID="ClientList" runat="server" DataSourceID="ClientNames" DataTextField="PartyName" DataValueField="PartyName">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="ClientNames" runat="server" ConnectionString="<%$ ConnectionStrings:4101_ProyectoFinalConnectionString1 %>" SelectCommand="A_GET_ALL_USERS" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <h4>En un rango de fechas: </h4>
                <h5>Fecha inicial:</h5>
                <p>
                    <asp:TextBox ID="InitialDate" runat="server" TextMode="Date"></asp:TextBox>
                </p>
                <h5>Fecha final:</h5>
                <p>
                    <asp:TextBox ID="EndDate" runat="server" TextMode="Date"></asp:TextBox>
                </p>
                <h4>Por estado: </h4>
                <p>
                    <asp:RadioButtonList ID="StatesList" runat="server" DataSourceID="OrderStatus" DataTextField="OrderStatusDescription" DataValueField="OrderStatusDescription">
                    </asp:RadioButtonList>
                    <asp:SqlDataSource ID="OrderStatus" runat="server" ConnectionString="<%$ ConnectionStrings:4101_ProyectoFinalConnectionString1 %>" SelectCommand="SELECT [OrderStatusDescription] FROM [OrderStatus]"></asp:SqlDataSource>
                </p>
                <p>
                    <asp:Button ID="FilterButton" runat="server" OnClick="Button1_Click" Text="Filtrar" />
                </p>
            </div>
            <%--<asp:Button ID="submitButton" runat="server" Text="Ingresar &raquo;" OnClick="Submit_Click" />--%>
        </div>
    </div>
</asp:Content>
