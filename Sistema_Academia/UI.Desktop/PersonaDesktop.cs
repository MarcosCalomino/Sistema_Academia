using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public Persona? personaActual { get; set; }
        public PersonaDesktop()
        {
            InitializeComponent();
            CargarComboBoxPlanes();
        }
        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            personaActual = new PersonaLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void PersonaDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = this.personaActual!.ID.ToString();
            this.txtNombre.Text = personaActual.Nombre;
            this.txtApellido.Text = personaActual.Apellido;
            this.txtLegajo.Text = personaActual.Legajo.ToString();
            this.txtEmail.Text = personaActual.Email;
            this.txtDireccion.Text = personaActual.Direccion;
            this.txtTelefono.Text = personaActual.Telefono;
            this.dtpFechaNacimiento.Value = personaActual.FechaNacimiento;

            foreach (var item in cBoxPlanes.Items)
            {
                if (item is Plan && ((Plan)item).ID == personaActual!.IDPlan)
                {
                    cBoxPlanes.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cBoxTipoPersona.Items)
            {
                if (personaActual.TipoPersona == 1) { cBoxTipoPersona.SelectedItem = "Profesor"; break; }
                else if (personaActual.TipoPersona == 2) { cBoxTipoPersona.SelectedItem = "Alumno"; break; }
                else if (personaActual.TipoPersona == 3) { cBoxTipoPersona.SelectedItem = "Administrador"; break; }
            }
        }
        private void CargarComboBoxPlanes()
        {
            List<Plan> listaPlanes = new PlanLogic().GetAll();
            listaPlanes.Insert(0, new Plan { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxPlanes.DataSource = listaPlanes;
            cBoxPlanes.DisplayMember = "Descripcion";
            cBoxPlanes.ValueMember = "ID";
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtLegajo.Text) || !isNumeric(txtLegajo.Text))
            {
                MessageBox.Show("Formato incorrecto en legajo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrEmpty(txtNombre.Text) || !VerificaNombre(txtNombre.Text))
            {
                MessageBox.Show("Formato incorrecto en nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text) || !VerificaNombre(txtApellido.Text))
            {
                MessageBox.Show("Formato incorrecto en apellido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Formato incorrecto en direccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !isNumeric(txtTelefono.Text))
            {
                MessageBox.Show("Formato incorrecto en telefono", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text) || !VerificarEmail(txtEmail.Text))
            {
                MessageBox.Show("Formato incorrecto en email", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (string.IsNullOrEmpty(cBoxPlanes.Text) || cBoxPlanes.Text.Equals("-- Seleccionar --"))
            {
                MessageBox.Show("Seleccione plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cBoxTipoPersona.Text.Equals("-- Seleccionar --"))
            {
                MessageBox.Show("Seleccione tipo de persona", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (dtpFechaNacimiento.Value >= DateTime.Now)
            {
                MessageBox.Show("La fecha seleccionada debe ser menor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
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
        public override void GuardarCambios()
        {
            try
            {
                MapearABaseDeDatos();
                new PersonaLogic().Save(personaActual);
                Notificar(personaActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    personaActual = new Persona();
                    personaActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    personaActual!.State = BusinessEntity.States.Modified;
                }

                personaActual!.IDPlan = Convert.ToInt32(cBoxPlanes.SelectedValue);
                personaActual.FechaNacimiento = dtpFechaNacimiento.Value;
                personaActual.TipoPersona = GetTipoDePersona();
                personaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                personaActual.Nombre = this.txtNombre.Text;
                personaActual.Apellido = this.txtApellido.Text;
                personaActual.Direccion = this.txtDireccion.Text;
                personaActual.Telefono = this.txtTelefono.Text;
                personaActual.Email = this.txtEmail.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                personaActual!.State = BusinessEntity.States.Deleted;
            }
        }
        private int GetTipoDePersona()
        {
            if (cBoxTipoPersona.Text.Equals("Profesor"))
            {
                return 1;
            }
            else if (cBoxTipoPersona.Text.Equals("Alumno"))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
