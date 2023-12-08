namespace WinFormCRUD
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            pnlContenedor = new Panel();
            btnCancelar = new Button();
            btnAcceder = new Button();
            lblLogin = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            pnlContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.GhostWhite;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.ForeColor = Color.DimGray;
            txtCorreo.Location = new Point(31, 75);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(366, 16);
            txtCorreo.TabIndex = 2;
            txtCorreo.Text = "CORREO";
            txtCorreo.Enter += txtCorreo_Enter;
            txtCorreo.Leave += txtCorreo_Leave;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = Color.GhostWhite;
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.ForeColor = Color.DimGray;
            txtContraseña.Location = new Point(31, 145);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(366, 16);
            txtContraseña.TabIndex = 3;
            txtContraseña.Text = "CONTRASEÑA";
            txtContraseña.Enter += txtContraseña_Enter;
            txtContraseña.Leave += txtContraseña_Leave;
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.GhostWhite;
            pnlContenedor.Controls.Add(btnCancelar);
            pnlContenedor.Controls.Add(btnAcceder);
            pnlContenedor.Controls.Add(lblLogin);
            pnlContenedor.Controls.Add(panel3);
            pnlContenedor.Controls.Add(panel2);
            pnlContenedor.Controls.Add(txtCorreo);
            pnlContenedor.Controls.Add(txtContraseña);
            pnlContenedor.Location = new Point(93, 39);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(428, 262);
            pnlContenedor.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.FlatAppearance.BorderColor = Color.DimGray;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.RosyBrown;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = SystemColors.Control;
            btnCancelar.Location = new Point(233, 215);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(164, 30);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.SteelBlue;
            btnAcceder.FlatAppearance.BorderColor = Color.DimGray;
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnAcceder.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAcceder.ForeColor = SystemColors.Control;
            btnAcceder.Location = new Point(31, 215);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(164, 30);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogin.ForeColor = Color.DimGray;
            lblLogin.Location = new Point(168, 16);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(83, 29);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "LOGIN";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Location = new Point(31, 161);
            panel3.Name = "panel3";
            panel3.Size = new Size(366, 1);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Location = new Point(33, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(366, 1);
            panel2.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(623, 348);
            Controls.Add(pnlContenedor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += Login_FormClosing;
            pnlContenedor.ResumeLayout(false);
            pnlContenedor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Panel pnlContenedor;
        private Panel panel2;
        private Label lblLogin;
        private Panel panel3;
        private Button btnCancelar;
        private Button btnAcceder;
    }
}