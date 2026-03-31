<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="ControlGastosWeb.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>

   
    <link href="<%= ResolveUrl("~/css/Login.css") %>" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Orbitron:wght@500;700&display=swap" rel="stylesheet">

    <script>
        function animarError() {
            let caja = document.querySelector(".login-container");
            caja.style.animation = "shake 0.4s";

            setTimeout(() => {
                caja.style.animation = "fadeIn 0.8s";
            }, 400);
        }
    </script>


    <style>
        /* ANIMACIÓN DE ERROR */
        @keyframes shake {
            0% { transform: translateX(0); }
            25% { transform: translateX(-5px); }
            50% { transform: translateX(5px); }
            75% { transform: translateX(-5px); }
            100% { transform: translateX(0); }
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <div class="login-container">

        <h2 class="titulo-login">CONTROL DE GASTOS</h2>

        <asp:TextBox ID="txtEmail" runat="server"
            CssClass="input"
            Placeholder="Correo"></asp:TextBox>

        <asp:TextBox ID="txtPassword" runat="server"
            CssClass="input"
            TextMode="Password"
            Placeholder="Contraseña"></asp:TextBox>

        <asp:Button ID="btnLogin" runat="server"
            Text="Ingresar"
            CssClass="btn-login"
            OnClick="btnLogin_Click" />

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

    </div>

</form>
</body>
</html>