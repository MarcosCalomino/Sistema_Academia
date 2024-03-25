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
    public partial class PersonaManagment : ApplicationForm
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
                    Response.Redirect("Personas.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear persona", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar persona", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar persona", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Personas.aspx");
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

                ddlPlan.DataSource = listaPlanes;
                ddlPlan.DataTextField = "Descripcion"; // Propiedad a mostrar en el DropDownList
                ddlPlan.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlPlan.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int idPersona)
        {
            try
            {
                Persona persona = new PersonaLogic().GetOne(idPersona);
                
                txtID.Text = persona.ID.ToString();
                txtFechaNacimiento.Text = persona.FechaNacimiento.ToString("yyyy-MM-dd");
                txtLegajo.Text = persona.Legajo.ToString();
                ddlPlan.SelectedValue = persona.IDPlan.ToString();
                txtNombre.Text = persona.Nombre;
                ddlTipoPersona.SelectedValue = persona.TipoPersona.ToString();
                txtApellido.Text = persona.Apellido;
                txtDireccion.Text = persona.Direccion;
                txtTelefono.Text = persona.Telefono;
                txtEmail.Text = persona.Email;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private Persona MapearABaseDeDatos()
        {
            Persona personaActual = new Persona();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    personaActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    personaActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    personaActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) personaActual.ID = Convert.ToInt32(this.txtID.Text);
            personaActual.IDPlan = Convert.ToInt32(ddlPlan.SelectedValue);
            personaActual.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            personaActual.TipoPersona = Convert.ToInt32(ddlTipoPersona.SelectedValue);
            personaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            personaActual.Nombre = this.txtNombre.Text;
            personaActual.Apellido = this.txtApellido.Text;
            personaActual.Direccion = this.txtDireccion.Text;
            personaActual.Telefono = this.txtTelefono.Text;
            personaActual.Email = this.txtEmail.Text;

            return personaActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Persona personaActual = MapearABaseDeDatos();
                new PersonaLogic().Save(personaActual);
                personaActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("Personas.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }      
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(txtLegajo.Text) || !isNumeric(txtLegajo.Text)) throw new Exception("Formato incorrecto en legajo");
            if (string.IsNullOrEmpty(txtNombre.Text) || !VerificaNombre(txtNombre.Text)) throw new Exception("Formato incorrecto en nombre");
            if (string.IsNullOrEmpty(txtApellido.Text) || !VerificaNombre(txtApellido.Text)) throw new Exception("Formato incorrecto en apellido");
            if (string.IsNullOrEmpty(txtDireccion.Text)) throw new Exception("Formato incorrecto en direccion");
            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !isNumeric(txtTelefono.Text)) throw new Exception("Formato incorrecto en telefono");
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !VerificarEmail(txtEmail.Text)) throw new Exception("Formato incorrecto en email");
            if (string.IsNullOrEmpty(ddlPlan.Text) || ddlPlan.SelectedValue == "0") throw new Exception("Seleccione plan");
            if (ddlTipoPersona.SelectedValue == "0") throw new Exception("Seleccione tipo de persona");
            //if (txtFechaNacimiento.Text >= DateTime.Now)
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