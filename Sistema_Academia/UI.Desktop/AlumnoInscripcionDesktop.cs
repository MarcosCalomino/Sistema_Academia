using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Desktop
{
    public class AlumnoInscripcionDesktop : ApplicationForm
    {
        AlumnoInscripcion? AlumnoInscripcionActual { get; set; }
        Persona? PersonaActual { get; set; }
        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();         
        }
        public AlumnoInscripcionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            CargarComboBoxCursos();
            CargarComboBoxAlumnos();
        }
        public AlumnoInscripcionDesktop(ModoForm modo, Persona persona) : this()
        {
            PersonaActual = persona;
            Modo = modo;
            SetInterfaceForAlum();
            CargarComboBoxAlumnos();
            CargarComboBoxCursos();
        }
        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;           
            AlumnoInscripcionActual = new AlumnoInscripcionLogic().GetOne(ID);
            CargarComboBoxAlumnos();
            CargarComboBoxCursos();
            MapearDeBaseDeDatos();
        }
        private void AlumnoInscripcionDesktop_Load(object sender, EventArgs e)
        {
            SetButtonAceptar(Modo, btnAceptar);
        }
        private void SetInterfaceForAlum()
        {
            this.txtNota.Visible = false;
            this.lblNota.Visible = false;
            this.lblAlumno.Visible = false;
            this.lblCondicion.Visible = false;
            this.cBoxAlumnos.Visible = false;
            this.cBoxCondicion.Visible = false;
            this.btnAceptar.Text = "Inscribirse";
            this.btnAceptar.FillColor = Color.LimeGreen;
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
                case ModoForm.Inscripcion:
                    if (string.IsNullOrWhiteSpace(this.cBoxCursos.Text) || cBoxCursos.Text.Equals("-- Seleccionar --"))
                        Notificar("Error", "Seleccione curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        GuardarCambios();
                        this.Close();
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
        public override void MapearABaseDeDatos()
        {
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion) || Modo.Equals(ModoForm.Inscripcion))
            {
                if (Modo.Equals(ModoForm.Alta))
                {
                    AlumnoInscripcionActual = new AlumnoInscripcion();
                    AlumnoInscripcionActual.State = BusinessEntity.States.New;
                }
                else if (Modo.Equals(ModoForm.Modificacion))
                {
                    AlumnoInscripcionActual!.State = BusinessEntity.States.Modified;
                }

                if(PersonaActual != null)
                {
                    AlumnoInscripcionActual = new AlumnoInscripcion();
                    AlumnoInscripcionActual.IDAlumno = PersonaActual.ID;
                    AlumnoInscripcionActual.IDCurso = Convert.ToInt32(cBoxCursos.SelectedValue);                   
                    AlumnoInscripcionActual.Condicion = "Cursando";
                    AlumnoInscripcionActual.Nota = 0;
                }
                else
                {
                    AlumnoInscripcionActual!.IDAlumno = Convert.ToInt32(cBoxAlumnos.SelectedValue);
                    AlumnoInscripcionActual!.IDCurso = Convert.ToInt32(cBoxCursos.SelectedValue);
                    AlumnoInscripcionActual!.Condicion = cBoxCondicion.SelectedItem!.ToString();
                    AlumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);
                }
                
            }
            else if (Modo == ModoForm.Baja)
            {
                AlumnoInscripcionActual!.State = BusinessEntity.States.Deleted;
            }


        }
        public override void GuardarCambios()
        {
            try
            {
                MapearABaseDeDatos();
                new AlumnoInscripcionLogic().Save(AlumnoInscripcionActual);
                this.Notificar(AlumnoInscripcionActual!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtNota.Text) || !isNumeric(this.txtNota.Text) || Convert.ToInt32(this.txtNota.Text) < 0)
            {
                Notificar("Error", "Formato incorrecto en nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxCondicion.Text) || cBoxCondicion.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione condicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxCursos.Text) || cBoxCursos.Text.Equals("-- Seleccionar --"))
            {
                Notificar("Error", "Seleccione curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxAlumnos.Text) || cBoxAlumnos.Text.Equals("0"))
            {
                Notificar("Error", "Seleccione alumno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void CargarComboBoxCursos()
        {
            var listaCursos = PersonaActual != null ? new CursoLogic().GetAll(PersonaActual.IDPlan) : new CursoLogic().GetAll();

             listaCursos = listaCursos.OrderBy(lp => lp.Descripcion).ToList();
             listaCursos.Insert(0, new Curso { ID = 0, Descripcion = "-- Seleccionar --" });
             cBoxCursos.DataSource = listaCursos;
             cBoxCursos.DisplayMember = "Descripcion"; // Propiedad a mostrar en el ComboBox
             cBoxCursos.ValueMember = "ID";
        }
        private void CargarComboBoxAlumnos()
        {
            List<Persona> listaAlumnos = new PersonaLogic().GetAll(2);
            listaAlumnos = listaAlumnos.OrderBy(la => la.Legajo).ToList();
            listaAlumnos.Insert(0, new Persona { ID = 0, Legajo = 0 });
            cBoxAlumnos.DataSource = listaAlumnos;
            cBoxAlumnos.DisplayMember = "Legajo";
            cBoxAlumnos.ValueMember = "ID";
        }
        public override void MapearDeBaseDeDatos()
        {
            this.txtID.Text = AlumnoInscripcionActual!.ID.ToString();
            this.txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            foreach (var item in cBoxCursos.Items)
            {
                if (item is Curso && ((Curso)item).ID == AlumnoInscripcionActual.IDCurso)
                {
                    cBoxCursos.SelectedItem = item;
                    break;
                }
            }
            foreach (var item in cBoxAlumnos.Items)
            {
                if (item is Persona && ((Persona)item).ID == AlumnoInscripcionActual.IDAlumno)
                {
                    cBoxAlumnos.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cBoxCondicion.Items)
            {
                if (AlumnoInscripcionActual.Condicion.Equals("Libre")) { cBoxCondicion.SelectedItem = "Libre"; break; }
                else if (AlumnoInscripcionActual.Condicion.Equals("Cursando")) { cBoxCondicion.SelectedItem = "Cursando"; break; }
                else if (AlumnoInscripcionActual.Condicion.Equals("Regular")) { cBoxCondicion.SelectedItem = "Regular"; break; }
                else if (AlumnoInscripcionActual.Condicion.Equals("Aprobada")) { cBoxCondicion.SelectedItem = "Aprobada"; break; }
            }
        }

        #region 
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            cBoxCursos = new ComboBox();
            label1 = new Label();
            lblAlumno = new Label();
            lblNota = new Label();
            btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            txtNota = new Guna.UI2.WinForms.Guna2TextBox();
            txtID = new Guna.UI2.WinForms.Guna2TextBox();
            cBoxAlumnos = new ComboBox();
            lblCondicion = new Label();
            cBoxCondicion = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 79);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 46;
            label2.Text = "Curso";
            // 
            // cBoxCursos
            // 
            cBoxCursos.FormattingEnabled = true;
            cBoxCursos.Location = new Point(102, 79);
            cBoxCursos.Name = "cBoxCursos";
            cBoxCursos.Size = new Size(234, 23);
            cBoxCursos.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 12);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 38;
            label1.Text = "ID";
            // 
            // lblAlumno
            // 
            lblAlumno.AutoSize = true;
            lblAlumno.Location = new Point(11, 47);
            lblAlumno.Name = "lblAlumno";
            lblAlumno.Size = new Size(50, 15);
            lblAlumno.TabIndex = 41;
            lblAlumno.Text = "Alumno";
            // 
            // lblNota
            // 
            lblNota.AutoSize = true;
            lblNota.Location = new Point(13, 137);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(33, 15);
            lblNota.TabIndex = 39;
            lblNota.Text = "Nota";
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.BorderRadius = 9;
            btnAceptar.CustomizableEdges = customizableEdges1;
            btnAceptar.DisabledState.BorderColor = Color.DarkGray;
            btnAceptar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAceptar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAceptar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAceptar.Font = new Font("Segoe UI", 9F);
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.Location = new Point(101, 184);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAceptar.Size = new Size(235, 29);
            btnAceptar.TabIndex = 42;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtNota
            // 
            txtNota.BorderRadius = 9;
            txtNota.CustomizableEdges = customizableEdges3;
            txtNota.DefaultText = "";
            txtNota.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNota.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNota.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNota.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNota.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNota.Font = new Font("Segoe UI", 9F);
            txtNota.ForeColor = Color.Black;
            txtNota.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNota.Location = new Point(101, 137);
            txtNota.Name = "txtNota";
            txtNota.PasswordChar = '\0';
            txtNota.PlaceholderText = "";
            txtNota.SelectedText = "";
            txtNota.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNota.Size = new Size(235, 29);
            txtNota.TabIndex = 43;
            // 
            // txtID
            // 
            txtID.BorderRadius = 9;
            txtID.CustomizableEdges = customizableEdges5;
            txtID.DefaultText = "";
            txtID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtID.FillColor = Color.LightGray;
            txtID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Font = new Font("Segoe UI", 9F);
            txtID.ForeColor = Color.Black;
            txtID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Location = new Point(101, 12);
            txtID.Name = "txtID";
            txtID.PasswordChar = '\0';
            txtID.PlaceholderText = "";
            txtID.ReadOnly = true;
            txtID.SelectedText = "";
            txtID.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtID.Size = new Size(235, 29);
            txtID.TabIndex = 44;
            // 
            // cBoxAlumnos
            // 
            cBoxAlumnos.FormattingEnabled = true;
            cBoxAlumnos.Location = new Point(102, 47);
            cBoxAlumnos.Name = "cBoxAlumnos";
            cBoxAlumnos.Size = new Size(234, 23);
            cBoxAlumnos.TabIndex = 40;
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.Location = new Point(11, 108);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(62, 15);
            lblCondicion.TabIndex = 48;
            lblCondicion.Text = "Condicion";
            // 
            // cBoxCondicion
            // 
            cBoxCondicion.FormattingEnabled = true;
            cBoxCondicion.Items.AddRange(new object[] { "Libre", "Cursando", "Regular", "Aprobada" });
            cBoxCondicion.Location = new Point(102, 108);
            cBoxCondicion.Name = "cBoxCondicion";
            cBoxCondicion.Size = new Size(234, 23);
            cBoxCondicion.TabIndex = 47;
            cBoxCondicion.Text = "-- Seleccionar --";
            // 
            // AlumnoInscripcionDesktop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(365, 225);
            Controls.Add(lblCondicion);
            Controls.Add(cBoxCondicion);
            Controls.Add(label2);
            Controls.Add(cBoxCursos);
            Controls.Add(label1);
            Controls.Add(lblAlumno);
            Controls.Add(lblNota);
            Controls.Add(btnAceptar);
            Controls.Add(txtNota);
            Controls.Add(txtID);
            Controls.Add(cBoxAlumnos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "AlumnoInscripcionDesktop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripciones de alumnos a materias";
            Load += AlumnoInscripcionDesktop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label2;
        private ComboBox cBoxCursos;
        private Label label1;
        private Label lblAlumno;
        private Label lblNota;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2TextBox txtNota;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Label lblCondicion;
        private ComboBox cBoxCondicion;
        private ComboBox cBoxAlumnos;
        #endregion
    }
}
