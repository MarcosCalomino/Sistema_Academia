<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosInscripciones.aspx.cs" Inherits="UI.Web.AlumnosInscripciones" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h1>Inscripciones de alumno</h1>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:LinkButton ID="btnNuevaInscripcion" OnClick="NuevaInscripcion_Click" runat="server" CssClass="btn btn-success" Text="Crear nueva inscripcion" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="gridView_RowDataBound">
                    <columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" visible="false"/>
                        <asp:BoundField HeaderText="Id Curso" DataField="IDCurso" visible="false"/>
                        <asp:BoundField HeaderText="Id Alumno" DataField="IDAlumno" visible="false" />
                        <asp:BoundField HeaderText="Curso" DataField="DescripcionCurso"/>
                        <asp:BoundField HeaderText="Alumno" DataField="LegajoAlumno"/>
                        <asp:BoundField HeaderText="Condicion" DataField="Condicion"/>
                        <asp:BoundField HeaderText="Nota" DataField="Nota"/>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton ID="editarLinkButton" CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EditarLinkButton_Click" CssClass="btn btn-sm btn-info">Editar</asp:LinkButton>
                                <asp:LinkButton ID="eliminarLinkButton" CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="EliminarLinkButton_Click" CssClass="btn btn-sm btn-danger">Eliminar</asp:LinkButton>
                            </itemtemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

<%--<asp:TemplateField HeaderText="Condicion">
    <ItemTemplate>
        <asp:Label runat="server" Text='<%# Convert.ToInt32(Eval("Condicion")) == 1 ? "Libre" : (Convert.ToInt32(Eval("Condicion")) == 2 ? "Cursando" : (Convert.ToInt32(Eval("Condicion")) == 3 ? "Regular" : "Aprobada")) %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>--%>