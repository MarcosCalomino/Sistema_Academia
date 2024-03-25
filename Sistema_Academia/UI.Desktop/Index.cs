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
    public partial class IndexAdmin : Form
    {
        private Loguin loginActual;
        private Persona personaActual;
        public IndexAdmin(Usuario usuarioActual, Loguin loguin)
        {
            InitializeComponent();
            loginActual = loguin;
            personaActual = new PersonaLogic().GetOne(usuarioActual.Id_Persona);
            SetInterface(personaActual);
        }
        private void SetInterface(Persona personaActual)
        {
            if (personaActual.TipoPersona == 1) //profesores
            {
                btnPersonas.Visible = false;
                btnUsuarios.Visible = false;
                btnEspecialidades.Visible = false;
                btnPlanes.Visible = false;
                btnComisiones.Visible = false;
                btnMaterias.Visible = false;
                btnCursos.Visible = false;
                btnInscribirse.Visible = false;

            }
            else if (personaActual.TipoPersona == 2) //alumnos
            {
                btnPersonas.Visible = false;
                btnUsuarios.Visible = false;
                btnEspecialidades.Visible = false;
                btnPlanes.Visible = false;
                btnComisiones.Visible = false;
                btnMaterias.Visible = false;
                btnCursos.Visible = false;
                btnDocentesCursos.Visible = false;
            }
            else if (personaActual.TipoPersona == 3) //admin
            {

            }
        }
        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false; // Ocultar el formulario Index
            loginActual.Visible = true; // Hacer visible el formulario Login
        }
        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPersonas_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Personas)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Personas personasForm = new Personas();
            personasForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            personasForm.Show(); // Mostrar el formulario Personas
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Usuarios)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Usuarios usuariosForm = new Usuarios();
            usuariosForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            usuariosForm.Show(); // Mostrar el formulario Personas
        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Especialidades)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Especialidades especialidadesForm = new Especialidades();
            especialidadesForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            especialidadesForm.Show(); // Mostrar el formulario Personas
        }
        private void btnPlanes_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Planes)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Planes planesForm = new Planes();
            planesForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            planesForm.Show(); // Mostrar el formulario Personas
        }
        private void btnComisiones_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Comisiones)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Comisiones comisionesForm = new Comisiones();
            comisionesForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            comisionesForm.Show(); // Mostrar el formulario Personas
        }
        private void btnMaterias_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Materias)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Materias materiasForm = new Materias();
            materiasForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            materiasForm.Show(); // Mostrar el formulario Personas
        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Personas ya está abierto como un formulario hijo
            foreach (Form form in this.MdiChildren)
            {
                if (form is Cursos)
                {
                    form.Activate(); // Si ya está abierto, activarlo y salir del método
                    return;
                }
            }
            // Si el formulario Personas no está abierto, crear una nueva instancia y mostrarlo como un formulario hijo
            Cursos cursosForm = new Cursos();
            cursosForm.MdiParent = this; // Establecer el formulario Index como el contenedor principal
            cursosForm.Show(); // Mostrar el formulario Personas
        }
        private void btnAlumnosInscripciones_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is AlumnosInscripciones)
                {
                    form.Activate();
                    return;
                }
            }

            Form alumnosInscripcionesForm;
            if (personaActual.TipoPersona == 2) //Alumno
            {
                alumnosInscripcionesForm = new AlumnosInscripciones(personaActual);
                alumnosInscripcionesForm.MdiParent = this;
                alumnosInscripcionesForm.Show();
            }
            else //Admin
            {
                alumnosInscripcionesForm = new AlumnosInscripciones();
                alumnosInscripcionesForm.MdiParent = this;
                alumnosInscripcionesForm.Show();
            }
        }
        private void btnDocentesCursos_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is DocentesCursos)
                {
                    form.Activate();
                    return;
                }
            }

            Form docentesCursosForm;
            if (personaActual.TipoPersona == 1) //Docente
            {
                docentesCursosForm = new AlumnosInscripciones(personaActual);
                docentesCursosForm.MdiParent = this;
                docentesCursosForm.Show();
            }
            else //Admin
            {
                docentesCursosForm = new DocentesCursos();
                docentesCursosForm.MdiParent = this;
                docentesCursosForm.Show();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is Reportes)
                {
                    form.Activate(); 
                    return;
                }
            }

            Reportes reportesForm = new Reportes();
            reportesForm.MdiParent = this; 
            reportesForm.Show(); 
        }
    }
}
