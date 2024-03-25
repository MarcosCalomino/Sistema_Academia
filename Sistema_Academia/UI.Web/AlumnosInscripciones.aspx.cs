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
    public partial class AlumnosInscripciones : ApplicationForm
    {
        Persona personaActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
        }
        private void CheckSession()
        {
            personaActual = GetSession();
            if (personaActual == null)
            {
                Response.Redirect("Loguin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                }
                SetInterfaceByUser(personaActual);
            }
        }
        private void LoadGrid()
        {
            try
            {
                var logic = new AlumnoInscripcionLogic();
                var dataSource = personaActual.TipoPersona == 2 || personaActual.TipoPersona == 1 ? logic.GetAll(personaActual) : logic.GetAll();

                gridView.DataSource = dataSource;
                gridView.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }
        protected void NuevaInscripcion_Click(object sender, EventArgs e)
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
            Response.Redirect($"AlumnoInscripcionManagment.aspx?FormMode={this.FormMode}&e={encodedEncryptedQueryString}");
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra los controles dentro del TemplateField
                LinkButton editarLinkButton = e.Row.FindControl("editarLinkButton") as LinkButton;
                LinkButton eliminarLinkButton = e.Row.FindControl("eliminarLinkButton") as LinkButton;

                // Verifica que los controles se hayan encontrado correctamente
                if (editarLinkButton != null && eliminarLinkButton != null)
                {
                    // Usa los controles como necesites
                    if (personaActual.TipoPersona == 2)
                    {
                        btnNuevaInscripcion.Text = "Increbirse a materia";
                        editarLinkButton.Visible = false;
                        eliminarLinkButton.Visible = false;
                    }
                    else if(personaActual.TipoPersona == 1)
                    {
                        btnNuevaInscripcion.Visible = false;
                        eliminarLinkButton.Visible = false;
                    }
                }
            }
        }
    }
}