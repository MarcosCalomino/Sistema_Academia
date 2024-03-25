<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <div class="container">
     <div class="row">
         <h1>Docentes Cursos</h1>
     </div>
     <br />
     <div class="row">
         <div class="col-12">
             <asp:LinkButton OnClick="NuevoDocenteCurso_Click" runat="server" CssClass="btn btn-success" Text="Incribir docente a curso" />
         </div>
     </div>
     <br />
     <div class="row">
         <div class="col-12">
             <asp:GridView ID="gridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                 <Columns>
                     <asp:BoundField HeaderText="ID" DataField="ID" Visible="false"/>
                     <asp:BoundField HeaderText="Id Curso" DataField="IdCurso" visible="false"/>
                     <asp:BoundField HeaderText="Id Docente" DataField="IdDocente" visible="false"/>
                     <asp:BoundField HeaderText="Docente" DataField="LegajoDocente"/>
                     <asp:BoundField HeaderText="Curso" DataField="DescripcionCurso"/>
                     <asp:BoundField HeaderText="Cargo" DataField="Cargo"/>
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
