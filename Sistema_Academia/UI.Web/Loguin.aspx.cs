using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Loguin : ApplicationForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = this.txtNombreUsuarios.Text;
                string password = this.txtPassword.Text;
                if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
                {
                    this.lblNotificacion.Text = "Existen campos en blanco";
                }
                else
                {
                    Usuario usuarioActual = new UsuarioLogic().Loguin(nombreUsuario, password);
                    SetSession(usuarioActual);
                    Response.Redirect("Index.aspx");
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Response.Redirect("Error.aspx");
            }
            catch (Exception Ex)
            {
                this.lblNotificacion.Text = Ex.Message;
            }
           
        }
    }
}