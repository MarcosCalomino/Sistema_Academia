namespace UI.Desktop
{
    partial class ComisionDesktop
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cBoxPlanes = new ComboBox();
            lblPlan = new Label();
            label1 = new Label();
            label2 = new Label();
            txtID = new Guna.UI2.WinForms.Guna2TextBox();
            btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            txtAnio = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // cBoxPlanes
            // 
            cBoxPlanes.FormattingEnabled = true;
            cBoxPlanes.Location = new Point(89, 114);
            cBoxPlanes.Name = "cBoxPlanes";
            cBoxPlanes.Size = new Size(234, 23);
            cBoxPlanes.TabIndex = 18;
            // 
            // lblPlan
            // 
            lblPlan.AutoSize = true;
            lblPlan.Location = new Point(14, 118);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(30, 15);
            lblPlan.TabIndex = 17;
            lblPlan.Text = "Plan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 12;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 51);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 15;
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
            txtID.Location = new Point(89, 9);
            txtID.Name = "txtID";
            txtID.PasswordChar = '\0';
            txtID.PlaceholderText = "";
            txtID.ReadOnly = true;
            txtID.SelectedText = "";
            txtID.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtID.Size = new Size(234, 29);
            txtID.TabIndex = 13;
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
            btnAceptar.Location = new Point(89, 154);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAceptar.Size = new Size(235, 29);
            btnAceptar.TabIndex = 16;
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
            txtDescripcion.Location = new Point(89, 44);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PasswordChar = '\0';
            txtDescripcion.PlaceholderText = "";
            txtDescripcion.SelectedText = "";
            txtDescripcion.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDescripcion.Size = new Size(234, 29);
            txtDescripcion.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 86);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 20;
            label3.Text = "Año";
            // 
            // txtAnio
            // 
            txtAnio.BorderRadius = 9;
            txtAnio.CustomizableEdges = customizableEdges7;
            txtAnio.DefaultText = "";
            txtAnio.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAnio.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAnio.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAnio.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAnio.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAnio.Font = new Font("Segoe UI", 9F);
            txtAnio.ForeColor = Color.Black;
            txtAnio.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAnio.Location = new Point(89, 79);
            txtAnio.Name = "txtAnio";
            txtAnio.PasswordChar = '\0';
            txtAnio.PlaceholderText = "";
            txtAnio.SelectedText = "";
            txtAnio.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtAnio.Size = new Size(234, 29);
            txtAnio.TabIndex = 19;
            // 
            // ComisionDesktop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 194);
            Controls.Add(label3);
            Controls.Add(txtAnio);
            Controls.Add(cBoxPlanes);
            Controls.Add(lblPlan);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtID);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "ComisionDesktop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comision";
            Load += ComisionDesktop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cBoxPlanes;
        private Label lblPlan;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtAnio;
    }
}