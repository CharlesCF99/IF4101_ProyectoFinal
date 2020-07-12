<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_KitchenEmployeeMainView.aspx.cs" Inherits="IF4101_ProyectoFinal.Views._KitchenEmployeeMainView" %>

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
                <li><a runat="server" href="~/Views/_LogOut">Salir</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-bg col-md-8 col-md-offset-2">
        <h1 align="justify">Lista de ordenes</h1>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <table class="table table-hover" id="myTable">
                    <thead class="thead-dark">
                        <tr class="header">
                            <th scope="col">Cliente</th>
                            <th scope="col">Platos pedidos</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var item in activeOrders)
                            {%>
                        <tr class="pointer">
                            <td><%=item.Split('|')[1].ToString() %></td>
                            <td><%=item.Split('|')[2].ToString() %></td>
                            <td>
                                <a href="../Views/_KitchenEmployeeMainView?id=<%=item.Split('|')[0].ToString() %>">Entregado</a>
                            </td>
                        </tr>
                        <%}%>
                    </tbody>
                </table>
                <asp:Button ID="UndoButton" runat="server" Text="Deshacer" OnClick="UndoButton_Click" class="btn btn-danger" />
            </div>
        </div>
        <div class="row">
            <h4></h4>
        </div>
    </div>
</asp:Content>
