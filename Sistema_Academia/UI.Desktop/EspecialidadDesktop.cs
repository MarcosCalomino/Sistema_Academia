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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        Especialidad? EspecialidadActual { get; set; }
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;     
            EspecialidadActual = new EspecialidadLogic().GetOne(ID);
            MapearDeBaseDeDatos();
        }
        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtDescripcion.Text = EspecialidadActual!.Descripcion;
            this.txtID.Text = EspecialidadActual.ID.ToString();
        }
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.State = BusinessEntity.States.New;
                }
                if (Modo.Equals(ModoForm.Modificacion))
                {
                    EspecialidadActual!.State = BusinessEntity.States.Modified;
                }

                EspecialidadActual!.Descripcion = this.txtDescripcion.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                EspecialidadActual!.State = BusinessEntity.States.Deleted;
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
                new EspecialidadLogic().Save(EspecialidadActual);
                Notificar(EspecialidadActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese descripion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
