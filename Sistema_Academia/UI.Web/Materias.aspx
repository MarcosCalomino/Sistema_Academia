<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Materias</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <%--<asp:LinkButton OnClick="NuevaMateria_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva materia" data-bs-toggle="modal" data-bs-target="#exampleModal" />--%>
                <asp:LinkButton OnClick="NuevaMateria_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva materia"/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Hs Semanales" DataField="HSSemanales" />
                        <asp:BoundField HeaderText="Hs Totales" DataField="HSTotales" />
                        <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan" />
                        <asp:BoundField HeaderText="Id Plan" DataField="IDPlan" Visible="false" />
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
