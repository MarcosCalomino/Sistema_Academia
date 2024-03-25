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
    public partial class CursoDesktop : ApplicationForm
    {
        Curso? cursoActual { get; set; }
        public CursoDesktop()
        {
            InitializeComponent();
            CargarComboBoxMaterias();
            CargarComboBoxComisiones();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            cursoActual = new CursoLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        private void CargarComboBoxComisiones()
        {
            List<Comision> listaComision = new ComisionLogic().GetAll();
            listaComision.Insert(0, new Comision { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxComision.DataSource = listaComision;
            cBoxComision.DisplayMember = "Descripcion";
            cBoxComision.ValueMember = "ID";
        }
        private void CargarComboBoxMaterias()
        {
            List<Materia> listaMateria = new MateriaLogic().GetAll();
            listaMateria.Insert(0, new Materia { ID = 0, Descripcion = "-- Seleccionar --" });
            cBoxMateria.DataSource = listaMateria;
            cBoxMateria.DisplayMember = "Descripcion";
            cBoxMateria.ValueMember = "ID";
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
                new CursoLogic().Save(cursoActual);
                this.Notificar(cursoActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = this.cursoActual!.ID.ToString();
            this.txtCupo.Text = cursoActual.Cupo.ToString();
            this.txtAnio.Text = cursoActual.AnioCalendario.ToString();
            this.txtDescripcion.Text = cursoActual.Descripcion;

            foreach (var item in cBoxMateria.Items)
            {
                if (item is Materia && ((Materia)item).ID == cursoActual.IDMateria)
                {
                    cBoxMateria.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cBoxComision.Items)
            {
                if (item is Comision && ((Comision)item).ID == cursoActual.IDComision)
                {
                    cBoxComision.SelectedItem = item;
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
                    cursoActual = new Curso();
                    cursoActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    cursoActual!.State = BusinessEntity.States.Modified;
                }

                cursoActual!.IDComision = Convert.ToInt32(cBoxComision.SelectedValue);
                cursoActual!.IDMateria = Convert.ToInt32(cBoxMateria.SelectedValue);
                cursoActual!.AnioCalendario = Convert.ToInt32(txtAnio.Text);
                cursoActual!.Cupo = Convert.ToInt32(txtCupo.Text);
                cursoActual!.Descripcion = txtDescripcion.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                cursoActual!.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Notificar("Error", "Ingrese ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(this.cBoxMateria.Text) || this.cBoxMateria.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(this.cBoxComision.Text) || this.cBoxComision.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione comision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtAnio.Text) || !isNumeric(txtAnio.Text) || Convert.ToInt32(txtAnio.Text) < 0)
            {
                Notificar("Error", "Año con formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCupo.Text) || !isNumeric(txtCupo.Text) || Convert.ToInt32(txtCupo.Text)<0)
            {
                Notificar("Error", "Cupo con formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
