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
    public partial class CursoManagment : ApplicationForm
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
                    Response.Redirect("Cursos.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear curso", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar curso", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar curso", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Cursos.aspx");
                        break;
                }

                LoadDropDownListComisiones();
                LoadDropDownListMateria();
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
        private void LoadDropDownListComisiones()
        {
            try
            {
                List<Comision> listaMaterias = new ComisionLogic().GetAll()
                                                .OrderBy(lp => lp.Descripcion)
                                                .ToList();
                listaMaterias.Insert(0, new Comision { ID = 0, Descripcion = "-- Seleccionar --" });

                ddlComisiones.DataSource = listaMaterias;
                ddlComisiones.DataTextField = "Descripcion"; // Propiedad a mostrar en el DropDownList
                ddlComisiones.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlComisiones.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void LoadDropDownListMateria()
        {
            try
            {
                List<Materia> listaMaterias = new MateriaLogic().GetAll()
                                                .OrderBy(lp => lp.Descripcion)
                                                .ToList();
                listaMaterias.Insert(0, new Materia { ID = 0, Descripcion = "-- Seleccionar --" });

                ddlMaetrias.DataSource = listaMaterias;
                ddlMaetrias.DataTextField = "Descripcion"; // Propiedad a mostrar en el DropDownList
                ddlMaetrias.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlMaetrias.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int idCurso)
        {
            try
            {
                Curso cursoActual = new CursoLogic().GetOne(idCurso);

                this.txtID.Text = cursoActual.ID.ToString();
                this.txtDescripcion.Text = cursoActual.Descripcion;
                this.txtAnio.Text = cursoActual.AnioCalendario.ToString();
                this.txtCupo.Text = cursoActual.Cupo.ToString();
                ddlComisiones.SelectedValue = cursoActual.IDComision.ToString();
                ddlMaetrias.SelectedValue = cursoActual.IDMateria.ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private Curso MapearABaseDeDatos()
        {
            Curso cursoActual = new Curso();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    cursoActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    cursoActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    cursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) cursoActual.ID = Convert.ToInt32(this.txtID.Text);
            cursoActual.Descripcion = this.txtDescripcion.Text;
            cursoActual.AnioCalendario = Convert.ToInt32(this.txtAnio.Text);
            cursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
            cursoActual.IDMateria = Convert.ToInt32(ddlMaetrias.SelectedValue);
            cursoActual.IDComision = Convert.ToInt32(ddlComisiones.SelectedValue);

            return cursoActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Curso cursoActual = MapearABaseDeDatos();
                new CursoLogic().Save(cursoActual);
                cursoActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("Cursos.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text)) throw new Exception("Ingrese descripion");
            if (string.IsNullOrWhiteSpace(txtAnio.Text) || !isNumeric(txtAnio.Text) || Convert.ToInt32(txtAnio.Text) < 0) throw new Exception("Formato incorrecto en año");
            if (string.IsNullOrWhiteSpace(txtCupo.Text) || !isNumeric(txtCupo.Text) || Convert.ToInt32(txtCupo.Text) < 0) throw new Exception("Formato incorrecto en cupo");
            if (string.IsNullOrEmpty(this.ddlComisiones.Text) || this.ddlComisiones.Text.Equals("0")) throw new Exception("Seleccione Comision");
            if (string.IsNullOrEmpty(this.ddlMaetrias.Text) || this.ddlMaetrias.Text.Equals("0")) throw new Exception("Seleccione Materia");
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