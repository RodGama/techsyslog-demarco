<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.TechsysLog.Login" %>

<!DOCTYPE html>

<html lang="pt">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Meu aplicativo ASP.NET</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <link rel="apple-touch-icon" sizes="180x180" href="./assets/images/favicon/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="./assets/images/favicon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="./assets/images/favicon/favicon-16x16.png">
    <link rel="mask-icon" href="./assets/images/favicon/safari-pinned-tab.svg" color="#5bbad5">
    <meta name="msapplication-TileColor" content="#da532c">
    <meta name="theme-color" content="#ffffff">

    <!-- Google Font-->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Overpass:wght@200;300;400;600&display=swap" rel="stylesheet">

    <!-- Vendor CSS -->
    <link rel="stylesheet" href="~/content/assets/css/libs.bundle.css" />

    <!-- Main CSS -->
    <link rel="stylesheet" href="~/content/assets/css/theme.bundle.css" />

    <!-- Fix for custom scrollbar if JS is disabled-->
    <noscript>
        <style>
            /**
          * Reinstate scrolling for non-JS clients
          */
            .simplebar-content-wrapper {
                overflow: auto;
            }
        </style>
    </noscript>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body class="">
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <section class="d-flex justify-content-center align-items-start vh-100 py-5 px-3 px-md-0">

            <!-- Login Form-->
            <div class="d-flex flex-column w-100 align-items-center">

                <!-- Logo-->
                <a href="/" class="d-table mt-5 mb-4 mx-auto">
                    <div class="d-flex align-items-center justify-content-center">

                        <span class="fw-bold fs-3 text-white">TechsysLog</span>
                    </div>
                </a>
                <!-- Logo-->

                <div class="shadow-lg rounded p-4 p-sm-5 bg-white form">
                    <h5 class="fw-bold text-muted">Login</h5>
                    <p class="text-muted">Bem vindo!</p>

                    <!-- Login Form-->
                    <div runat="server" class="mt-4">

                        <asp:Literal runat="server" ID="ErrorList"/>

                        <div class="form-group">
                            <label class="form-label form-label-light" for="login-email">Email</label>
                            <asp:TextBox ID="email" runat="server" type="email" class="form-control form-control-light" placeholder="name@email.com"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="password" runat="server" type="password" class="form-control form-control-light" placeholder="Senha"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" type="submit" Text="Login" class="btn btn-primary d-block w-100 my-4" />
                    </div>
                    <!-- / Login Form -->

                    <p class="d-block text-center text-muted small">
                        Novo aqui? <a class=" text-decoration-underline"
                            href="./signup">Crie sua conta</a>
                    </p>
                </div>
            </div>
            <!-- / Login Form-->

        </section>
        <!-- / Main Section-->

        <!-- Theme JS -->
        <!-- Vendor JS -->
        <script src="./assets/js/vendor.bundle.js"></script>

        <!-- Theme JS -->
        <script src="./assets/js/theme.bundle.js"></script>
    </form>
</body>
</html>
