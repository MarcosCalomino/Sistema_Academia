<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Usuarios</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:LinkButton OnClick="NuevoUsuario_Click" runat="server" CssClass="btn btn-success" Text="Crear nuevo usuarios" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:TemplateField HeaderText="Habilitado">
                            <ItemTemplate>
                                <asp:Label ID="lblHabilitado" runat="server" Text='<%# Convert.ToBoolean(Eval("Habilitado")) ? "Sí" : "No" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Clave" DataField="Clave" />
                        <asp:BoundField HeaderText="ID Persona" DataField="Id_Persona" Visible="false" />
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
    </div>
</asp:Content>
