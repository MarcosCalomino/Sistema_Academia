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
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = this.txtNombreUsuarios.Text;
                string password = this.txtPassword.Text;
                if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Existen campos en blanco", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Usuario usuarioActual = new UsuarioLogic().Loguin(nombreUsuario, password);
                    IndexAdmin frmIndex = new IndexAdmin(usuarioActual, this);
                    this.Visible = false;
                    frmIndex!.Show();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
        }
    }
}
