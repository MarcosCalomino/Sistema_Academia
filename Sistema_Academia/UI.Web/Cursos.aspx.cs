using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class Cursos : ApplicationForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionAndRedirect();
            if (!Page.IsPostBack) LoadGrid();
        }
        private void CheckSessionAndRedirect()
        {
            Persona personaActual = GetSession();
            if (personaActual == null)
            {
                Response.Redirect("Loguin.aspx");
            }
            else if (personaActual.TipoPersona == 2 || personaActual.TipoPersona == 1)
            {
                Response.Redirect("Index.aspx");
            }
        }
        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = new CursoLogic().GetAll();
                this.gridView.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }
        protected void NuevaCurso_Click(object sender, EventArgs e)
        {
            RedirectToCursoManagement(FormModes.Alta);
        }
        protected void EditarLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            SelectedID = Convert.ToInt32(btn.CommandArgument);
            RedirectToCursoManagement(FormModes.Modificacion);
        }
        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            SelectedID = Convert.ToInt32(btn.CommandArgument);
            RedirectToCursoManagement(FormModes.Baja);
        }
        private void RedirectToCursoManagement(FormModes formMode)
        {
            string encryptedQueryString = Encriptador.EncryptString(SelectedID.ToString());
            string encodedEncryptedQueryString = HttpUtility.UrlEncode(encryptedQueryString);
            this.FormMode = formMode;
            Response.Redirect($"CursoManagment.aspx?FormMode={this.FormMode}&e={encodedEncryptedQueryString}");
        }
    }
}