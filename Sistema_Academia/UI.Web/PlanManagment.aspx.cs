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
    public partial class PlanManagment : ApplicationForm
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
                    Response.Redirect("Planes.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear plan", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar plan", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar plan", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Planes.aspx");
                        break;
                }

                LoadDropDownListEspecialidades();
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
        private void LoadDropDownListEspecialidades()
        {
            try
            {
                var listaEspecialidades = new EspecialidadLogic().GetAll()
                                            .OrderBy(lp => lp.Descripcion)
                                            .ToList();
                listaEspecialidades.Insert(0, new Especialidad { ID = 0, Descripcion = "-- Seleccionar --" });

                ddlEspecialidades.DataSource = listaEspecialidades;
                ddlEspecialidades.DataTextField = "Descripcion";
                ddlEspecialidades.DataValueField = "ID";
                ddlEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int id)
        {
            try
            {
                Plan planActual = new PlanLogic().GetOne(id);
                Especialidad especialidad = new EspecialidadLogic().GetOne(planActual.IDEspecialidad);
                txtID.Text = planActual.ID.ToString();
                txtDescripcion.Text = planActual.Descripcion;
                ddlEspecialidades.SelectedValue = especialidad.ID.ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private Plan MapearABaseDeDatos()
        {
            Plan planActual = new Plan();
            if (ViewState["FormMode"].ToString().Equals("Alta"))
            {
                planActual.State = BusinessEntity.States.New;
            }
            else if (ViewState["FormMode"].ToString().Equals("Modificacion"))
            {
                planActual.State = BusinessEntity.States.Modified;
            }
            else if (ViewState["FormMode"].ToString().Equals("Baja"))
            {
                planActual.State = BusinessEntity.States.Deleted;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) planActual.ID = Convert.ToInt32(this.txtID.Text);
            planActual.IDEspecialidad = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            planActual.Descripcion = this.txtDescripcion.Text;

            return planActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Plan planActual = MapearABaseDeDatos();
                new PlanLogic().Save(planActual);
                planActual.State = BusinessEntity.States.Unmodified;
                Response.Redirect("Planes.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(ddlEspecialidades.Text) || ddlEspecialidades.SelectedValue == "0")
                throw new Exception("Seleccione especialidad");

            if (string.IsNullOrEmpty(txtDescripcion.Text))
                throw new Exception("Ingrese descripcion");
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