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
    public partial class DocentesCursos : Form
    {
        private Persona? PersonaActual { get; set; }
        public DocentesCursos()
        {
            InitializeComponent();
            dgvDocentesCursos.AutoGenerateColumns = false;
        }
        public DocentesCursos(Persona persona): this()
        {
            PersonaActual = persona;
        }
        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            SetInterface();
        }
        private void SetInterface()
        {
            if (PersonaActual != null)
            {
                this.btnEliminar.Visible = false;
                this.btnNuevo.Visible = false;
            }
            this.Listar();         
        }
        private void Listar()
        {
            try
            {
                dgvDocentesCursos.DataSource = new DocenteCursoLogic().GetAll();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                DocenteCursoDesktop docenteCursoDesktop = new DocenteCursoDesktop();
                docenteCursoDesktop.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocenteCursoDesktop = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocenteCursoDesktop.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocenteCursoDesktop = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocenteCursoDesktop.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
