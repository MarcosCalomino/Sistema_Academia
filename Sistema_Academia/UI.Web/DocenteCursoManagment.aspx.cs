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
    public partial class DocenteCursoManagment : ApplicationForm
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
                    Response.Redirect("DocentesCursos.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear docente-curso", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar docente-curso", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar docente-curso", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("DocentesCursos.aspx");
                        break;
                }

                LoadDropDownListDocente();
                LoadDropDownListCurso();
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
        private void LoadDropDownListDocente()
        {
            try
            {
                List<Persona> listaDocentes = new PersonaLogic().GetAll(1)
                                                .OrderBy(lp => lp.Legajo)
                                                .ToList();
                listaDocentes.Insert(0, new Persona { ID = 0, Legajo = 0 });
                ddlDocente.DataSource = listaDocentes;
                ddlDocente.DataTextField = "Legajo"; // Propiedad a mostrar en el DropDownList
                ddlDocente.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlDocente.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void LoadDropDownListCurso()
        {
            try
            {
                List<Curso> listaCursos = new CursoLogic().GetAll()
                                            .OrderBy(lp => lp.Descripcion)
                                            .ToList();
                listaCursos.Insert(0, new Curso { ID = 0, Descripcion = "-- Seleccionar --" });
                ddlCurso.DataSource = listaCursos;
                ddlCurso.DataTextField = "Descripcion"; // Propiedad a mostrar en el DropDownList
                ddlCurso.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlCurso.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int idDocenteCurso)
        {
            try
            {
                DocenteCurso docenteCursoActual = new DocenteCursoLogic().GetOne(idDocenteCurso);
                this.txtID.Text = docenteCursoActual.ID.ToString();
                ddlDocente.SelectedValue = docenteCursoActual.IDDocente.ToString();
                ddlCurso.SelectedValue = docenteCursoActual.IDCurso.ToString();
                ddlCargo.SelectedValue = Convert.ToInt32(docenteCursoActual.Cargo).ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private DocenteCurso MapearABaseDeDatos()
        {
            DocenteCurso docenteCursoActual = new DocenteCurso();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    docenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    docenteCursoActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    docenteCursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) docenteCursoActual.ID = Convert.ToInt32(this.txtID.Text);
            docenteCursoActual.IDCurso = Convert.ToInt32(ddlCurso.SelectedValue);
            docenteCursoActual.IDDocente = Convert.ToInt32(ddlDocente.SelectedValue);
            string valorSeleccionado = ddlCargo.SelectedValue;
            docenteCursoActual.Cargo = (DocenteCurso.tipoCargo)Convert.ToInt32(ddlCargo.SelectedValue);

            return docenteCursoActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                DocenteCurso docenteCursoActual = MapearABaseDeDatos();
                new DocenteCursoLogic().Save(docenteCursoActual);
                docenteCursoActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("DocentesCursos.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(ddlCurso.Text) || ddlCurso.SelectedValue == "0") throw new Exception("Seleccione curso");
            if (ddlDocente.SelectedValue == "0") throw new Exception("Seleccione docente");
            if (ddlCargo.SelectedValue == "0" ) throw new Exception("Seleccione cargo");
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