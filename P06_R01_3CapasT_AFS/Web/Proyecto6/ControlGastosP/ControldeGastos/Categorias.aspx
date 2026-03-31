<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Categorias.aspx.cs"
    Inherits="ControlGastosWeb.Categorias" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Categorías</title>
    <link href="<%= ResolveUrl("~/css/usuarios.css") %>" rel="stylesheet" />
    <script>
        function abrirModal() {
            document.getElementById("modalCategoria").style.display = "block";
        }

        function cerrarModal() {
            document.getElementById("modalCategoria").style.display = "none";
        }

        function nuevaCategoria() {
            document.getElementById('<%= hfIdCategoria.ClientID %>').value = "";
            document.getElementById('<%= txtNombre.ClientID %>').value = "";
            document.getElementById('<%= txtDescripcion.ClientID %>').value = "";

            document.getElementById("tituloModal").innerText = "Nueva Categoría";
            abrirModal();
        }
    </script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="topbar">
        <div class="titulo">📂 Categorías</div>
        <asp:Button ID="btnNuevo" runat="server"
            Text="+ Nuevo"
            CssClass="btn-top"
            OnClientClick="nuevaCategoria(); return false;" />
    </div>

    <!-- Mensaje fuera del modal -->
    <asp:Label ID="lblMensajeTabla" runat="server" CssClass="mensaje-tabla"></asp:Label>

    <asp:GridView ID="gvCategorias" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdCategoria"
        CssClass="tabla"
        AlternatingRowStyle-CssClass="filaAlterna"
        OnRowCommand="gvCategorias_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdCategoria" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:ButtonField Text="✏️" CommandName="Editar" HeaderText="Editar" />
            <asp:ButtonField Text="🗑️" CommandName="Eliminar" HeaderText="Eliminar" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnMenu" runat="server" Text="⏎ Menú" CssClass="btn-menu" OnClick="btnMenu_Click" />

    <!-- Modal -->
    <div id="modalCategoria" class="modal">
        <div class="modal-content">
            <h3 id="tituloModal">Nueva Categoría</h3>

            <asp:HiddenField ID="hfIdCategoria" runat="server" />

            <asp:TextBox ID="txtNombre" runat="server" CssClass="input" Placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="input" Placeholder="Descripción"></asp:TextBox>

            <!-- Mensaje dentro del modal -->
            <asp:Label ID="lblMensajeModal" runat="server" CssClass="mensaje-modal"></asp:Label>

            <br />

            <asp:Button ID="btnGuardar" runat="server"
                Text="Guardar"
                CssClass="btn-top"
                OnClick="btnGuardar_Click" />
            <button type="button" class="btn-top" onclick="cerrarModal()">Cerrar</button>
        </div>
    </div>
</form>
</body>
</html>