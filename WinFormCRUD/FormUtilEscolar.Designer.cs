namespace WinFormCRUD
{
    partial class FormUtilEscolar
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
            txtBoxNumero = new TextBox();
            txtBoxPrecio = new TextBox();
            txtBoxCodigoDeBarras = new TextBox();
            txtBoxMarca = new TextBox();
            txtBoxPeso = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnCerrar = new Button();
            cbxGarantia = new ComboBox();
            picBoxUtil = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoxUtil).BeginInit();
            SuspendLayout();
            // 
            // txtBoxNumero
            // 
            txtBoxNumero.Location = new Point(12, 11);
            txtBoxNumero.Name = "txtBoxNumero";
            txtBoxNumero.PlaceholderText = "Nro";
            txtBoxNumero.ReadOnly = true;
            txtBoxNumero.Size = new Size(224, 23);
            txtBoxNumero.TabIndex = 0;
            // 
            // txtBoxPrecio
            // 
            txtBoxPrecio.Location = new Point(12, 100);
            txtBoxPrecio.MaxLength = 6;
            txtBoxPrecio.Name = "txtBoxPrecio";
            txtBoxPrecio.PlaceholderText = "Precio (Requerido)";
            txtBoxPrecio.Size = new Size(224, 23);
            txtBoxPrecio.TabIndex = 1;
            txtBoxPrecio.KeyPress += txtBoxPrecio_KeyPress;
            // 
            // txtBoxCodigoDeBarras
            // 
            txtBoxCodigoDeBarras.Location = new Point(12, 40);
            txtBoxCodigoDeBarras.MaxLength = 4;
            txtBoxCodigoDeBarras.Name = "txtBoxCodigoDeBarras";
            txtBoxCodigoDeBarras.PlaceholderText = "Codigo de barras (Requerido)";
            txtBoxCodigoDeBarras.Size = new Size(224, 23);
            txtBoxCodigoDeBarras.TabIndex = 1;
            txtBoxCodigoDeBarras.KeyPress += txtBoxCodigoDeBarras_KeyPress;
            // 
            // txtBoxMarca
            // 
            txtBoxMarca.Location = new Point(12, 70);
            txtBoxMarca.MaxLength = 12;
            txtBoxMarca.Name = "txtBoxMarca";
            txtBoxMarca.PlaceholderText = "Marca (Requerido)";
            txtBoxMarca.Size = new Size(224, 23);
            txtBoxMarca.TabIndex = 2;
            txtBoxMarca.KeyPress += txtBoxMarca_KeyPress;
            // 
            // txtBoxPeso
            // 
            txtBoxPeso.Location = new Point(12, 128);
            txtBoxPeso.MaxLength = 3;
            txtBoxPeso.Name = "txtBoxPeso";
            txtBoxPeso.PlaceholderText = "Peso";
            txtBoxPeso.Size = new Size(224, 23);
            txtBoxPeso.TabIndex = 3;
            txtBoxPeso.KeyPress += txtBoxPeso_KeyPress;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Turquoise;
            btnAceptar.FlatAppearance.BorderColor = Color.DimGray;
            btnAceptar.FlatAppearance.BorderSize = 2;
            btnAceptar.FlatAppearance.MouseDownBackColor = Color.Turquoise;
            btnAceptar.FlatAppearance.MouseOverBackColor = Color.PaleTurquoise;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.ForeColor = SystemColors.ActiveCaptionText;
            btnAceptar.Location = new Point(12, 342);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(66, 32);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.FlatAppearance.BorderColor = Color.DimGray;
            btnCancelar.FlatAppearance.BorderSize = 2;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.RosyBrown;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(89, 342);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(66, 32);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.SteelBlue;
            btnCerrar.FlatAppearance.BorderColor = Color.DimGray;
            btnCerrar.FlatAppearance.BorderSize = 2;
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrar.Location = new Point(170, 342);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(66, 32);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cbxGarantia
            // 
            cbxGarantia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGarantia.FormattingEnabled = true;
            cbxGarantia.Items.AddRange(new object[] { "Garantía", "Si", "No" });
            cbxGarantia.Location = new Point(12, 158);
            cbxGarantia.Name = "cbxGarantia";
            cbxGarantia.Size = new Size(224, 23);
            cbxGarantia.TabIndex = 8;
            // 
            // picBoxUtil
            // 
            picBoxUtil.Location = new Point(12, 241);
            picBoxUtil.Name = "picBoxUtil";
            picBoxUtil.Size = new Size(224, 95);
            picBoxUtil.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxUtil.TabIndex = 12;
            picBoxUtil.TabStop = false;
            // 
            // FormUtilEscolar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(248, 382);
            ControlBox = false;
            Controls.Add(picBoxUtil);
            Controls.Add(cbxGarantia);
            Controls.Add(btnCerrar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtBoxPeso);
            Controls.Add(txtBoxMarca);
            Controls.Add(txtBoxCodigoDeBarras);
            Controls.Add(txtBoxPrecio);
            Controls.Add(txtBoxNumero);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUtilEscolar";
            StartPosition = FormStartPosition.Manual;
            Text = "FormUtilEscolar";
            ((System.ComponentModel.ISupportInitialize)picBoxUtil).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected TextBox txtBoxNumero;
        private TextBox txtBoxPrecio;
        private TextBox txtBoxCodigoDeBarras;
        private TextBox txtBoxMarca;
        protected TextBox txtBoxPeso;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnCerrar;
        protected ComboBox cbxGarantia;
        private PictureBox picBoxUtil;
    }
}