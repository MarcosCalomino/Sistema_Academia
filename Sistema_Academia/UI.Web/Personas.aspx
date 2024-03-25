<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container-fluid">
        <div class="row">
            <h1>Personas</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-6">
                <asp:LinkButton OnClick="NuevaPersona_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva persona" />
            </div>
            <div class="col-2">
                <asp:TextBox ID="txtLegajo" runat="server" placeholder="Legajo" type="number"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Button  runat="server" ID="btnBuscarPersona" Text="Buscar" OnClick="btnBuscarPersona_Click"/>
            </div>
            <div class="col-2">
                <asp:Label ID="lblAvisoDeBusqueda" runat="server" class="text-danger"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                        <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNacimiento" />
                        <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Tipo" DataField="TipoPersonaString" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan" />
                        <asp:BoundField HeaderText="IDPlan" DataField="IDPlan" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EditarLinkButton_Click" CssClass="btn btn-sm btn-info">Editar</asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EliminarLinkButton_Click" CssClass="btn btn-sm btn-danger">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <asp:Button visible="false" runat="server" ID="btnTodasLasPersonas" Text="Ver todas" OnClick="btnTodasLasPersonas_Click"/>
    </div>
</asp:Content>
