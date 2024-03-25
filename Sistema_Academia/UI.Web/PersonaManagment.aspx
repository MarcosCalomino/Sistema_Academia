<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaManagment.aspx.cs" Inherits="UI.Web.PersonaManagment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="formularioPersonas" runat="server">
        <div class="container">
            <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
            <div class="row">
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">ID</label>
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Fecha nacimiento</label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Legajo</label>
                        <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Plan</label>
                        <asp:DropDownList ID="ddlPlan" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Tipo persona</label>
                        <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="form-control">
                            <asp:ListItem Text="-- Seleccionar --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Profesor" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Alumno" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Administrador" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Direccion</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Telefono</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="mb-1 mt-3">
                        <label class="col-form-label">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Enviar" CssClass="btn btn-success mt-4" />
            <asp:LinkButton runat="server" PostBackUrl="~/Personas.aspx" CssClass="btn  btn-primary mt-4">Volver</asp:LinkButton>
            <br />
            <asp:Label runat="server" class="text-danger" Visible="true" ID="lblNotificacion"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</body>
</html>
