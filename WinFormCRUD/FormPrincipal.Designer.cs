namespace WinFormCRUD
{
    partial class FormPrincipal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lstBoxUtiles = new ListBox();
            lblUsuarioConexion = new Label();
            menuStrip1 = new MenuStrip();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            lapiceraToolStripMenuItem = new ToolStripMenuItem();
            sacapuntasToolStripMenuItem = new ToolStripMenuItem();
            reglaToolStripMenuItem = new ToolStripMenuItem();
            ordenarToolStripMenuItem = new ToolStripMenuItem();
            ascendentementeToolStripMenuItem = new ToolStripMenuItem();
            descendentementeToolStripMenuItem = new ToolStripMenuItem();
            ascendentePPrecioToolStripMenuItem = new ToolStripMenuItem();
            descendentePPrecioToolStripMenuItem = new ToolStripMenuItem();
            ascendentePNumeroToolStripMenuItem = new ToolStripMenuItem();
            descendentePNumeroToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            recuperarToolStripMenuItem = new ToolStripMenuItem();
            visualizarLoginsToolStripMenuItem = new ToolStripMenuItem();
            loginsToolStripMenuItem = new ToolStripMenuItem();
            utilizarToolStripMenuItem = new ToolStripMenuItem();
            mostrarBasedeDatosToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            lblHora = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lstBoxUtiles
            // 
            lstBoxUtiles.BackColor = Color.DimGray;
            lstBoxUtiles.BorderStyle = BorderStyle.None;
            lstBoxUtiles.Font = new Font("Yu Gothic UI Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lstBoxUtiles.ForeColor = SystemColors.ButtonHighlight;
            lstBoxUtiles.FormattingEnabled = true;
            lstBoxUtiles.Location = new Point(290, 37);
            lstBoxUtiles.Name = "lstBoxUtiles";
            lstBoxUtiles.Size = new Size(573, 455);
            lstBoxUtiles.TabIndex = 0;
            lstBoxUtiles.Visible = false;
            // 
            // lblUsuarioConexion
            // 
            lblUsuarioConexion.AutoSize = true;
            lblUsuarioConexion.BackColor = Color.Transparent;
            lblUsuarioConexion.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuarioConexion.Location = new Point(12, 465);
            lblUsuarioConexion.Name = "lblUsuarioConexion";
            lblUsuarioConexion.Size = new Size(120, 18);
            lblUsuarioConexion.TabIndex = 1;
            lblUsuarioConexion.Text = "lblUsuarioConexion";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DimGray;
            menuStrip1.Font = new Font("Corbel", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, ordenarToolStripMenuItem, modificarToolStripMenuItem, eliminarToolStripMenuItem, guardarToolStripMenuItem, recuperarToolStripMenuItem, visualizarLoginsToolStripMenuItem, utilizarToolStripMenuItem, mostrarBasedeDatosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(875, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lapiceraToolStripMenuItem, sacapuntasToolStripMenuItem, reglaToolStripMenuItem });
            agregarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            agregarToolStripMenuItem.Size = new Size(59, 20);
            agregarToolStripMenuItem.Text = "Agregar";
            // 
            // lapiceraToolStripMenuItem
            // 
            lapiceraToolStripMenuItem.Name = "lapiceraToolStripMenuItem";
            lapiceraToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            lapiceraToolStripMenuItem.Size = new Size(180, 22);
            lapiceraToolStripMenuItem.Text = "Lapicera";
            lapiceraToolStripMenuItem.Click += lapiceraToolStripMenuItem_Click;
            // 
            // sacapuntasToolStripMenuItem
            // 
            sacapuntasToolStripMenuItem.Name = "sacapuntasToolStripMenuItem";
            sacapuntasToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            sacapuntasToolStripMenuItem.Size = new Size(180, 22);
            sacapuntasToolStripMenuItem.Text = "Sacapuntas";
            sacapuntasToolStripMenuItem.Click += sacapuntasToolStripMenuItem_Click;
            // 
            // reglaToolStripMenuItem
            // 
            reglaToolStripMenuItem.Name = "reglaToolStripMenuItem";
            reglaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            reglaToolStripMenuItem.Size = new Size(180, 22);
            reglaToolStripMenuItem.Text = "Regla";
            reglaToolStripMenuItem.Click += reglaToolStripMenuItem_Click;
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendentementeToolStripMenuItem, descendentementeToolStripMenuItem, ascendentePPrecioToolStripMenuItem, descendentePPrecioToolStripMenuItem, ascendentePNumeroToolStripMenuItem, descendentePNumeroToolStripMenuItem });
            ordenarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            ordenarToolStripMenuItem.Size = new Size(60, 20);
            ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // ascendentementeToolStripMenuItem
            // 
            ascendentementeToolStripMenuItem.Name = "ascendentementeToolStripMenuItem";
            ascendentementeToolStripMenuItem.Size = new Size(191, 22);
            ascendentementeToolStripMenuItem.Text = "Ascendente p/ Marca";
            ascendentementeToolStripMenuItem.Click += ascendentePMarcaToolStripMenuItem_Click;
            // 
            // descendentementeToolStripMenuItem
            // 
            descendentementeToolStripMenuItem.Name = "descendentementeToolStripMenuItem";
            descendentementeToolStripMenuItem.Size = new Size(191, 22);
            descendentementeToolStripMenuItem.Text = "Descendente p/ Marca";
            descendentementeToolStripMenuItem.Click += descendentePMarcaToolStripMenuItem_Click;
            // 
            // ascendentePPrecioToolStripMenuItem
            // 
            ascendentePPrecioToolStripMenuItem.Name = "ascendentePPrecioToolStripMenuItem";
            ascendentePPrecioToolStripMenuItem.Size = new Size(191, 22);
            ascendentePPrecioToolStripMenuItem.Text = "Ascendente p/ Precio";
            ascendentePPrecioToolStripMenuItem.Click += ascendentePPrecioToolStripMenuItem_Click;
            // 
            // descendentePPrecioToolStripMenuItem
            // 
            descendentePPrecioToolStripMenuItem.Name = "descendentePPrecioToolStripMenuItem";
            descendentePPrecioToolStripMenuItem.Size = new Size(191, 22);
            descendentePPrecioToolStripMenuItem.Text = "Descendente p/ Precio";
            descendentePPrecioToolStripMenuItem.Click += descendentePPrecioToolStripMenuItem_Click;
            // 
            // ascendentePNumeroToolStripMenuItem
            // 
            ascendentePNumeroToolStripMenuItem.Name = "ascendentePNumeroToolStripMenuItem";
            ascendentePNumeroToolStripMenuItem.Size = new Size(191, 22);
            ascendentePNumeroToolStripMenuItem.Text = "Ascendente p/ Numero";
            ascendentePNumeroToolStripMenuItem.Click += ascendentePNumeroToolStripMenuItem_Click;
            // 
            // descendentePNumeroToolStripMenuItem
            // 
            descendentePNumeroToolStripMenuItem.Name = "descendentePNumeroToolStripMenuItem";
            descendentePNumeroToolStripMenuItem.Size = new Size(191, 22);
            descendentePNumeroToolStripMenuItem.Text = "Descendente p/ Numero";
            descendentePNumeroToolStripMenuItem.Click += descendentePNumeroToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            modificarToolStripMenuItem.Size = new Size(65, 20);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            eliminarToolStripMenuItem.Size = new Size(61, 20);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            guardarToolStripMenuItem.Size = new Size(61, 20);
            guardarToolStripMenuItem.Text = "Exportar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // recuperarToolStripMenuItem
            // 
            recuperarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            recuperarToolStripMenuItem.Name = "recuperarToolStripMenuItem";
            recuperarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.R;
            recuperarToolStripMenuItem.Size = new Size(137, 20);
            recuperarToolStripMenuItem.Text = "Recuperar (Solo lectura)";
            recuperarToolStripMenuItem.Click += recuperarToolStripMenuItem_Click;
            // 
            // visualizarLoginsToolStripMenuItem
            // 
            visualizarLoginsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loginsToolStripMenuItem });
            visualizarLoginsToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            visualizarLoginsToolStripMenuItem.Name = "visualizarLoginsToolStripMenuItem";
            visualizarLoginsToolStripMenuItem.Size = new Size(36, 20);
            visualizarLoginsToolStripMenuItem.Text = "Ver";
            // 
            // loginsToolStripMenuItem
            // 
            loginsToolStripMenuItem.Name = "loginsToolStripMenuItem";
            loginsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.L;
            loginsToolStripMenuItem.Size = new Size(207, 22);
            loginsToolStripMenuItem.Text = "Logins";
            loginsToolStripMenuItem.Click += loginsToolStripMenuItem_Click;
            // 
            // utilizarToolStripMenuItem
            // 
            utilizarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            utilizarToolStripMenuItem.Name = "utilizarToolStripMenuItem";
            utilizarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            utilizarToolStripMenuItem.Size = new Size(55, 20);
            utilizarToolStripMenuItem.Text = "Utilizar";
            utilizarToolStripMenuItem.Click += utilizarToolStripMenuItem_Click;
            // 
            // mostrarBasedeDatosToolStripMenuItem
            // 
            mostrarBasedeDatosToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            mostrarBasedeDatosToolStripMenuItem.Name = "mostrarBasedeDatosToolStripMenuItem";
            mostrarBasedeDatosToolStripMenuItem.Size = new Size(137, 20);
            mostrarBasedeDatosToolStripMenuItem.Text = "Cambiar Diseño List Box";
            mostrarBasedeDatosToolStripMenuItem.Click += mostrarBasedeDatosToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.DimGray;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(290, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DimGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = Color.DimGray;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ButtonHighlight;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(573, 483);
            dataGridView1.TabIndex = 4;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.BackColor = Color.Transparent;
            lblHora.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblHora.Location = new Point(12, 502);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(50, 18);
            lblHora.TabIndex = 6;
            lblHora.Text = "lblHora";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 531);
            Controls.Add(lblHora);
            Controls.Add(dataGridView1);
            Controls.Add(lblUsuarioConexion);
            Controls.Add(lstBoxUtiles);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            FormClosing += FormPrincipal_FormClosing;
            Load += FormPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBoxUtiles;
        private Label lblUsuarioConexion;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem lapiceraToolStripMenuItem;
        private ToolStripMenuItem sacapuntasToolStripMenuItem;
        private ToolStripMenuItem reglaToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem recuperarToolStripMenuItem;
        private ToolStripMenuItem ordenarToolStripMenuItem;
        private ToolStripMenuItem ascendentementeToolStripMenuItem;
        private ToolStripMenuItem descendentementeToolStripMenuItem;
        private ToolStripMenuItem ascendentePPrecioToolStripMenuItem;
        private ToolStripMenuItem descendentePPrecioToolStripMenuItem;
        private ToolStripMenuItem ascendentePNumeroToolStripMenuItem;
        private ToolStripMenuItem descendentePNumeroToolStripMenuItem;
        private ToolStripMenuItem visualizarLoginsToolStripMenuItem;
        private ToolStripMenuItem loginsToolStripMenuItem;
        private ToolStripMenuItem utilizarToolStripMenuItem;
        private DataGridView dataGridView1;
        private Label lblHora;
        private ToolStripMenuItem mostrarBasedeDatosToolStripMenuItem;
    }
}