<%@ Page Language="C#" MasterPageFile="~/jvserrinox.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="jvserrinox.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/site.css" rel="stylesheet">

    <link rel="stylesheet" href="css/feature-carousel.css" charset="utf-8" />
    <script src="js/jquery-1.7.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.featureCarousel.min.js" type="text/javascript" charset="utf-8"></script>

    <link rel="stylesheet" type="text/css" href="css/style.css?version=new" />

    <script type="text/javascript" src="js/jquery-ui-1.9.0.custom.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-tabs-rotate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#featured").tabs({ fx: { opacity: "toggle" } }).tabs("rotate", 5000, true);
        });
    </script>
    <link href='http://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'>

    <center>
    <div id="featured">
        <ul class="ui-tabs-nav">
            <asp:Repeater ID="rptImgSmall" runat="server">
                <ItemTemplate>
                    <li class="ui-tabs-nav-item" id=<%# "nav-fragment-" + Eval("CodProduto") %>><a href=<%# "\"#fragment-" + Eval("CodProduto") + "\"" %>>
                    <img src=<%# Eval("CaminhoImagemTemp") %> alt="" /><span><%# Eval("Nome") %></span></a></li>
                </ItemTemplate>
            </asp:Repeater>
           <%-- <li class="ui-tabs-nav-item" id="nav-fragment-1"><a href="#fragment-1">
                <img src="images/galeriaProdutos/portao1_Small.jpg" alt="" /><span>Portão fechado com abertura superior</span></a></li>
            <li class="ui-tabs-nav-item" id="nav-fragment-2"><a href="#fragment-2">
                <img src="images/galeriaProdutos/portao2_Small.jpg" alt="" /><span>Portão fechado com abertura superior e inferior</span></a></li>
            <li class="ui-tabs-nav-item" id="nav-fragment-3"><a href="#fragment-3">
                <img src="images/galeriaProdutos/portao3_Small.jpg" alt="" /><span>Portão com abertura total</span></a></li>
            <li class="ui-tabs-nav-item" id="nav-fragment-4"><a href="#fragment-4">
                <img src="images/galeriaProdutos/portao4_Small.jpg" alt="" /><span>Portão com chapas horizontais</span></a></li>
            <li class="ui-tabs-nav-item" id="nav-fragment-5"><a href="#fragment-5">
                <img src="images/galeriaProdutos/portao5_Small.jpg" alt="" /><span>Portão totalmente fechado</span></a></li>
            <li class="ui-tabs-nav-item" id="nav-fragment-6"><a href="#fragment-6">
                <img src="images/galeriaProdutos/CascataLB_Small.jpg" alt="" /><span>Portão totalmente fechado</span></a></li>--%>
        </ul>

        <!-- First Content -->
        <asp:Repeater ID="rptImgLarge" runat="server">
            <ItemTemplate>
                 <div id=<%# "fragment-" + Eval("CodProduto") %> class="ui-tabs-panel ui-tabs-hide" style="">
                <img src=<%# Eval("CaminhoImagemTemp") %> alt="" />
                <div class="info">
                    <h2><a href="#"><%# Eval("Nome") %></a></h2>
                </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--<div id="fragment-1" class="ui-tabs-panel" style="">
            <img src="images/galeriaProdutos/portao1_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão fechado com abertura superior</a></h2>
            </div>
        </div>

        <!-- Second Content -->
        <div id="fragment-2" class="ui-tabs-panel ui-tabs-hide" style="">
            <img src="images/galeriaProdutos/portao2_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão fechado com abertura superior e inferior</a></h2>
            </div>
        </div>

        <!-- Third Content -->
        <div id="fragment-3" class="ui-tabs-panel ui-tabs-hide" style="">
            <img src="images/galeriaProdutos/portao3_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão com abertura total</a></h2>
            </div>
        </div>

        <!-- Fourth Content -->
        <div id="fragment-4" class="ui-tabs-panel ui-tabs-hide" style="">
            <img src="images/galeriaProdutos/portao4_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão com chapas horizontais</a></h2>
            </div>
        </div>

         <!-- Fourth Content -->
        <div id="fragment-5" class="ui-tabs-panel ui-tabs-hide" style="">
            <img src="images/galeriaProdutos/portao5_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão totalmente fechado</a></h2>
            </div>
        </div>
          <div id="fragment-6" class="ui-tabs-panel ui-tabs-hide" style="">
            <img src="images/galeriaProdutos/CascataLB_Large.jpg" alt="" />
            <div class="info">
                <h2><a href="#">Portão totalmente fechado</a></h2>
            </div>
        </div>--%>
    </div>
        </center>
</asp:Content>
