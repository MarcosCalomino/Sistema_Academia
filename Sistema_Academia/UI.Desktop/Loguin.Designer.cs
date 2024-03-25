namespace UI.Desktop
{
    partial class Loguin
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
            btnAcceder = new Guna.UI2.WinForms.Guna2Button();
            txtNombreUsuarios = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnAcceder
            // 
            btnAcceder.BorderColor = Color.FromArgb(64, 64, 64);
            btnAcceder.BorderRadius = 9;
            btnAcceder.CustomizableEdges = customizableEdges1;
            btnAcceder.DisabledState.BorderColor = Color.DarkGray;
            btnAcceder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAcceder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAcceder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAcceder.FillColor = Color.Lime;
            btnAcceder.Font = new Font("Segoe UI", 9F);
            btnAcceder.ForeColor = Color.Black;
            btnAcceder.Location = new Point(233, 140);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAcceder.Size = new Size(227, 45);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "Acceder";
            btnAcceder.Click += btnAcceder_Click;
            // 
            // txtNombreUsuarios
            // 
            txtNombreUsuarios.BorderColor = Color.FromArgb(64, 64, 64);
            txtNombreUsuarios.BorderRadius = 5;
            txtNombreUsuarios.CustomizableEdges = customizableEdges3;
            txtNombreUsuarios.DefaultText = "";
            txtNombreUsuarios.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNombreUsuarios.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNombreUsuarios.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNombreUsuarios.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNombreUsuarios.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNombreUsuarios.Font = new Font("Segoe UI", 9F);
            txtNombreUsuarios.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNombreUsuarios.Location = new Point(12, 27);
            txtNombreUsuarios.Name = "txtNombreUsuarios";
            txtNombreUsuarios.PasswordChar = '\0';
            txtNombreUsuarios.PlaceholderText = "";
            txtNombreUsuarios.SelectedText = "";
            txtNombreUsuarios.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNombreUsuarios.Size = new Size(640, 36);
            txtNombreUsuarios.TabIndex = 1;
            txtNombreUsuarios.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(64, 64, 64);
            txtPassword.BorderRadius = 5;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(12, 88);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(640, 36);
            txtPassword.TabIndex = 2;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // Loguin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 203);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtNombreUsuarios);
            Controls.Add(btnAcceder);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Loguin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loguin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAcceder;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreUsuarios;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label label1;
        private Label label2;
    }
}