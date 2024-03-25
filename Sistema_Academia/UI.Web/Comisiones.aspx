<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Comisiones</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:LinkButton OnClick="NuevaComision_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva comision" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Año" DataField="AnioEspecialidad" />
                        <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan" />
                        <asp:BoundField HeaderText="Id Plan" DataField="IDPlan" visible="false"/>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EditarLinkButton_Click" CssClass="btn btn-sm btn-info">Editar</asp:LinkButton>
                                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EliminarLinkButton_Click" CssClass="btn btn-sm btn-danger">Eliminar</asp:LinkButton>
                            </itemtemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
