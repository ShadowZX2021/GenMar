<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ControlGastosWeb.Usuarios" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Usuarios</title>
    <link href="<%= ResolveUrl("~/css/usuarios.css") %>" rel="stylesheet" />

    <script>
        function abrirModal() {
            document.getElementById("modalUsuario").style.display = "block";
        }

        function cerrarModal() {
            document.getElementById("modalUsuario").style.display = "none";
        }

        function nuevoUsuario() {
            document.getElementById('<%= hfIdUsuario.ClientID %>').value = "";
            document.getElementById('<%= txtNombre.ClientID %>').value = "";
            document.getElementById('<%= txtEmail.ClientID %>').value = "";
            document.getElementById('<%= txtPassword.ClientID %>').value = "";
            document.getElementById('<%= ddlDatos.ClientID %>').selectedIndex = 0;
            document.getElementById("tituloModal").innerText = "Nuevo Usuario";
            abrirModal();
        }
    </script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="topbar">
        <div class="titulo">👤 Usuarios</div>
        <asp:Button ID="btnNuevo" runat="server"
            Text="+ Nuevo"
            CssClass="btn-top"
            OnClientClick="nuevoUsuario(); return false;" />
    </div>

    <!-- Mensajes fuera del modal -->
    <asp:Label ID="lblMensajeTabla" runat="server" CssClass="mensaje-tabla"></asp:Label>

    <asp:GridView ID="gvUsuarios" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdUsuario"
        CssClass="tabla"
        AlternatingRowStyle-CssClass="filaAlterna"
        OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdUsuario" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:ButtonField Text="✏️" CommandName="Editar" HeaderText="Editar" />
            <asp:ButtonField Text="🗑️" CommandName="Eliminar" HeaderText="Eliminar" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnMenu" runat="server" Text="⏎ Menú" CssClass="btn-menu" OnClick="btnMenu_Click" />

    <!-- Modal -->
    <div id="modalUsuario" class="modal">
        <div class="modal-content">
            <h3 id="tituloModal">Nuevo Usuario</h3>

            <asp:HiddenField ID="hfIdUsuario" runat="server" />
            <asp:DropDownList ID="ddlDatos" runat="server" CssClass="input"></asp:DropDownList>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input" Placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" Placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" Placeholder="Password"></asp:TextBox>

            <!-- Mensaje dentro del modal -->
            <asp:Label ID="lblMensajeModal" runat="server" CssClass="mensaje-modal"></asp:Label>

            <br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn-top" OnClick="btnGuardar_Click" />
            <button type="button" class="btn-top" onclick="cerrarModal()">Cerrar</button>
        </div>
    </div>
</form>
</body>
</html>