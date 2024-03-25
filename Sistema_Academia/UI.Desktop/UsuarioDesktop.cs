using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario? UsuarioActual { get; set; }
        public UsuarioDesktop()
        {
            InitializeComponent();
            CargarComboBoxIdPersonas();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearDeBaseDeDatos()
        {
            Persona persona = new PersonaLogic().GetOne(UsuarioActual!.Id_Persona);

            this.txtID.Text = this.UsuarioActual!.ID.ToString();
            this.txtNombre.Text = persona.Nombre;
            this.txtApellido.Text = persona.Apellido;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtEmail.Text = persona.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            foreach (var item in cBoxIdPersona.Items)
            {
                if (item is Persona && ((Persona)item).ID == persona.ID)
                {
                    cBoxIdPersona.SelectedItem = item;
                    break; 
                }
            }
            this.cBoxIdPersona.Enabled = false;
        }
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    UsuarioActual!.State = BusinessEntity.States.Modified;
                }

                UsuarioActual!.Id_Persona = Convert.ToInt32(cBoxIdPersona.SelectedValue);
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                UsuarioActual!.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearABaseDeDatos();
                new UsuarioLogic().Save(UsuarioActual);
                Notificar(UsuarioActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.cBoxIdPersona.Text))
            {
                Notificar("Error", "Seleccione legajo de persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                Notificar("Error", "Ingrese email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtUsuario.Text))
            {
                Notificar("Error", "Ingrese nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtClave.Text))
            {
                Notificar("Error", "Ingrese clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtConfirmarClave.Text))
            {
                Notificar("Error", "Ingrese confirmacion de clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if ((this.txtClave.Text).Length < 8)
            {
                Notificar("Error", "Clave incorrecta.\nDebe tener mas de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if ((this.txtConfirmarClave.Text).Length < 8)
            {
                Notificar("Error", "Confirmacion de clave incorrecta.\nDebe tener mas de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Error", "Las claves deben coincidir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!VerificarEmail(this.txtEmail.Text))
            {
                Notificar("Error", "Email con formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void CargarComboBoxIdPersonas()
        {
            List<Persona> listaPersonas = new PersonaLogic().GetAll();
            listaPersonas = listaPersonas.OrderBy(lp => lp.Legajo).ToList();
            listaPersonas.Insert(0, new Persona { ID = 0, Legajo = 0, Nombre = "", Apellido = "", Email = "" });
            cBoxIdPersona.DataSource = listaPersonas;
            cBoxIdPersona.DisplayMember = "Legajo"; // Propiedad a mostrar en el ComboBox
            cBoxIdPersona.ValueMember = "ID";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        this.Close();
                    }
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        this.Close();
                    }
                    break;
                case ModoForm.Baja:
                    GuardarCambios();
                    this.Close();
                    break;
            }
        }
        private void cBoxIdPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            Persona persona;
            if (cBoxIdPersona.SelectedItem is Persona)
            {
                persona = (Persona)cBoxIdPersona.SelectedItem;
                this.txtNombre.Text = persona.Nombre;
                this.txtApellido.Text = persona.Apellido;
                this.txtEmail.Text = persona.Email;
            }
            else
            {
                int idPersona = Convert.ToInt32(cBoxIdPersona.SelectedValue);
                persona = new PersonaLogic().GetOne(idPersona);
                this.txtNombre.Text = persona.Nombre;
                this.txtApellido.Text = persona.Apellido;
                this.txtEmail.Text = persona.Email;
            }
        }
    }
}
