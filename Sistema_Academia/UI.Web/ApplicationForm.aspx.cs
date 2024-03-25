using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ApplicationForm : System.Web.UI.Page
    {
        public int SessionID = 0;
        public FormModes formMode;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return formMode; }
            set { formMode = value; }
        }
        public int SelectedID
        {
            get
            {
                if (SessionID != 0)
                {
                    return SessionID;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                SessionID = value;
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
        public void SetInterfaceByUser(Persona personaActual)
        {
            if (personaActual.TipoPersona == 2 || personaActual.TipoPersona == 1)
            {
                Master.AccesoPersonaVisible = false;
                Master.EspecialidadesAccesoVisible = false;
                Master.UsuariosAccesoVisible = false;
                Master.PlanesAccesoVisible = false;
                Master.ComisionesAccesoVisible = false;
                Master.MateriaAccesoVisible = false;
                Master.DocentesCursosAccesoVisible = false;
                Master.CursosAccesoVisible = false;
            }
        }
        public void SetSession(Usuario usuario)
        {
            try
            {
                Persona personaActual = new PersonaLogic().GetOne(usuario.Id_Persona);
                Session["SessionLoguin"] = personaActual;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }
        public Persona GetSession()
        {
            return (Persona)Session["SessionLoguin"];
        }
    }
}