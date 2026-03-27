<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="TransportesWeb.Choferes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <h1>🧑‍✈️ Gestión de Choferes</h1>

    <!-- FILTROS Y BOTONES -->
    <div class="filtros mb-3">
        <label>Filtrar por:</label>
        <asp:DropDownList ID="ddlFiltro" runat="server">
            <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
            <asp:ListItem Value="1">Disponibles</asp:ListItem>
            <asp:ListItem Value="2">No Disponibles</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary ms-2" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-secondary ms-2" />
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Chofer" CssClass="btn btn-success ms-2" OnClick="btnNuevo_Click" />
    </div>

    <!-- MENSAJES -->
    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="mb-3">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>

    <!-- GRID -->
    <asp:GridView ID="gvChoferes" runat="server"
        CssClass="table table-striped table-hover table-bordered"
        AutoGenerateColumns="False"
        AllowPaging="true" PageSize="10"
        OnPageIndexChanging="gvChoferes_PageIndexChanging"
        OnRowCommand="gvChoferes_RowCommand">

        <HeaderStyle CssClass="table-dark" />
        <PagerStyle CssClass="pagination-ys" />

        <Columns>
            <asp:BoundField DataField="IdChofer" HeaderText="ID" />
            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Licencia" HeaderText="Licencia" />

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <span class='badge <%# (bool)Eval("Disponibilidad") ? "bg-success" : "bg-danger" %>'>
                        <%# (bool)Eval("Disponibilidad") ? "Disponible" : "No Disponible" %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# Eval("IdChofer") %>'
                        CssClass="btn btn-warning btn-sm" />

                    <asp:Button runat="server" Text="Eliminar"
                        CommandName="Eliminar"
                        CommandArgument='<%# Eval("IdChofer") %>'
                        CssClass="btn btn-danger btn-sm"
                        OnClientClick="return confirm('¿Eliminar chofer?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- MODAL CON SCROLL -->
    <asp:Panel ID="pnlModal" runat="server" Visible="false"
        Style="position:fixed; 
               top:50%; left:50%; 
               transform:translate(-50%, -50%);
               width:420px; 
               max-height:80vh; 
               overflow-y:auto;
               background:white; 
               border:1px solid black; 
               padding:20px; 
               z-index:1000;">

        <h4>Datos del Chofer</h4>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Id Chofer:</label>
            <asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Ap. Paterno:</label>
            <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Ap. Materno:</label>
            <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Fec. Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px; margin-right:10px;">Licencia:</label>
            <asp:TextBox ID="txtLicencia" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2">
            <asp:CheckBox ID="chkDisponible" runat="server" Text="Disponible" />
        </div>

        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
            CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar"
            CssClass="btn btn-secondary ms-2" OnClick="btnCerrar_Click" />

    </asp:Panel>

</div>

</asp:Content>