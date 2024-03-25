namespace UI.Desktop
{
    partial class AlumnosInscripciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnosInscripciones));
            toolStripContainer1 = new ToolStripContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvAlumnosInscripciones = new DataGridView();
            btnActualizar = new Guna.UI2.WinForms.Guna2Button();
            btnSalir = new Guna.UI2.WinForms.Guna2Button();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            ID = new DataGridViewTextBoxColumn();
            IDCurso = new DataGridViewTextBoxColumn();
            IDAlumno = new DataGridViewTextBoxColumn();
            DescripcionCurso = new DataGridViewTextBoxColumn();
            LegajoAlumno = new DataGridViewTextBoxColumn();
            Condicion = new DataGridViewTextBoxColumn();
            Nota = new DataGridViewTextBoxColumn();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnosInscripciones).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanel1);
            toolStripContainer1.ContentPanel.Size = new Size(800, 425);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 450);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(dgvAlumnosInscripciones, 0, 0);
            tableLayoutPanel1.Controls.Add(btnActualizar, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSalir, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 425);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvAlumnosInscripciones
            // 
            dgvAlumnosInscripciones.AllowUserToAddRows = false;
            dgvAlumnosInscripciones.AllowUserToDeleteRows = false;
            dgvAlumnosInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnosInscripciones.Columns.AddRange(new DataGridViewColumn[] { ID, IDCurso, IDAlumno, DescripcionCurso, LegajoAlumno, Condicion, Nota });
            tableLayoutPanel1.SetColumnSpan(dgvAlumnosInscripciones, 2);
            dgvAlumnosInscripciones.Dock = DockStyle.Fill;
            dgvAlumnosInscripciones.Location = new Point(3, 3);
            dgvAlumnosInscripciones.Name = "dgvAlumnosInscripciones";
            dgvAlumnosInscripciones.ReadOnly = true;
            dgvAlumnosInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnosInscripciones.Size = new Size(794, 380);
            dgvAlumnosInscripciones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BorderRadius = 9;
            btnActualizar.CustomizableEdges = customizableEdges1;
            btnActualizar.DisabledState.BorderColor = Color.DarkGray;
            btnActualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnActualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnActualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnActualizar.Font = new Font("Segoe UI", 9F);
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.Location = new Point(431, 389);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnActualizar.Size = new Size(180, 33);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BorderRadius = 9;
            btnSalir.CustomizableEdges = customizableEdges3;
            btnSalir.DisabledState.BorderColor = Color.DarkGray;
            btnSalir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSalir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSalir.FillColor = Color.LightCoral;
            btnSalir.Font = new Font("Segoe UI", 9F);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(617, 389);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSalir.Size = new Size(180, 33);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar });
            toolStrip1.Location = new Point(3, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(93, 25);
            toolStrip1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageTransparentColor = Color.Magenta;
            btnNuevo.Margin = new Padding(2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(23, 21);
            btnNuevo.Text = "toolStripButton1";
            btnNuevo.ToolTipText = "Nueva inscripcion";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Margin = new Padding(2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(23, 21);
            btnEditar.Text = "toolStripButton2";
            btnEditar.ToolTipText = "Editar inscripcion";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.ImageTransparentColor = Color.Magenta;
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(23, 21);
            btnEliminar.Text = "btnEliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // IDCurso
            // 
            IDCurso.DataPropertyName = "IDCurso";
            IDCurso.HeaderText = "Id Curso";
            IDCurso.Name = "IDCurso";
            IDCurso.ReadOnly = true;
            IDCurso.Visible = false;
            // 
            // IDAlumno
            // 
            IDAlumno.DataPropertyName = "IDAlumno";
            IDAlumno.HeaderText = "Id Alumno";
            IDAlumno.Name = "IDAlumno";
            IDAlumno.ReadOnly = true;
            IDAlumno.Visible = false;
            // 
            // DescripcionCurso
            // 
            DescripcionCurso.DataPropertyName = "DescripcionCurso";
            DescripcionCurso.HeaderText = "Curso";
            DescripcionCurso.Name = "DescripcionCurso";
            DescripcionCurso.ReadOnly = true;
            // 
            // LegajoAlumno
            // 
            LegajoAlumno.DataPropertyName = "LegajoAlumno";
            LegajoAlumno.HeaderText = "Alumno";
            LegajoAlumno.Name = "LegajoAlumno";
            LegajoAlumno.ReadOnly = true;
            // 
            // Condicion
            // 
            Condicion.DataPropertyName = "Condicion";
            Condicion.HeaderText = "Condicion";
            Condicion.Name = "Condicion";
            Condicion.ReadOnly = true;
            // 
            // Nota
            // 
            Nota.DataPropertyName = "Nota";
            Nota.HeaderText = "Nota";
            Nota.Name = "Nota";
            Nota.ReadOnly = true;
            // 
            // AlumnosInscripciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Name = "AlumnosInscripciones";
            Text = "AlumnosInscripciones";
            Load += AlumnosInscripciones_Load;
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlumnosInscripciones).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnEditar;
        private ToolStripButton btnEliminar;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvAlumnosInscripciones;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn IDCurso;
        private DataGridViewTextBoxColumn IDAlumno;
        private DataGridViewTextBoxColumn DescripcionCurso;
        private DataGridViewTextBoxColumn LegajoAlumno;
        private DataGridViewTextBoxColumn Condicion;
        private DataGridViewTextBoxColumn Nota;
    }
}