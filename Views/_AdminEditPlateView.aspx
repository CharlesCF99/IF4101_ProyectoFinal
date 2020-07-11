<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_AdminEditPlateView.aspx.cs" Inherits="IF4101_ProyectoFinal.Views._AdminEditPlateView" %>

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

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
