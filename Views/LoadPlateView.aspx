<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoadPlateView.aspx.cs" Inherits="IF4101_ProyectoFinal.Views.LoadPlateView" %>
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
                        <li><a href="/Views/UploadPlateView.aspx">Añadir plato</a></li>
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
     <div class="container-bg col-md-8 col-md-offset-2 border">
        <h1 align="justify">Añadir plato</h1>
        <div classname="row">
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Ingrese el nomnbre<font color="red">*</font></h4>
                    <asp:TextBox ID="plateName" runat="server" Width="200px" placeholder="Ej: Hamburguesa"></asp:TextBox>
                </div>
            </div>
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Ingrese la descripción<font color="red">*</font></h4>
                    <asp:TextBox ID="plateDescription" runat="server" Width="200px" placeholder="Ej: Hamburguesa con torta de res"></asp:TextBox>
                </div>
            </div>
            <div classname="col-md-4">
                <div align="justify">
                    <h4>Indique la disponibilidad del plato<font color="red">*</font></h4>
                    <asp:TextBox ID="plateStatus" runat="server" Width="200px" placeholder="Ej: true o false"></asp:TextBox>
                </div>
            </div>
        </div>
    <img id="imgpreview" src="" class=" w-50 mt-4  p-2" style="border-width: 0px; visibility: hidden;" />
    <asp:Image ID="imagePlate" runat="server" />
    <asp:Button ID="addButton" runat="server" Text="Añadir" OnClick="Add_Click" />
    <script src="../Content/showImage.js"></script>
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

    <asp:FileUpload ID="FUImage" runat="server" onchange="showpreview(this);" Font-Size="Smaller" />

</asp:Content>
