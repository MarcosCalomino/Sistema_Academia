<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Planes</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:LinkButton OnClick="NuevoPlan_Click" runat="server" CssClass="btn btn-success" Text="Crear nuevo plan" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Descripcion plan" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Especialidad" DataField="DescripcionEspecialidad" />
                        <asp:BoundField HeaderText="ID Especialidad" DataField="IDEspecialidad" visible="false"/>
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
