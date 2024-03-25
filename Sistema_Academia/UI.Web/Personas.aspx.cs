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
    public partial class Personas : ApplicationForm
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
                this.gridView.DataSource = new PersonaLogic().GetAll();
                this.gridView.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }
        protected void NuevaPersona_Click(object sender, EventArgs e)
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
            Response.Redirect($"PersonaManagment.aspx?FormMode={this.FormMode}&e={encodedEncryptedQueryString}");
        }

        protected void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo;
                if (!int.TryParse(this.txtLegajo.Text, out legajo))
                {
                    this.lblAvisoDeBusqueda.Text = "Ingrese legajo";
                    return;
                }
                var persona = new PersonaLogic().GetOneForLegajo(legajo);
                List<Persona> personaList = new List<Persona>();
                personaList.Add(persona);
                this.gridView.DataSource = personaList;
                this.gridView.DataBind();
                this.lblAvisoDeBusqueda.Text = "";
                this.btnTodasLasPersonas.Visible = true;
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException)
                    Response.Redirect("Error.aspx");
                else
                    this.lblAvisoDeBusqueda.Text = ex.Message;
            }
            
        }

        protected void btnTodasLasPersonas_Click(object sender, EventArgs e)
        {
            this.btnTodasLasPersonas.Visible = false;
            LoadGrid();
        }
    }
}