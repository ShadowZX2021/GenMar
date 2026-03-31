<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ControldeGastos.Menu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Menú</title>
    <link href="<%= ResolveUrl("~/css/Menu.css") %>" rel="stylesheet" />

   
</head>

<body>
    <form id="form1" runat="server">

        <div class="sidebar">
            <h2>CONTROL</h2>

            <asp:Button ID="btnUsuarios" runat="server" Text="👤 Usuarios" CssClass="menu-btn" OnClick="btnUsuarios_Click" />
            <asp:Button ID="btnCategorias" runat="server" Text="🗂️ Categorías" CssClass="menu-btn" OnClick="btnCategorias_Click" />
            <asp:Button ID="btnGastos" runat="server" Text="💸 Gastos" CssClass="menu-btn" OnClick="btnGastos_Click" />
            <asp:Button ID="btnDatos" runat="server" Text="📄 Datos Personales" CssClass="menu-btn" OnClick="btnDatos_Click" />

            <div class="logout">
                <asp:Button ID="btnLogout" runat="server" Text="🚪 Cerrar sesión" CssClass="menu-btn" OnClick="btnLogout_Click" />
            </div>
        </div>

        <div class="contenido">
            <h1>Bienvenido</h1>
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </div>

        <!-- AVISO FIJO EN ESQUINA INFERIOR IZQUIERDA -->
        <div class="aviso">
            Proyecto: ControlGastosWeb | Autor: Andrés Ferrer Servin
        </div>

    </form>
</body>
</html>