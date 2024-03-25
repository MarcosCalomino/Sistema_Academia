using Business.Entities;
using Business.Logic;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public enum ModoForm { Alta, Baja, Modificacion, Consulta, Inscripcion }

        private ModoForm modo;
        public ModoForm Modo { get => modo; set => modo = value; }
        public ApplicationForm()
        {
            InitializeComponent();
        }
        public virtual void MapearDeBaseDeDatos() { }
        public virtual void MapearABaseDeDatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono) { MessageBox.Show(mensaje, titulo, botones, icono); }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono) { this.Notificar(this.Text, mensaje, botones, icono); }
        public static bool VerificarEmail(string email)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool isNumeric(string x)
        {
            if (Regex.IsMatch(x, @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }
        public bool VerificaNombre(string n)
        {
            Regex name_validation = new Regex(@"^[a-zA-Z\s]+$");

            if (name_validation.IsMatch(n))
            {
                return true;
            }
            return false;
        }
        public void SetButtonAceptar(ModoForm modo, Guna2Button btnAceptar)
        {
            if (modo.Equals(ModoForm.Alta))
            {
                btnAceptar.FillColor = Color.Green;
                btnAceptar.Text = "Guardar";
            }
            else if (modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.FillColor = Color.Yellow;
                btnAceptar.Text = "Editar";
            }
            else if (modo.Equals(ModoForm.Baja))
            {
                btnAceptar.FillColor = Color.Red;
                btnAceptar.Text = "Eliminar";
            }
        }
        public void Notificar<T>(T entidad) where T : BusinessEntity
        {
            Dictionary<BusinessEntity.States, string> mensajes = new Dictionary<BusinessEntity.States, string>
            {
                { BusinessEntity.States.New, " creado " },
                { BusinessEntity.States.Modified, " editado " },
                { BusinessEntity.States.Deleted, " eliminado " }
            };

            if (mensajes.ContainsKey(entidad.State))
            {
                MessageBox.Show("Registro" + mensajes[entidad.State] + "correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            entidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
