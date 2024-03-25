using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public bool AccesoPersonaVisible
        {
            get { return PersonasAcceso.Visible; }
            set { PersonasAcceso.Visible = value; }
        } 
        public bool EspecialidadesAccesoVisible
        {
            get { return EspecialidadesAcceso.Visible; }
            set { EspecialidadesAcceso.Visible = value; }
        } 
        public bool UsuariosAccesoVisible
        {
            get { return UsuariosAcceso.Visible; }
            set { UsuariosAcceso.Visible = value; }
        }
        public bool PlanesAccesoVisible
        {
            get { return PlanesAcceso.Visible; }
            set { PlanesAcceso.Visible = value; }
        }
        public bool ComisionesAccesoVisible
        {
            get { return ComisionesAcceso.Visible; }
            set { ComisionesAcceso.Visible = value; }
        }
        public bool MateriaAccesoVisible
        {
            get { return MateriaAcceso.Visible; }
            set { MateriaAcceso.Visible = value; }
        }
        public bool DocentesCursosAccesoVisible
        {
            get { return DocentesCursosAcceso.Visible; }
            set { DocentesCursosAcceso.Visible = value; }
        }
        public bool CursosAccesoVisible
        {
            get { return CursosAcceso.Visible; }
            set { CursosAcceso.Visible = value; }
        }
        public bool AlumnosInscripcionesAccesoVisible
        {
            get { return AlumnosInscripcionesAcceso.Visible; }
            set { AlumnosInscripcionesAcceso.Visible = value; }
        }

        protected void CerrarSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Loguin.aspx");
        }
    }
}