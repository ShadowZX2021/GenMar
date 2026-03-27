<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rutas.aspx.cs" Inherits="TransportesWeb.Rutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <h1>🛣️ Gestión de Rutas</h1>

    <!-- FILTROS Y BOTONES -->
    <div class="mb-3 d-flex align-items-center">
        <label class="me-2">Filtrar por estado:</label>
        <asp:DropDownList ID="ddlEstadoFiltro" runat="server" CssClass="form-select me-2">
            <asp:ListItem Value="-1" Selected="True">Todos</asp:ListItem>
            <asp:ListItem Value="1">A Tiempo</asp:ListItem>
            <asp:ListItem Value="0">Retrasado</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary me-2" OnClick="btnFiltrar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary me-2" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnNuevo" runat="server" Text="Nueva Ruta" CssClass="btn btn-success" OnClick="btnNuevo_Click" />
    </div>

    <!-- MENSAJES -->
    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="mb-3">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>

    <!-- GRID DE RUTAS -->
    <asp:GridView ID="gvRutas" runat="server"
        CssClass="table table-striped table-hover table-bordered"
        AutoGenerateColumns="False"
        AllowPaging="true" PageSize="10"
        OnPageIndexChanging="gvRutas_PageIndexChanging"
        OnRowCommand="gvRutas_RowCommand">

        <HeaderStyle CssClass="table-dark" />

        <Columns>
            <asp:BoundField DataField="IdRuta" HeaderText="ID" />
            <asp:BoundField DataField="NombreChofer" HeaderText="Chofer" />
            <asp:BoundField DataField="Matricula" HeaderText="Camión" />
            <asp:BoundField DataField="Origen" HeaderText="Origen" />
            <asp:BoundField DataField="Destino" HeaderText="Destino" />
            <asp:BoundField DataField="FechaSalida" HeaderText="Salida" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="FechaLlegada" HeaderText="Llegada" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="Distancia" HeaderText="Distancia (km)" DataFormatString="{0:N2}" />

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <span class='badge <%# (bool)Eval("ATiempo") ? "bg-success" : "bg-danger" %>'>
                        <%# (bool)Eval("ATiempo") ? "A Tiempo" : "Retrasado" %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm"
                        CommandName="Editar" CommandArgument='<%# Eval("IdRuta") %>' />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm"
                        CommandName="Eliminar" CommandArgument='<%# Eval("IdRuta") %>'
                        OnClientClick="return confirm('¿Eliminar esta ruta?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- MODAL CON SCROLL -->
    <asp:Panel ID="pnlModal" runat="server" Visible="false"
        Style="position:fixed; 
               top:50%; left:50%; 
               transform:translate(-50%, -50%);
               width:500px; 
               max-height:80vh; 
               overflow-y:auto;
               background:white; 
               border:1px solid black; 
               padding:20px; 
               z-index:1000;">
        <h4>Datos de la Ruta</h4>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Id Ruta:</label>
            <asp:TextBox ID="txtIdRuta" runat="server" ReadOnly="true" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Chofer:</label>
            <asp:DropDownList ID="ddlChofer" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Camión:</label>
            <asp:DropDownList ID="ddlCamion" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Origen:</label>
            <asp:TextBox ID="txtOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Destino:</label>
            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Fecha Salida:</label>
            <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="DateTimeLocal" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Fecha Llegada:</label>
            <asp:TextBox ID="txtFechaLlegada" runat="server" CssClass="form-control" TextMode="DateTimeLocal" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:140px;">Distancia (km):</label>
            <asp:TextBox ID="txtDistancia" runat="server" CssClass="form-control" TextMode="Number" />
        </div>

        <div class="mb-2">
            <asp:CheckBox ID="chkATiempo" runat="server" Text="A Tiempo" />
        </div>

        <br />

        <asp:Button ID="btnGuardarRuta" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarRuta_Click" />
        <asp:Button ID="btnCerrarRuta" runat="server" Text="Cerrar" CssClass="btn btn-secondary ms-2" OnClick="btnCerrarRuta_Click" />
    </asp:Panel>

</div>

</asp:Content>