<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="IF4101_ProyectoFinal.Views.SignUp" %>

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
                <li><a runat="server" href="~/Contact">Contacto</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-bg col-md-8 col-md-offset-2 border">
        <h1 align="justify">Registrarse</h1>
        <div classname="row">
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Ingrese su nombre<font color="red">*</font></h4>
                    <asp:TextBox ID="fullName" runat="server" Width="200px" placeholder="Ej: Victor"></asp:TextBox>
                </div>
            </div>
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Ingrese su primer apellido<font color="red">*</font></h4>
                    <asp:TextBox ID="lastName" runat="server" Width="200px" placeholder="Ej: Bolaños"></asp:TextBox>
                </div>
            </div>
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Ingrese su segundo apellido<font color="red">*</font></h4>
                    <asp:TextBox ID="secondLastName" runat="server" Width="200px" placeholder="Ej: Corrales"></asp:TextBox>
                </div>
            </div>
        </div>
        <div classname="row">
            <div classname="col-12">
                <div align="justify">
                    <h4>Ingrese su correo electronico<font color="red">*</font></h4>
                    <asp:TextBox ID="email" runat="server" Width="200px" placeholder="Ej: victor.bolanos@ucrso.info"></asp:TextBox>
                </div>
            </div>
        </div>
        <div classname="row">
            <div classname="col-12">
                <div align="justify">
                    <h4>Ingrese su direccion exacta<font color="red">*</font></h4>
                    <asp:TextBox ID="adress" runat="server" Width="200px" placeholder="Ej: 75 mts sur del supermercado"></asp:TextBox>
                </div>
            </div>
        </div>
        <div classname="row">
            <div classname="col-12">
                <div align="justify">
                    <h4>Ingrese su contraseña<font color="red">*</font></h4>
                    <asp:TextBox ID="firstPassword" type="password" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div classname="row">
            <div classname="col-12">
                <div align="justify">
                    <h4>Ingrese su contraseña nuevamente<font color="red">*</font></h4>
                    <asp:TextBox ID="secondPassword" type="password" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div classname="row">
            <h4></h4>
            <asp:Button ID="submitButton" runat="server" Text="Registrarse &raquo;" OnClick="Submit_Click" />
        </div>
    </div>
</asp:Content>
