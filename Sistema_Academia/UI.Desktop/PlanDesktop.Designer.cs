namespace UI.Desktop
{
    partial class PlanDesktop
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            txtID = new Guna.UI2.WinForms.Guna2TextBox();
            btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            lblEspecialidad = new Label();
            cBoxEspecialidad = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 18);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 5;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 54);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 8;
            label2.Text = "Descripcion";
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
            txtID.Location = new Point(84, 12);
            txtID.Name = "txtID";
            txtID.PasswordChar = '\0';
            txtID.PlaceholderText = "";
            txtID.ReadOnly = true;
            txtID.SelectedText = "";
            txtID.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtID.Size = new Size(234, 29);
            txtID.TabIndex = 6;
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
            btnAceptar.Location = new Point(84, 124);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAceptar.Size = new Size(235, 29);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderRadius = 9;
            txtDescripcion.CustomizableEdges = customizableEdges5;
            txtDescripcion.DefaultText = "";
            txtDescripcion.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDescripcion.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDescripcion.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDescripcion.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDescripcion.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.ForeColor = Color.Black;
            txtDescripcion.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescripcion.Location = new Point(84, 47);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PasswordChar = '\0';
            txtDescripcion.PlaceholderText = "";
            txtDescripcion.SelectedText = "";
            txtDescripcion.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDescripcion.Size = new Size(234, 29);
            txtDescripcion.TabIndex = 7;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(9, 88);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(72, 15);
            lblEspecialidad.TabIndex = 10;
            lblEspecialidad.Text = "Especialidad";
            // 
            // cBoxEspecialidad
            // 
            cBoxEspecialidad.FormattingEnabled = true;
            cBoxEspecialidad.Location = new Point(84, 84);
            cBoxEspecialidad.Name = "cBoxEspecialidad";
            cBoxEspecialidad.Size = new Size(234, 23);
            cBoxEspecialidad.TabIndex = 11;
            // 
            // PlanDesktop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 164);
            Controls.Add(cBoxEspecialidad);
            Controls.Add(lblEspecialidad);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtID);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "PlanDesktop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plan";
            Load += PlanDesktop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Label lblEspecialidad;
        private ComboBox cBoxEspecialidad;
    }
}