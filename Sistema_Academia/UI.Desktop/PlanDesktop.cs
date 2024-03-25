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
    public partial class PlanDesktop : ApplicationForm
    {
        Plan? planActual { get; set; }
        public PlanDesktop()
        {
            InitializeComponent();
            CargarComboBoxEspecialidades();
        }
        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo; 
            planActual = new PlanLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void PlanDesktop_Load(object sender, EventArgs e)
        {                 
            SetButtonAceptar(Modo, btnAceptar);
        }
        private void CargarComboBoxEspecialidades()
        {
            List<Especialidad> listaEspecialidades = new EspecialidadLogic().GetAll();
            listaEspecialidades = listaEspecialidades.OrderBy(lp => lp.Descripcion).ToList();
            listaEspecialidades.Insert(0, new Especialidad { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxEspecialidad.DataSource = listaEspecialidades;
            cBoxEspecialidad.DisplayMember = "Descripcion"; // Propiedad a mostrar en el ComboBox
            cBoxEspecialidad.ValueMember = "ID";
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
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = planActual!.ID.ToString();
            this.txtDescripcion.Text = planActual.Descripcion;
            foreach (var item in cBoxEspecialidad.Items)
            {
                if (item is Especialidad && ((Especialidad)item).ID == planActual!.IDEspecialidad)
                {
                    cBoxEspecialidad.SelectedItem = item;
                    break;
                }
            }
        }
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    planActual = new Plan();
                    planActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    planActual!.State = BusinessEntity.States.Modified;
                }

                planActual!.IDEspecialidad = Convert.ToInt32(cBoxEspecialidad.SelectedValue);
                planActual.Descripcion = this.txtDescripcion.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                planActual!.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearABaseDeDatos();
                new PlanLogic().Save(planActual);
                Notificar(planActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Notificar("Error", "Ingrese descipcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxEspecialidad.Text) || cBoxEspecialidad.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }   
    }
}
