using Entidades;
using ExceptionBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCRUD
{
    /// <summary>
    /// Formulario para la gestión de Reglas.
    /// </summary>
    public partial class FormRegla : FormUtilEscolar
    {
        /// <summary>
        /// Constructor por defecto del formulario de Regla, inicializa componentes, establece el valor predeterminado para la flexibilidad y suma en uno el contador de útiles.
        /// </summary>
        public FormRegla()
        {
            InitializeComponent();
            this.cbxFlexibilidad.SelectedIndex = 0;
            contadorUtiles++;
        }
        /// <summary>
        /// Constructor sobrecargado del formulario de Regla que toma una Regla existente y lo muestra en el formulario para su modificación.
        /// </summary>
        /// <param name="regla">La regla existente que se mostrará en el formulario.</param>
        public FormRegla(Regla regla) : base(regla)
        {
            InitializeComponent();
            this.cbxFlexibilidad.SelectedIndex = 0;

            this.txtBoxLongitud.Text = regla.Longitud.ToString();
            if (regla.EsFlexible == true)
            {
                this.cbxFlexibilidad.SelectedIndex = 1;
            }
            else
            {
                this.cbxFlexibilidad.SelectedIndex = 2;
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
            bool flexibilidad = false;

            base.btnAceptar_Click(sender, e);
            if (this.txtBoxLongitud.Text == "" || this.cbxFlexibilidad.SelectedIndex == 0)
            {
                MessageBox.Show("Llenar campos requeridos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (this.cbxFlexibilidad.SelectedIndex == 1)
                {
                    flexibilidad = true;
                }
                else if (this.cbxGarantia.SelectedIndex == 2)
                {
                    flexibilidad = false;
                }

                double longitud = double.Parse(this.txtBoxLongitud.Text);

                if (this.cbxGarantia.SelectedIndex == 0 && this.txtBoxPeso.Text == "")
                {
                    this.utilEscolar = new Regla(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, longitud, flexibilidad);
                }
                else if (this.cbxGarantia.SelectedIndex == 0)
                {
                    this.utilEscolar = new Regla(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, longitud, flexibilidad);
                }
                else
                {
                    this.utilEscolar = new Regla(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, this.garantiaUtil, longitud, flexibilidad);
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
            this.txtBoxLongitud.Text = "";
            this.cbxFlexibilidad.SelectedIndex = 0;
        }
        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto "Longitud" para validar la entrada de números decimales con coma.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtBoxLongitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.ValidarIngresoNumerosConComa(sender, e);
            }
            catch (OperacionInvalidaException ex)
            {
                MessageBox.Show(ex.ToString(), "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        /// <summary>
        /// Maneja el evento Load del formulario FormRegla.
        /// Carga una lista de imágenes en segundo plano utilizando la clase Task.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormRegla_Load(object sender, EventArgs e)
        {
            List<Bitmap> listaDeRutas = this.CargarImagenes();
            Task t = Task.Run(() => MostrarImagenes(listaDeRutas));
        }

        
    }
}
