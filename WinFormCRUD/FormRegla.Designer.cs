namespace WinFormCRUD
{
    partial class FormRegla
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
            txtBoxLongitud = new TextBox();
            cbxFlexibilidad = new ComboBox();
            SuspendLayout();
            // 
            // txtBoxLongitud
            // 
            txtBoxLongitud.Location = new Point(12, 185);
            txtBoxLongitud.MaxLength = 4;
            txtBoxLongitud.Name = "txtBoxLongitud";
            txtBoxLongitud.PlaceholderText = "Longitud (Requerido)";
            txtBoxLongitud.Size = new Size(224, 23);
            txtBoxLongitud.TabIndex = 9;
            txtBoxLongitud.KeyPress += txtBoxLongitud_KeyPress;
            // 
            // cbxFlexibilidad
            // 
            cbxFlexibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFlexibilidad.FormattingEnabled = true;
            cbxFlexibilidad.Items.AddRange(new object[] { "Flexibilidad (Requerido)", "Si", "No" });
            cbxFlexibilidad.Location = new Point(12, 212);
            cbxFlexibilidad.Name = "cbxFlexibilidad";
            cbxFlexibilidad.Size = new Size(224, 23);
            cbxFlexibilidad.TabIndex = 10;
            // 
            // FormRegla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 387);
            Controls.Add(cbxFlexibilidad);
            Controls.Add(txtBoxLongitud);
            Name = "FormRegla";
            Text = "FormRegla";
            Load += FormRegla_Load;
            Controls.SetChildIndex(txtBoxLongitud, 0);
            Controls.SetChildIndex(cbxFlexibilidad, 0);
            Controls.SetChildIndex(txtBoxNumero, 0);
            Controls.SetChildIndex(txtBoxPeso, 0);
            Controls.SetChildIndex(cbxGarantia, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxLongitud;
        private ComboBox cbxFlexibilidad;
    }
}