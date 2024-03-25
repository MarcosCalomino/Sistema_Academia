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
using static UI.Desktop.ApplicationForm;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        DocenteCurso? DocenteCursoActual { get; set; }
        public DocenteCursoDesktop()
        {
            InitializeComponent();
            CargarComboBoxCursos();
            CargarComboBoxDocentes();
            cBoxCargo.DataSource = Enum.GetValues(typeof(DocenteCurso.tipoCargo));
        }
        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            DocenteCursoActual = new DocenteCursoLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    DocenteCursoActual!.State = BusinessEntity.States.Modified;
                }

                DocenteCursoActual!.IDDocente = Convert.ToInt32(cBoxDocente.SelectedValue);
                DocenteCursoActual!.IDCurso = Convert.ToInt32(cBoxCurso.SelectedValue);
                DocenteCursoActual!.Cargo = (DocenteCurso.tipoCargo)(int)cBoxCargo.SelectedValue!;
            }
            else if (Modo == ModoForm.Baja)
            {
                DocenteCursoActual!.State = BusinessEntity.States.Deleted;
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
                new DocenteCursoLogic().Save(DocenteCursoActual);
                Notificar(DocenteCursoActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarComboBoxDocentes()
        {
            List<Persona> listaDocentes = new PersonaLogic().GetAll(1);
            listaDocentes = listaDocentes.OrderBy(lp => lp.Legajo).ToList();
            listaDocentes.Insert(0, new Persona { ID = 0, Legajo = 0 });
            cBoxDocente.DataSource = listaDocentes;
            cBoxDocente.DisplayMember = "Legajo"; // Propiedad a mostrar en el ComboBox
            cBoxDocente.ValueMember = "ID";
        }
        private void CargarComboBoxCursos()
        {
            List<Curso> listaCursos = new CursoLogic().GetAll();
            listaCursos = listaCursos.OrderBy(lp => lp.Descripcion).ToList();
            listaCursos.Insert(0, new Curso { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxCurso.DataSource = listaCursos;
            cBoxCurso.DisplayMember = "Descripcion"; // Propiedad a mostrar en el ComboBox
            cBoxCurso.ValueMember = "ID";
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = this.DocenteCursoActual!.ID.ToString();

            foreach (var item in cBoxCurso.Items)
            {
                if (item is Curso && ((Curso)item).ID == DocenteCursoActual.IDCurso)
                {
                    // Establecer la persona como SelectedItem en el ComboBox
                    cBoxCurso.SelectedItem = item;
                    break; // Salir del bucle una vez que se encuentre la persona
                }
            }

            foreach (var item in cBoxDocente.Items)
            {
                if (item is Persona && ((Persona)item).ID == DocenteCursoActual.IDDocente)
                {
                    // Establecer la persona como SelectedItem en el ComboBox
                    cBoxDocente.SelectedItem = item;
                    break; // Salir del bucle una vez que se encuentre la persona
                }
            }

            foreach (var item in cBoxCargo.Items)
            {
                if (DocenteCursoActual.Cargo == DocenteCurso.tipoCargo.DocentePractica) { cBoxCargo.SelectedItem = "Docente de practica"; break; }
                else if (DocenteCursoActual.Cargo == DocenteCurso.tipoCargo.DocenteTeoria) { cBoxCargo.SelectedItem = "Docente de teoria"; break; }
                else if (DocenteCursoActual.Cargo == DocenteCurso.tipoCargo.Ayudante) { cBoxCargo.SelectedItem = "Ayudante"; break; }
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.cBoxCargo.Text) || this.cBoxCargo.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(this.cBoxCurso.Text) || this.cBoxCurso.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(this.cBoxDocente.Text) || this.cBoxDocente.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione docente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
