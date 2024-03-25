using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class EspecialidadManagment : ApplicationForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }
        private void LoadForm()
        {
            try
            {
                ViewState["FormMode"] = Request.QueryString["FormMode"];
                ViewState["ID"] = Encriptador.DecryptString(Request.QueryString["e"]);

                if (ViewState["FormMode"] == null && Convert.ToInt32(ViewState["ID"]) == 0)
                {
                    Response.Redirect("Especialidades.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear especialidad", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar especialidad", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar especialidad", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Especialidades.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void SetFormSettings(string title, Color buttonColor)
        {
            lblTitulo.Text = title;
            btnSubmit.Text = title;
            btnSubmit.BackColor = buttonColor;
            btnSubmit.ForeColor = Color.Black;
        }
        private void MapearDesdeBaseDeDatos(int idEspecialidad)
        {
            try
            {
                Especialidad especialidadActual = new EspecialidadLogic().GetOne(idEspecialidad);
                this.txtID.Text = especialidadActual.ID.ToString();
                this.txtDescripcion.Text = especialidadActual.Descripcion;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }      
        }
        private Especialidad MapearABaseDeDatos()
        {
            Especialidad especialidadActual = new Especialidad();
            if (!string.IsNullOrEmpty(txtID.Text)) especialidadActual.ID = Convert.ToInt32(this.txtID.Text);
            especialidadActual.Descripcion = this.txtDescripcion.Text;
            return especialidadActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Especialidad especialidadActual = MapearABaseDeDatos();
                string formMode = ViewState["FormMode"].ToString();

                switch (formMode)
                {
                    case "Alta":
                        especialidadActual.State = BusinessEntity.States.New;
                        break;
                    case "Modificacion":
                        especialidadActual.State = BusinessEntity.States.Modified;
                        break;
                    case "Baja":
                        especialidadActual.State = BusinessEntity.States.Deleted;
                        break;
                }

                new EspecialidadLogic().Save(especialidadActual);
                Response.Redirect("Especialidades.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text)) throw new Exception("Ingrese descripcion");
        }
        private void HandleError(Exception ex)
        {
            if (ex is System.Data.SqlClient.SqlException)
            {
                Response.Redirect("Error.aspx");
            }
            else
            {
                lblNotificacion.Text = ex.Message;
            }
        }
    }
}