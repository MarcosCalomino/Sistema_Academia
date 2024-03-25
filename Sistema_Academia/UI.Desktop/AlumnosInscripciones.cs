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
    public partial class AlumnosInscripciones : Form
    {
        private Persona? PersonaActual { get; set; }
        public AlumnosInscripciones()
        {
            InitializeComponent();
            dgvAlumnosInscripciones.AutoGenerateColumns = false;
        }
        public AlumnosInscripciones(Persona personaActual) : this()
        {
            this.PersonaActual = personaActual;
        }
        private void AlumnosInscripciones_Load(object sender, EventArgs e)
        {
            SetInterface();
        }
        private void SetInterface()
        {
            if (PersonaActual != null)
            {    
                if(PersonaActual.TipoPersona == 2) //Alumno
                {
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }
                else if(PersonaActual.TipoPersona == 1) //Profesor
                {
                    btnNuevo.Visible = false;
                    btnEliminar.Visible = false;
                }
            }
            this.Listar();
        }
        private void Listar()
        {
            try
            {
                if (PersonaActual != null)
                {
                    dgvAlumnosInscripciones.DataSource = new AlumnoInscripcionLogic().GetAll(PersonaActual);
                }
                else
                {
                    dgvAlumnosInscripciones.DataSource = new AlumnoInscripcionLogic().GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SetInterface();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Form frmDesktop;
                if (PersonaActual != null)
                {
                    frmDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Inscripcion, PersonaActual);
                    frmDesktop.ShowDialog();
                    this.Listar();
                }
                else
                {
                    frmDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
                    frmDesktop.ShowDialog();
                    this.Listar();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop frmDesktop = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                frmDesktop.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop frmDesktop = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                frmDesktop.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
