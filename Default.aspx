<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IF4101_ProyectoFinal._Default" %>

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
                    <li><a runat="server" href="~/">Inicio</a></li>
                    <li><a runat="server" href="~/Views/Login">Ingresar</a></li>
                    <li><a runat="server" href="~/Views/SignUp">Registrarse</a></li>
                </ul>
            </div>
        </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Proyecto lenguajes de aplicaciones comerciales</h2>
        <p class="lead">Victor Hugo Bolaños Corrales - B61113</p>
        <p class="lead">Pedro Rodriguez Diaz - B72592</p>
        <p class="lead">Maria Ramirez Hernandes - B65716</p>
        <p class="lead">Carlos Cabezas Fallas - B71356</p>
        <p class="lead">Jonathan Orozco Perez - B65152</p>
    </div>   
</asp:Content>
