namespace WinFormCRUD
{
    partial class FormBienvenida
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
            lblBienvenida = new Label();
            lblUsuario = new Panel();
            lblCargando = new Label();
            lblPorcentaje = new Label();
            progressBar1 = new ProgressBar();
            lblUser = new Label();
            lblUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenida.ForeColor = Color.SteelBlue;
            lblBienvenida.Location = new Point(58, 42);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(256, 42);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "BIENVENIDO";
            // 
            // lblUsuario
            // 
            lblUsuario.BackColor = Color.GhostWhite;
            lblUsuario.Controls.Add(lblCargando);
            lblUsuario.Controls.Add(lblPorcentaje);
            lblUsuario.Controls.Add(progressBar1);
            lblUsuario.Controls.Add(lblUser);
            lblUsuario.Controls.Add(lblBienvenida);
            lblUsuario.Location = new Point(93, 37);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(428, 264);
            lblUsuario.TabIndex = 1;
            // 
            // lblCargando
            // 
            lblCargando.AutoSize = true;
            lblCargando.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCargando.ForeColor = Color.DimGray;
            lblCargando.Location = new Point(67, 215);
            lblCargando.Name = "lblCargando";
            lblCargando.Size = new Size(79, 20);
            lblCargando.TabIndex = 4;
            lblCargando.Text = "Cargando...";
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.BackColor = Color.Transparent;
            lblPorcentaje.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPorcentaje.ForeColor = Color.DimGray;
            lblPorcentaje.Location = new Point(337, 215);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(28, 20);
            lblPorcentaje.TabIndex = 3;
            lblPorcentaje.Text = "0%";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.Turquoise;
            progressBar1.ForeColor = SystemColors.ActiveBorder;
            progressBar1.Location = new Point(67, 178);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(303, 34);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 2;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.ForeColor = Color.LightSlateGray;
            lblUser.Location = new Point(187, 95);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(139, 31);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username";
            // 
            // FormBienvenida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(623, 348);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormBienvenida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBienvenida";
            FormClosing += FormBienvenida_FormClosing;
            Load += FormBienvenida_Load;
            lblUsuario.ResumeLayout(false);
            lblUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBienvenida;
        private Panel lblUsuario;
        private Label lblUser;
        private ProgressBar progressBar1;
        private Label lblPorcentaje;
        private Label lblCargando;
    }
}