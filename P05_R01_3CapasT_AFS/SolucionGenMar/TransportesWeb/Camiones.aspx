<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Camiones.aspx.cs" Inherits="TransportesWeb.Camiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <h1>🚛 Gestión de Camiones</h1>
    
    <div class="filtros mb-3">
        <label>Filtrar por:</label>
        <asp:DropDownList ID="ddlFiltro" runat="server">
            <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
            <asp:ListItem Value="1">Disponibles</asp:ListItem>
            <asp:ListItem Value="2">No Disponibles</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary ms-2" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-secondary ms-2" />
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Camión" CssClass="btn btn-success ms-2" OnClick="btnNuevo_Click" />
    </div>

    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="info-mensaje mb-3">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </asp:Panel>

    <asp:GridView ID="gvCamiones" runat="server" CssClass="table table-striped table-hover table-bordered"
        AutoGenerateColumns="False"
        AllowPaging="true" PageSize="10"
        OnPageIndexChanging="gvCamiones_PageIndexChanging"
        OnRowCommand="gvCamiones_RowCommand">

        <HeaderStyle CssClass="table-dark" />
        <PagerStyle CssClass="pagination-ys" />

        <Columns>
            <asp:BoundField DataField="IdCamion" HeaderText="ID" />
            <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
            <asp:BoundField DataField="TipoCamion" HeaderText="Tipo" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad (kg)" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Kilometraje" HeaderText="KM" DataFormatString="{0:N2}" />

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <span class='badge <%# (bool)Eval("Disponibilidad") ? "bg-success" : "bg-danger" %>'>
                        <%# (bool)Eval("Disponibilidad") ? "Disponible" : "No Disponible" %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar"
                        CssClass="btn btn-sm btn-warning"
                        CommandName="Editar" CommandArgument='<%# Eval("IdCamion") %>' />

                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                        CssClass="btn btn-sm btn-danger"
                        CommandName="Eliminar" CommandArgument='<%# Eval("IdCamion") %>'
                        OnClientClick="return confirm('¿Seguro que deseas eliminar este camión?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- Modal para Alta / Edición con scroll -->
    <asp:Panel ID="pnlModal" runat="server" Visible="false" 
        Style="position:fixed; 
               top:50%; left:50%; 
               transform:translate(-50%, -50%);
               width:400px; 
               max-height:80vh; 
               overflow-y:auto;
               background:white; 
               border:1px solid black; 
               padding:20px; 
               z-index:1000;">

        <h4>Datos del Camión</h4>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Id Camión:</label>
            <asp:TextBox ID="txtIdcamion" runat="server" ReadOnly="true" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Matrícula:</label>
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Tipo:</label>
            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Marca:</label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Modelo:</label>
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">Capacidad:</label>
            <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" TextMode="Number" />
        </div>

        <div class="mb-2 d-flex align-items-center">
            <label style="width:120px;">KM:</label>
            <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-2">
            <asp:CheckBox ID="chkDisponible" runat="server" Text="Disponible" />
        </div>

        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
            CssClass="btn btn-primary" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" 
            CssClass="btn btn-secondary" OnClick="btnCerrar_Click" />

    </asp:Panel>

</div>

</asp:Content>