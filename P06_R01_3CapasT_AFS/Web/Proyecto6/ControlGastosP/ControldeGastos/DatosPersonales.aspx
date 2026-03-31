<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="DatosPersonales.aspx.cs"
    Inherits="ControlGastosWeb.DatosPersonales" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Datos Personales</title>
    <link href="<%= ResolveUrl("~/css/usuarios.css") %>" rel="stylesheet" />
    <script>
        function abrirModal() {
            document.getElementById("modalDatos").style.display = "block";
        }

        function cerrarModal() {
            document.getElementById("modalDatos").style.display = "none";
        }

        function nuevoDato() {
            document.getElementById('<%= hfIdDatos.ClientID %>').value = "";
            document.getElementById('<%= txtNombre.ClientID %>').value = "";
            document.getElementById('<%= txtApPaterno.ClientID %>').value = "";
            document.getElementById('<%= txtApMaterno.ClientID %>').value = "";
            document.getElementById('<%= txtTelefono.ClientID %>').value = "";
            document.getElementById('<%= txtDireccion.ClientID %>').value = "";

            document.getElementById("tituloModal").innerText = "Nuevo Dato Personal";
            abrirModal();
        }
    </script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="topbar">
        <div class="titulo">📝 Datos Personales</div>
        <asp:Button ID="btnNuevo" runat="server"
            Text="+ Nuevo"
            CssClass="btn-top"
            OnClientClick="nuevoDato(); return false;" />
    </div>

    <!-- Mensajes generales (fuera del modal) -->
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

    <asp:GridView ID="gvDatos" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdDatos"
        CssClass="tabla"
        AlternatingRowStyle-CssClass="filaAlterna"
        OnRowCommand="gvDatos_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdDatos" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="ApPaterno" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="ApMaterno" HeaderText="Apellido Materno" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            <asp:ButtonField Text="✏️" CommandName="Editar" HeaderText="Editar" />
            <asp:ButtonField Text="🗑️" CommandName="Eliminar" HeaderText="Eliminar" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnMenu" runat="server" Text="⏎ Menú" CssClass="btn-menu" OnClick="btnMenu_Click" />

    <!-- MODAL -->
    <div id="modalDatos" class="modal">
        <div class="modal-content">
            <h3 id="tituloModal">Nuevo Dato Personal</h3>

            <!-- Mensaje de validación dentro del modal -->
            <asp:Label ID="lblModalMensaje" runat="server" CssClass="modal-mensaje"></asp:Label>

            <asp:HiddenField ID="hfIdDatos" runat="server" />

            <asp:TextBox ID="txtNombre" runat="server" CssClass="input" Placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtApPaterno" runat="server" CssClass="input" Placeholder="Apellido Paterno"></asp:TextBox>
            <asp:TextBox ID="txtApMaterno" runat="server" CssClass="input" Placeholder="Apellido Materno"></asp:TextBox>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="input" Placeholder="Teléfono"></asp:TextBox>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="input" Placeholder="Dirección"></asp:TextBox>

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