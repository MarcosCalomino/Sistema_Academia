namespace UI.Desktop
{
    partial class Reportes
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnReporteCursos = new Guna.UI2.WinForms.Guna2Button();
            btnReportePlanes = new Guna.UI2.WinForms.Guna2Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnReporteCursos, 1, 0);
            tableLayoutPanel1.Controls.Add(btnReportePlanes, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnReporteCursos
            // 
            btnReporteCursos.BorderRadius = 9;
            btnReporteCursos.CustomizableEdges = customizableEdges1;
            btnReporteCursos.DisabledState.BorderColor = Color.DarkGray;
            btnReporteCursos.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReporteCursos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReporteCursos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReporteCursos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReporteCursos.ForeColor = Color.Black;
            btnReporteCursos.Location = new Point(189, 3);
            btnReporteCursos.Name = "btnReporteCursos";
            btnReporteCursos.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReporteCursos.Size = new Size(180, 31);
            btnReporteCursos.TabIndex = 1;
            btnReporteCursos.Text = "Generar reporte de cursos";
            btnReporteCursos.Click += btnReporteCursos_Click;
            // 
            // btnReportePlanes
            // 
            btnReportePlanes.BorderRadius = 9;
            btnReportePlanes.CustomizableEdges = customizableEdges3;
            btnReportePlanes.DisabledState.BorderColor = Color.DarkGray;
            btnReportePlanes.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReportePlanes.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReportePlanes.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReportePlanes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReportePlanes.ForeColor = Color.Black;
            btnReportePlanes.Location = new Point(3, 3);
            btnReportePlanes.Name = "btnReportePlanes";
            btnReportePlanes.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnReportePlanes.Size = new Size(180, 31);
            btnReportePlanes.TabIndex = 0;
            btnReportePlanes.Text = "Generar reporte de planes";
            btnReportePlanes.Click += btnReportePlanes_Click;
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Reportes";
            Text = "Reportes";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnReporteCursos;
        private Guna.UI2.WinForms.Guna2Button btnReportePlanes;
    }
}