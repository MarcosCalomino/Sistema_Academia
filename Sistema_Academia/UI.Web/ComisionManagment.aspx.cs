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
    public partial class ComisionManagment : ApplicationForm
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
                    Response.Redirect("Comisiones.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear comision", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar comision", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar comision", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Comisiones.aspx");
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
        private void MapearDesdeBaseDeDatos(int idComision)
        {
            try
            {
                Comision comisionActual = new ComisionLogic().GetOne(idComision);

                this.txtID.Text = comisionActual.ID.ToString();
                this.txtDescripcion.Text = comisionActual.Descripcion;
                this.txtAnio.Text = comisionActual.AnioEspecialidad.ToString();
                ddlPlanes.SelectedValue = comisionActual.IDPlan.ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }     
        }
        private Comision MapearABaseDeDatos()
        {
            Comision comisionActual = new Comision();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    comisionActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    comisionActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    comisionActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) comisionActual.ID = Convert.ToInt32(this.txtID.Text);
            comisionActual.Descripcion = this.txtDescripcion.Text;
            comisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
            comisionActual.IDPlan = Convert.ToInt32(ddlPlanes.SelectedValue);

            return comisionActual;
        }  
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Comision comisionActual = MapearABaseDeDatos();
                new ComisionLogic().Save(comisionActual);
                comisionActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("Comisiones.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text)) throw new Exception("Ingrese descripion");
            if (string.IsNullOrWhiteSpace(txtAnio.Text) || !isNumeric(txtAnio.Text)) throw new Exception("Formato incorrecto en el año ingresado");
            if (string.IsNullOrEmpty(this.ddlPlanes.Text) || this.ddlPlanes.Text.Equals("0")) throw new Exception("Seleccione plan");
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