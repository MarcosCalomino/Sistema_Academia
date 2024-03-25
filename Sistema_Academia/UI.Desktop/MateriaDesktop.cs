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
    public partial class MateriaDesktop : ApplicationForm
    {
        Materia? MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
            CargarComboBoxPlanes();
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaActual = new MateriaLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = this.MateriaActual!.ID.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHsSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = MateriaActual.HSTotales.ToString();

            foreach (var item in cBoxPlanes.Items)
            {
                if (item is Plan && ((Plan)item).ID == MateriaActual.IDPlan)
                {
                    cBoxPlanes.SelectedItem = item;
                    break;
                }
            }
        }
        private void CargarComboBoxPlanes()
        {
            List<Plan> listaPlanes = new PlanLogic().GetAll();
            listaPlanes = listaPlanes.OrderBy(lp => lp.Descripcion).ToList();
            listaPlanes.Insert(0, new Plan { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxPlanes.DataSource = listaPlanes;
            cBoxPlanes.DisplayMember = "Descripcion"; // Propiedad a mostrar en el ComboBox
            cBoxPlanes.ValueMember = "ID";
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
                new MateriaLogic().Save(MateriaActual);
                Notificar(MateriaActual!);
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
                    MateriaActual = new Materia();
                    MateriaActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    MateriaActual!.State = BusinessEntity.States.Modified;
                }

                MateriaActual!.IDPlan = Convert.ToInt32(cBoxPlanes.SelectedValue);
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual!.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Notificar("Error", "Ingrese descripcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsSemanales.Text) || !isNumeric(this.txtHsSemanales.Text))
            {
                Notificar("Error", "Formato incorrecto en horas semanales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsTotales.Text) || !isNumeric(this.txtHsTotales.Text))
            {
                Notificar("Error", "Formato incorrecto en horas totales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(this.cBoxPlanes.Text) || this.cBoxPlanes.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
