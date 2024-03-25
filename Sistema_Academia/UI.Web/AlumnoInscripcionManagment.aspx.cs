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
    public partial class AlumnoInscripcionManagment : ApplicationForm
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
                    Response.Redirect("AlumnosInscripciones.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear inscripcion", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar inscripcion", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar inscripcion", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("AlumnosInscripciones.aspx");
                        break;
                }

                LoadDropDownListAlumnos();
                LoadDropDownListCursos();
                SetInterfaceByUser2();
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
        private void SetInterfaceByUser2()
        {
            Persona personaActual = GetSession();
            if (personaActual.TipoPersona == 2)
            {
                lblID.Visible = false;
                txtID.Visible = false;
                lblNota.Visible = false;
                txtNota.Visible = false;
                lblCondicion.Visible = false;
                ddlCondicion.Visible = false;
                ddlAlumnos.SelectedValue = personaActual.ID.ToString();
                ddlAlumnos.Enabled = false;
            }
            else if(personaActual.TipoPersona == 1)
            {
                ddlAlumnos.Enabled = false;
                ddlCurso.Enabled = false;
            }
        }
        private void MapearDesdeBaseDeDatos(int idInscripcion)
        {
            try
            {
                AlumnoInscripcion AlumnoInscripcionActual = new AlumnoInscripcionLogic().GetOne(idInscripcion);

                this.txtID.Text = AlumnoInscripcionActual.ID.ToString();
                this.txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
                ddlAlumnos.SelectedValue = AlumnoInscripcionActual.IDAlumno.ToString();
                ddlCurso.SelectedValue = AlumnoInscripcionActual.IDCurso.ToString();
                ddlCondicion.SelectedValue = AlumnoInscripcionActual.Condicion;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void LoadDropDownListCursos()
        {
            try
            {
                Persona personaActual = GetSession();

                List<Curso> listaCursos = new List<Curso>();
                if (personaActual.TipoPersona == 2)
                    listaCursos = new CursoLogic().GetAll(personaActual.IDPlan);
                else
                    listaCursos = new CursoLogic().GetAll();

                listaCursos = listaCursos.OrderBy(lp => lp.Descripcion).ToList();
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
        private void LoadDropDownListAlumnos()
        {
            try
            {
                List<Persona> listaPersonas = new PersonaLogic().GetAll(2).OrderBy(lp => lp.Legajo).ToList();
                listaPersonas.Insert(0, new Persona { ID = 0, Legajo = 0 });

                ddlAlumnos.DataSource = listaPersonas;
                ddlAlumnos.DataTextField = "Legajo"; // Propiedad a mostrar en el DropDownList
                ddlAlumnos.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlAlumnos.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private AlumnoInscripcion MapearABaseDeDatos()
        {
            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    alumnoInscripcion.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    alumnoInscripcion.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    alumnoInscripcion.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) alumnoInscripcion.ID = Convert.ToInt32(this.txtID.Text);
            alumnoInscripcion.Nota = (formMode.Equals("Alta") && VerificarTipoDePersona() == 2) ? 0 : Convert.ToInt32(txtNota.Text);
            alumnoInscripcion.IDAlumno = Convert.ToInt32(ddlAlumnos.SelectedValue);
            alumnoInscripcion.IDCurso = Convert.ToInt32(ddlCurso.SelectedValue);
            alumnoInscripcion.Condicion = (formMode.Equals("Alta") && VerificarTipoDePersona() == 2) ? "Cursando" : ddlCondicion.SelectedItem.Text;

            return alumnoInscripcion;
        }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtNota.Text) || !isNumeric(this.txtNota.Text) || Convert.ToInt32(this.txtNota.Text) < 0) throw new Exception("Formato incorrecto en nota");
            if (string.IsNullOrEmpty(this.ddlAlumnos.Text) || ddlAlumnos.Text.Equals("0")) throw new Exception("Seleccione alumno");
            if (string.IsNullOrEmpty(this.ddlCurso.Text) || Convert.ToInt32(ddlCurso.SelectedValue) == 0) throw new Exception("Seleccione curso");
            if (string.IsNullOrEmpty(this.ddlCondicion.Text) || Convert.ToInt32(ddlCondicion.SelectedValue) == 0) throw new Exception("Seleccione condicion");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {  
                AlumnoInscripcion alumnoInscripcion = MapearABaseDeDatos();
                string formMode = ViewState["FormMode"].ToString();
                switch (formMode)
                {
                    case "Alta":
                        if(VerificarTipoDePersona() != 2)
                            Validar();
                        else
                            if (string.IsNullOrEmpty(this.ddlCurso.Text) || Convert.ToInt32(ddlCurso.SelectedValue) == 0) throw new Exception("Seleccione curso");         
                        alumnoInscripcion.State = BusinessEntity.States.New;
                        break;
                    case "Modificacion":
                        Validar();
                        alumnoInscripcion.State = BusinessEntity.States.Modified;
                        break;
                    case "Baja":
                        alumnoInscripcion.State = BusinessEntity.States.Deleted;
                        break;
                }
                new AlumnoInscripcionLogic().Save(alumnoInscripcion);
                Response.Redirect("AlumnosInscripciones.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private int VerificarTipoDePersona()
        {
            Persona personaActual = GetSession();
            if (personaActual.TipoPersona == 2) return 2;
            else if (personaActual.TipoPersona == 1) return 1;
            else return 3;
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