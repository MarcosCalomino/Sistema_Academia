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
    public partial class MateriaManagment : ApplicationForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
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
                    Response.Redirect("Materias.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear materia", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar materia", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar materia", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Materias.aspx");
                        break;
                }

                LoadDropDownListPlanes();
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
        private void LoadDropDownListPlanes()
        {
            try
            {
                List<Plan> listaPlanes = new PlanLogic().GetAll()
                                            .OrderBy(lp => lp.Descripcion)
                                            .ToList();
                listaPlanes.Insert(0, new Plan { ID = 0, Descripcion = "-- Seleccionar --" });

                ddlPlanes.DataSource = listaPlanes;
                ddlPlanes.DataTextField = "Descripcion"; // Propiedad a mostrar en el DropDownList
                ddlPlanes.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlPlanes.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int idMateria)
        {
            try
            {
                Materia materiaActual = new MateriaLogic().GetOne(idMateria);

                this.txtID.Text = materiaActual.ID.ToString();
                this.txtDescripcion.Text = materiaActual.Descripcion;
                this.txtHorasSemanales.Text = materiaActual.HSTotales.ToString();
                this.txtHorasTotales.Text = materiaActual.HSTotales.ToString();
                ddlPlanes.SelectedValue = materiaActual.IDPlan.ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

        }
        private Materia MapearABaseDeDatos()
        {
            Materia materiaActual = new Materia();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    materiaActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    materiaActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    materiaActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) materiaActual.ID = Convert.ToInt32(this.txtID.Text);
            materiaActual.Descripcion = this.txtDescripcion.Text;
            materiaActual.HSSemanales = Convert.ToInt32(this.txtHorasSemanales.Text);
            materiaActual.HSTotales = Convert.ToInt32(this.txtHorasTotales.Text);
            materiaActual.IDPlan = Convert.ToInt32(ddlPlanes.SelectedValue);

            return materiaActual;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text)) throw new Exception("Ingrese descripion");
            if (string.IsNullOrWhiteSpace(txtHorasSemanales.Text) || !isNumeric(txtHorasSemanales.Text)) throw new Exception("Formato incorrecto en horas semanales");
            if (string.IsNullOrWhiteSpace(txtHorasTotales.Text) || !isNumeric(txtHorasTotales.Text)) throw new Exception("Formato incorrecto en horas totales");
            if (string.IsNullOrEmpty(this.ddlPlanes.Text) || this.ddlPlanes.Text.Equals("0")) throw new Exception("Seleccione plan");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Materia materiaActual = MapearABaseDeDatos();
                new MateriaLogic().Save(materiaActual);
                materiaActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("Materias.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
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