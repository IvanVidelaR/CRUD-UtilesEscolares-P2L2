namespace WinFormCRUD
{
    partial class FormVisualizadorLogins
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
            rtxtBox = new RichTextBox();
            lblUsuarios = new Label();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // rtxtBox
            // 
            rtxtBox.BackColor = SystemColors.InactiveCaption;
            rtxtBox.Location = new Point(12, 32);
            rtxtBox.Name = "rtxtBox";
            rtxtBox.Size = new Size(226, 314);
            rtxtBox.TabIndex = 0;
            rtxtBox.Text = "";
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblUsuarios.ForeColor = SystemColors.ButtonFace;
            lblUsuarios.Location = new Point(64, 7);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(174, 22);
            lblUsuarios.TabIndex = 1;
            lblUsuarios.Text = "Usuarios Logueados";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.FlatAppearance.BorderColor = Color.DimGray;
            btnCerrar.FlatAppearance.BorderSize = 2;
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.RosyBrown;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrar.Location = new Point(12, 352);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(76, 29);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormVisualizadorLogins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(250, 384);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(lblUsuarios);
            Controls.Add(rtxtBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormVisualizadorLogins";
            StartPosition = FormStartPosition.Manual;
            Text = "FormVisualizadorLogins";
            Load += FormVisualizadorLogins_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtxtBox;
        private Label lblUsuarios;
        private Button btnCerrar;
    }
}