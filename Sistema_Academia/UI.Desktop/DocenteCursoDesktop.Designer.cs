namespace UI.Desktop
{
    partial class DocenteCursoDesktop
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
            cBoxCurso = new ComboBox();
            lblPlan = new Label();
            label1 = new Label();
            txtID = new Guna.UI2.WinForms.Guna2TextBox();
            btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            cBoxDocente = new ComboBox();
            label2 = new Label();
            cBoxCargo = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // cBoxCurso
            // 
            cBoxCurso.FormattingEnabled = true;
            cBoxCurso.Items.AddRange(new object[] { "-- Seleccionar --", "Docente Practica", "Docente Teoria", "Ayudante " });
            cBoxCurso.Location = new Point(79, 44);
            cBoxCurso.Name = "cBoxCurso";
            cBoxCurso.Size = new Size(234, 23);
            cBoxCurso.TabIndex = 32;
            // 
            // lblPlan
            // 
            lblPlan.AutoSize = true;
            lblPlan.Location = new Point(12, 44);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(38, 15);
            lblPlan.TabIndex = 31;
            lblPlan.Text = "Curso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 28;
            label1.Text = "ID";
            // 
            // txtID
            // 
            txtID.BorderRadius = 9;
            txtID.CustomizableEdges = customizableEdges1;
            txtID.DefaultText = "";
            txtID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtID.FillColor = Color.LightGray;
            txtID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Font = new Font("Segoe UI", 9F);
            txtID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtID.Location = new Point(79, 9);
            txtID.Name = "txtID";
            txtID.PasswordChar = '\0';
            txtID.PlaceholderText = "";
            txtID.ReadOnly = true;
            txtID.SelectedText = "";
            txtID.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtID.Size = new Size(234, 29);
            txtID.TabIndex = 29;
            // 
            // btnAceptar
            // 
            btnAceptar.BorderRadius = 9;
            btnAceptar.CustomizableEdges = customizableEdges3;
            btnAceptar.DisabledState.BorderColor = Color.DarkGray;
            btnAceptar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAceptar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAceptar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAceptar.Font = new Font("Segoe UI", 9F);
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.Location = new Point(79, 133);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAceptar.Size = new Size(235, 29);
            btnAceptar.TabIndex = 30;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cBoxDocente
            // 
            cBoxDocente.FormattingEnabled = true;
            cBoxDocente.Location = new Point(79, 75);
            cBoxDocente.Name = "cBoxDocente";
            cBoxDocente.Size = new Size(234, 23);
            cBoxDocente.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 33;
            label2.Text = "Docente";
            // 
            // cBoxCargo
            // 
            cBoxCargo.FormattingEnabled = true;
            cBoxCargo.Items.AddRange(new object[] { "Docente de practica", "Docente de teoria", "Ayudante" });
            cBoxCargo.Location = new Point(79, 104);
            cBoxCargo.Name = "cBoxCargo";
            cBoxCargo.Size = new Size(234, 23);
            cBoxCargo.TabIndex = 36;
            cBoxCargo.Text = "-- Seleccionar --";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 35;
            label3.Text = "Cargo";
            // 
            // DocenteCursoDesktop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 173);
            Controls.Add(cBoxCargo);
            Controls.Add(label3);
            Controls.Add(cBoxDocente);
            Controls.Add(label2);
            Controls.Add(cBoxCurso);
            Controls.Add(lblPlan);
            Controls.Add(label1);
            Controls.Add(txtID);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "DocenteCursoDesktop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docente-Curso";
            Load += DocenteCursoDesktop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cBoxCurso;
        private Label lblPlan;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private ComboBox cBoxDocente;
        private Label label2;
        private ComboBox cBoxCargo;
        private Label label3;
    }
}