using Entidades;
using ExceptionBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormCRUD
{
    /// <summary>
    /// Formulario para la gestión de Lapiceras.
    /// </summary>
    public partial class FormLapicera : FormUtilEscolar
    {
        /// <summary>
        /// Constructor predeterminado de la clase FormLapicera.
        /// Inicializa componentes, el combobox y suma uno al contador de utiles
        /// </summary>
        public FormLapicera()
        {
            InitializeComponent();
            InicializarComboBoxColorTinta();
            contadorUtiles++;
        }
        /// <summary>
        /// Constructor que recibe una Lapicera para su edición.
        /// Inicializa combo box.
        /// Setea txtbox y cbxbox en base a lo que trae la lapicera.
        /// </summary>
        /// <param name="lapicera">La Lapicera a editar.</param>
        public FormLapicera(Lapicera lapicera) : base(lapicera)
        {
            InitializeComponent();
            InicializarComboBoxColorTinta();
            this.txtBoxNivelTinta.Text = lapicera.NivelTinta.ToString();
            switch (lapicera.ColorTinta)
            {
                case EColoresTinta.Azul:
                    this.cbxColorTinta.SelectedIndex = 1;
                    break;
                case EColoresTinta.Verde:
                    this.cbxColorTinta.SelectedIndex = 2;
                    break;
                case EColoresTinta.Negra:
                    this.cbxColorTinta.SelectedIndex = 3;
                    break;
                case EColoresTinta.Roja:
                    this.cbxColorTinta.SelectedIndex = 4;
                    break;
            }
        }
        /// <summary>
        /// Inicializa el ComboBox para seleccionar el color de tinta.
        /// </summary>
        private void InicializarComboBoxColorTinta()
        {
            this.cbxColorTinta.Items.Add("Color de tinta (Requerido)");
            EColoresTinta[] colores = (EColoresTinta[])Enum.GetValues(typeof(EColoresTinta));
            foreach (EColoresTinta color in colores)
            {
                this.cbxColorTinta.Items.Add(color);
            }
            this.cbxColorTinta.SelectedIndex = 0;
        }
        /// <summary>
        /// Maneja el evento KeyPress para el nivel de tinta, para que solo se puedan ingresar números.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento KeyPress.</param>
        private void txtBoxNivelTinta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.ValidarIngresoNumeros(sender, e);
            }
            catch (OperacionInvalidaException ex)
            {
                MessageBox.Show(ex.ToString(), "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Maneja el evento Click del botón Aceptar. Reutiliza la de la clase padre. Si están vacios los campos requeridos lo advierte. 
        /// Si no realiza los constructores en base a la cantidad de parametros recibidos.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            base.btnAceptar_Click(sender, e);
            if (this.txtBoxNivelTinta.Text == "" || this.cbxColorTinta.SelectedIndex == 0)
            {
                MessageBox.Show("Llenar campos requeridos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                short nivelTinta = short.Parse(this.txtBoxNivelTinta.Text);
                EColoresTinta colorTinta = (EColoresTinta)this.cbxColorTinta.SelectedIndex - 1;
                if (this.cbxGarantia.SelectedIndex == 0 && this.txtBoxPeso.Text == "")
                {
                    this.utilEscolar = new Lapicera(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, nivelTinta, colorTinta);
                }
                else if (this.cbxGarantia.SelectedIndex == 0)
                {
                    this.utilEscolar = new Lapicera(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, nivelTinta, colorTinta);
                }
                else
                {
                    this.utilEscolar = new Lapicera(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, this.garantiaUtil, nivelTinta, colorTinta);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Maneja el evento Click del botón Cancelar. Reutiliza la de la clase padre y reinicia txtboxes y cbxboxes a predeterminado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            base.btnCancelar_Click(sender, e);
            this.txtBoxNivelTinta.Text = "";
            this.cbxColorTinta.SelectedIndex = 0;
        }
        /// <summary>
        /// Maneja el evento Load del formulario FormLapicera.
        /// Carga una lista de imágenes en segundo plano utilizando la clase Task.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormLapicera_Load(object sender, EventArgs e)
        {
            List<Bitmap> listaDeRutas = this.CargarImagenes();
            Task t = Task.Run(() => MostrarImagenes(listaDeRutas));
        }

        
    }
}
