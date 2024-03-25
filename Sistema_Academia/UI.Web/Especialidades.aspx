<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Especialidades</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:LinkButton OnClick="NuevaEspecialidad_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva especialidad" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
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

<%--<asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged"> 
        <Columns>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>  
</asp:Panel>
<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Ingrese la descripción"></asp:RequiredFieldValidator>
</asp:Panel>
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>  
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>  
</asp:Panel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="validaciones"></asp:ValidationSummary>--%>
