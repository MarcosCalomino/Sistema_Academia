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
    public partial class ComisionDesktop : ApplicationForm
    {
        Comision? ComisionActual { get; set; }
        public ComisionDesktop()
        {
            InitializeComponent();
            CargarComboBoxPlanes();
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;           
            ComisionActual = new ComisionLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = ComisionActual!.ID.ToString();
            this.txtDescripcion.Text = ComisionActual!.Descripcion;
            this.txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();
            foreach (var item in cBoxPlanes.Items)
            {
                if (item is Plan && ((Plan)item).ID == ComisionActual.IDPlan)
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
                new ComisionLogic().Save(ComisionActual);
                Notificar(ComisionActual!);
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
                    ComisionActual = new Comision();
                    ComisionActual.State = BusinessEntity.States.New;
                }
                if (Modo.Equals(ModoForm.Modificacion))
                {
                    ComisionActual!.State = BusinessEntity.States.Modified;
                }

                ComisionActual!.Descripcion = this.txtDescripcion.Text;
                ComisionActual!.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
                ComisionActual!.IDPlan = Convert.ToInt32(cBoxPlanes.SelectedValue);
            }

            if (Modo == ModoForm.Baja)
            {
                ComisionActual!.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese descripion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtAnio.Text) || !isNumeric(txtAnio.Text))
            {
                MessageBox.Show("Formato incorrecto en el año ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cBoxPlanes.Text.Equals("-- Seleccionar --") || string.IsNullOrEmpty((cBoxPlanes.Text)))
            {
                MessageBox.Show("Seleccione plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
