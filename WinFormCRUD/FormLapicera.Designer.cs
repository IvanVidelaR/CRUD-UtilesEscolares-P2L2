namespace WinFormCRUD
{
    partial class FormLapicera
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
            txtBoxNivelTinta = new TextBox();
            cbxColorTinta = new ComboBox();
            SuspendLayout();
            // 
            // txtBoxNivelTinta
            // 
            txtBoxNivelTinta.Location = new Point(12, 186);
            txtBoxNivelTinta.MaxLength = 2;
            txtBoxNivelTinta.Name = "txtBoxNivelTinta";
            txtBoxNivelTinta.PlaceholderText = "Nivel de tinta (Requerido)";
            txtBoxNivelTinta.Size = new Size(224, 23);
            txtBoxNivelTinta.TabIndex = 9;
            txtBoxNivelTinta.KeyPress += txtBoxNivelTinta_KeyPress;
            // 
            // cbxColorTinta
            // 
            cbxColorTinta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxColorTinta.FormattingEnabled = true;
            cbxColorTinta.Location = new Point(12, 215);
            cbxColorTinta.Name = "cbxColorTinta";
            cbxColorTinta.Size = new Size(224, 23);
            cbxColorTinta.TabIndex = 10;
            // 
            // FormLapicera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 387);
            Controls.Add(cbxColorTinta);
            Controls.Add(txtBoxNivelTinta);
            Name = "FormLapicera";
            Text = "FormLapicera";
            Load += FormLapicera_Load;
            Controls.SetChildIndex(txtBoxNumero, 0);
            Controls.SetChildIndex(txtBoxPeso, 0);
            Controls.SetChildIndex(cbxGarantia, 0);
            Controls.SetChildIndex(txtBoxNivelTinta, 0);
            Controls.SetChildIndex(cbxColorTinta, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxNivelTinta;
        private ComboBox cbxColorTinta;
    }
}