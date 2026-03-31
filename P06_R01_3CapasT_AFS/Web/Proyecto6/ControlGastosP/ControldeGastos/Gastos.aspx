<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Gastos.aspx.cs"
    Inherits="ControlGastosWeb.Gastos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gastos</title>
    <link href="<%= ResolveUrl("~/css/usuarios.css") %>" rel="stylesheet" />
    <script>
        function abrirModal() {
            document.getElementById("modalGasto").style.display = "block";
        }

        function cerrarModal() {
            document.getElementById("modalGasto").style.display = "none";
        }

        function nuevoGasto() {
            document.getElementById('<%= hfIdGasto.ClientID %>').value = "";
            document.getElementById('<%= txtMonto.ClientID %>').value = "";
            document.getElementById('<%= txtDescripcion.ClientID %>').value = "";
            document.getElementById('<%= ddlUsuario.ClientID %>').selectedIndex = 0;
            document.getElementById('<%= ddlCategoria.ClientID %>').selectedIndex = 0;

            document.getElementById("tituloModal").innerText = "Nuevo Gasto";
            abrirModal();
        }
    </script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="topbar">
        <div class="titulo">💸 Gastos</div>
        <asp:Button ID="btnNuevo" runat="server"
            Text="+ Nuevo"
            CssClass="btn-top"
            OnClientClick="nuevoGasto(); return false;" />
    </div>

    <!-- Mensaje fuera del modal -->
    <asp:Label ID="lblMensajeTabla" runat="server" CssClass="mensaje-tabla"></asp:Label>

    <asp:GridView ID="gvGastos" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdGastos"
        CssClass="tabla"
        AlternatingRowStyle-CssClass="filaAlterna"
        OnRowCommand="gvGastos_RowCommand">
        <Columns>
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
            <asp:BoundField DataField="Monto" HeaderText="Monto" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:ButtonField Text="🗑️" CommandName="Eliminar" HeaderText="Eliminar" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnMenu" runat="server" Text="⏎ Menú" CssClass="btn-menu" OnClick="btnMenu_Click" />

    <!-- MODAL -->
    <div id="modalGasto" class="modal">
        <div class="modal-content">
            <h3 id="tituloModal">Nuevo Gasto</h3>

            <asp:HiddenField ID="hfIdGasto" runat="server" />

            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="input"></asp:DropDownList>
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="input"></asp:DropDownList>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="input" Placeholder="Monto"></asp:TextBox>
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