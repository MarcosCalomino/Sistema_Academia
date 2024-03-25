namespace UI.Desktop
{
    partial class Materias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materias));
            toolStripContainer1 = new ToolStripContainer();
            tblPanel = new TableLayoutPanel();
            btnSalir = new Guna.UI2.WinForms.Guna2Button();
            dgvMaterias = new DataGridView();
            btnActualizar = new Guna.UI2.WinForms.Guna2Button();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            ID = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            HsSemanales = new DataGridViewTextBoxColumn();
            HsTotales = new DataGridViewTextBoxColumn();
            Plan = new DataGridViewTextBoxColumn();
            IDPlan = new DataGridViewTextBoxColumn();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tblPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tblPanel);
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
            // tblPanel
            // 
            tblPanel.ColumnCount = 2;
            tblPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanel.ColumnStyles.Add(new ColumnStyle());
            tblPanel.Controls.Add(btnSalir, 1, 1);
            tblPanel.Controls.Add(dgvMaterias, 0, 0);
            tblPanel.Controls.Add(btnActualizar, 0, 1);
            tblPanel.Dock = DockStyle.Fill;
            tblPanel.Location = new Point(0, 0);
            tblPanel.Name = "tblPanel";
            tblPanel.RowCount = 2;
            tblPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanel.RowStyles.Add(new RowStyle());
            tblPanel.Size = new Size(800, 425);
            tblPanel.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BorderRadius = 9;
            btnSalir.CustomizableEdges = customizableEdges1;
            btnSalir.DisabledState.BorderColor = Color.DarkGray;
            btnSalir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSalir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSalir.FillColor = Color.LightCoral;
            btnSalir.Font = new Font("Segoe UI", 9F);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(617, 389);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSalir.Size = new Size(180, 33);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvMaterias
            // 
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.AllowUserToDeleteRows = false;
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Columns.AddRange(new DataGridViewColumn[] { ID, Descripcion, HsSemanales, HsTotales, Plan, IDPlan });
            tblPanel.SetColumnSpan(dgvMaterias, 2);
            dgvMaterias.Dock = DockStyle.Fill;
            dgvMaterias.Location = new Point(3, 3);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.ReadOnly = true;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.Size = new Size(794, 380);
            dgvMaterias.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BorderRadius = 9;
            btnActualizar.CustomizableEdges = customizableEdges3;
            btnActualizar.DisabledState.BorderColor = Color.DarkGray;
            btnActualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnActualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnActualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnActualizar.Font = new Font("Segoe UI", 9F);
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.Location = new Point(431, 389);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnActualizar.Size = new Size(180, 33);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
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
            btnNuevo.ToolTipText = "Registrar materia";
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
            btnEditar.ToolTipText = "Editar materia";
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
            btnEliminar.Text = "toolStripButton3";
            btnEliminar.ToolTipText = "Eliminar materia";
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
            // Descripcion
            // 
            Descripcion.DataPropertyName = "Descripcion";
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // HsSemanales
            // 
            HsSemanales.DataPropertyName = "HSSemanales";
            HsSemanales.HeaderText = "Horas semanales";
            HsSemanales.Name = "HsSemanales";
            HsSemanales.ReadOnly = true;
            // 
            // HsTotales
            // 
            HsTotales.DataPropertyName = "HSTotales";
            HsTotales.HeaderText = "Horas totales";
            HsTotales.Name = "HsTotales";
            HsTotales.ReadOnly = true;
            // 
            // Plan
            // 
            Plan.DataPropertyName = "DescripcionPlan";
            Plan.HeaderText = "Plan";
            Plan.Name = "Plan";
            Plan.ReadOnly = true;
            // 
            // IDPlan
            // 
            IDPlan.DataPropertyName = "IDPlan";
            IDPlan.HeaderText = "Id Plan";
            IDPlan.Name = "IDPlan";
            IDPlan.ReadOnly = true;
            IDPlan.Visible = false;
            // 
            // Materias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Name = "Materias";
            Text = "Materias";
            Load += Materias_Load;
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            tblPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
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
        private TableLayoutPanel tblPanel;
        private DataGridView dgvMaterias;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private Guna.UI2.WinForms.Guna2Button btnActualizar;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn HsSemanales;
        private DataGridViewTextBoxColumn HsTotales;
        private DataGridViewTextBoxColumn Plan;
        private DataGridViewTextBoxColumn IDPlan;
    }
}