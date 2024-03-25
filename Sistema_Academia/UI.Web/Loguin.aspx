<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loguin.aspx.cs" Inherits="UI.Web.Loguin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Loguin</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5 pt-5">
            <div class="row justify-content-center">
                <div class="col-12 col-xl-4 col-md-6">
                    <div class="card">
                        <div class="card-header">
                            Iniciar Sesion
                        </div>
                        <div class="card-body">
                            <asp:TextBox ID="txtNombreUsuarios" placeholder="Usuario" runat="server" CssClass="form-control mb-3"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" placeholder="Contraseña" runat="server" CssClass="form-control mb-3" type="password"></asp:TextBox>
                            <div class="d-grid gap-2 mb-3">
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Iniciar Sesion" CssClass="btn btn-primary mt-4"/> 
                            </div>
                        </div>
                    </div>
                    <asp:Label runat="server" class="text-danger" visible="true" ID="lblNotificacion"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</body>
</html>
