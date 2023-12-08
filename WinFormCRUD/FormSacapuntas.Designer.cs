namespace WinFormCRUD
{
    partial class FormSacapuntas
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
            cbxTipoSacapuntas = new ComboBox();
            cbxMaterial = new ComboBox();
            SuspendLayout();
            // 
            // cbxTipoSacapuntas
            // 
            cbxTipoSacapuntas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoSacapuntas.FormattingEnabled = true;
            cbxTipoSacapuntas.Location = new Point(12, 186);
            cbxTipoSacapuntas.Name = "cbxTipoSacapuntas";
            cbxTipoSacapuntas.Size = new Size(224, 23);
            cbxTipoSacapuntas.TabIndex = 9;
            // 
            // cbxMaterial
            // 
            cbxMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaterial.FormattingEnabled = true;
            cbxMaterial.Location = new Point(12, 215);
            cbxMaterial.Name = "cbxMaterial";
            cbxMaterial.Size = new Size(224, 23);
            cbxMaterial.TabIndex = 10;
            // 
            // FormSacapuntas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 387);
            Controls.Add(cbxMaterial);
            Controls.Add(cbxTipoSacapuntas);
            Name = "FormSacapuntas";
            Text = "FormSacapuntas";
            Load += FormSacapuntas_Load;
            Controls.SetChildIndex(txtBoxNumero, 0);
            Controls.SetChildIndex(txtBoxPeso, 0);
            Controls.SetChildIndex(cbxGarantia, 0);
            Controls.SetChildIndex(cbxTipoSacapuntas, 0);
            Controls.SetChildIndex(cbxMaterial, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxTipoSacapuntas;
        private ComboBox cbxMaterial;
    }
}