using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class UsuarioManagment : ApplicationForm
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
                    Response.Redirect("Usuarios.aspx");
                }

                Enum.TryParse(ViewState["FormMode"].ToString(), out FormModes formMode);

                switch (formMode)
                {
                    case FormModes.Alta:
                        SetFormSettings("Crear usuario", Color.LimeGreen);
                        break;
                    case FormModes.Baja:
                        SetFormSettings("Eliminar usuario", Color.Red);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    case FormModes.Modificacion:
                        SetFormSettings("Editar usuario", Color.MediumTurquoise);
                        MapearDesdeBaseDeDatos(Convert.ToInt32(ViewState["ID"]));
                        break;
                    default:
                        Response.Redirect("Usuarios.aspx");
                        break;
                }

                LoadDropDownListLegajos();
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
        private void LoadDropDownListLegajos()
        {
            try
            {
                List<Persona> listaPersonas = new PersonaLogic().GetAll()
                                                .OrderBy(lp => lp.Legajo)
                                                .ToList();
                listaPersonas.Insert(0, new Persona { ID = 0, Legajo = 0, Nombre = "", Apellido = "", Email = "" });

                ddlLegajos.DataSource = listaPersonas;
                ddlLegajos.DataTextField = "Legajo"; // Propiedad a mostrar en el DropDownList
                ddlLegajos.DataValueField = "ID"; // Valor asociado a cada elemento del DropDownList
                ddlLegajos.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private void MapearDesdeBaseDeDatos(int idUsuario)
        {
            try
            {
                Usuario usuario = new UsuarioLogic().GetOne(idUsuario);
                Persona persona = new PersonaLogic().GetOne(usuario.Id_Persona);

                this.txtID.Text = usuario.ID.ToString();
                this.txtNombre.Text = persona.Nombre;
                this.txtApellido.Text = persona.Apellido;
                this.chkHabilitado.Checked = usuario.Habilitado;
                this.txtEmail.Text = persona.Email;
                this.txtUsaurio.Text = usuario.NombreUsuario;
                this.txtClave.Text = usuario.Clave;
                this.txtConfirmarClave.Text = usuario.Clave;
                ddlLegajos.SelectedValue = persona.ID.ToString();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        private Usuario MapearABaseDeDatos()
        {
            Usuario usuarioActual = new Usuario();
            string formMode = ViewState["FormMode"].ToString();
            switch (formMode)
            {
                case "Alta":
                    usuarioActual.State = BusinessEntity.States.New;
                    break;
                case "Modificacion":
                    usuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case "Baja":
                    usuarioActual.State = BusinessEntity.States.Deleted;
                    break;
            }

            if (!string.IsNullOrEmpty(txtID.Text)) usuarioActual.ID = Convert.ToInt32(this.txtID.Text);
            usuarioActual.Id_Persona = Convert.ToInt32(ddlLegajos.SelectedValue);
            usuarioActual.Habilitado = this.chkHabilitado.Checked;
            usuarioActual.Nombre = this.txtNombre.Text;
            usuarioActual.Apellido = this.txtApellido.Text;
            usuarioActual.Email = this.txtEmail.Text;
            usuarioActual.NombreUsuario = this.txtUsaurio.Text;
            usuarioActual.Clave = this.txtClave.Text;

            return usuarioActual;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Usuario usuarioActual = MapearABaseDeDatos();
                new UsuarioLogic().Save(usuarioActual);
                usuarioActual.State = BusinessEntity.States.Unmodified; //*
                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }       
        private void Validar()
        {
            if (string.IsNullOrEmpty(this.ddlLegajos.Text) || this.ddlLegajos.Text.Equals("0")) throw new Exception("Seleccione legajo");
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text)) throw new Exception("Ingrese Email");
            if (string.IsNullOrWhiteSpace(this.txtUsaurio.Text)) throw new Exception("Ingrese nombre de usuario");
            if (string.IsNullOrWhiteSpace(this.txtClave.Text)) throw new Exception("Ingrese clave");
            if ((this.txtClave.Text).Length < 8) throw new Exception("Clave incorrecta. Debe tener mas de 8 caracteres");
            if (string.IsNullOrWhiteSpace(this.txtConfirmarClave.Text)) throw new Exception("Ingrese confirmacion de clave");
            if ((this.txtConfirmarClave.Text).Length < 8) throw new Exception("Confirmacion de clave incorrecta. Debe tener mas de 8 caracteres");
            if (this.txtClave.Text != this.txtConfirmarClave.Text) throw new Exception("Las claves deben coincidir");
            if (!VerificarEmail(this.txtEmail.Text)) throw new Exception("Email con formato incorrecto");
        }  
        protected void ddlLegajos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPersona = Convert.ToInt32(ddlLegajos.SelectedValue);
            if (idPersona != 0)
            {
                Persona persona = new PersonaLogic().GetOne(idPersona);
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEmail.Text = persona.Email;
            }
            else
            {
                // Lógica para limpiar los campos si no se selecciona una persona
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
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