using Entidades;
using ExceptionBiblioteca;
using System.Drawing;

namespace WinFormCRUD
{
    /// <summary>
    /// Clase base para formularios de utiles escolares que permite agregarlos o modificarlos.
    /// </summary>
    public partial class FormUtilEscolar : Form
    {
        public static int contadorUtiles;
        public UtilEscolar utilEscolar;
        protected int numeroUtil;
        protected int codigoDeBarrasUtil;
        protected string marcaUtil;
        protected double precioUtil;
        protected short pesoUtil;
        protected bool garantiaUtil;
        protected CancellationToken cancellationToken;
        protected CancellationTokenSource cancellationTokenSource;
        private bool agregar;
        /// <summary>
        /// Constructor estático que inicializa el contador de utiles en 1
        /// </summary>
        static FormUtilEscolar()
        {
            contadorUtiles = 1;
        }
        // <summary>
        /// Constructor para mostrar un formulario de modificación de un util escolar existente.
        /// </summary>
        /// <param name="utilEscolar">El util escolar existente que se muestra para su modificación.</param>
        public FormUtilEscolar(UtilEscolar utilEscolar) : this()
        {
            this.agregar = false;
            this.txtBoxNumero.Text = utilEscolar.NumeroUtil.ToString();
            this.txtBoxCodigoDeBarras.Text = utilEscolar.CodigoDeBarras.ToString();
            this.txtBoxCodigoDeBarras.ReadOnly = true;
            this.txtBoxMarca.Text = utilEscolar.Marca;
            this.txtBoxPrecio.Text = utilEscolar.Precio.ToString();
            this.txtBoxPeso.Text = utilEscolar.Peso.ToString();
            if (utilEscolar.Garantia == true)
            {
                this.cbxGarantia.SelectedIndex = 1;
            }
            else
            {
                this.cbxGarantia.SelectedIndex = 2;
            }
        }
        /// <summary>
        /// Constructor por defecto del formulario para agregar un util escolar, inicializar componentes, indice de garantia en 0 y mostrar en el txt box numero la cantidad de utiles.
        /// </summary>
        public FormUtilEscolar()
        {
            InitializeComponent();
            this.cbxGarantia.SelectedIndex = 0;
            this.txtBoxNumero.Text = $"{contadorUtiles}";
            this.agregar = true;
        }
        /// <summary>
        /// Maneja el evento Click del botón Aceptar. Si están vacios los campos requeridos lo advierte, si no inicializa los atributos que se pasaran al constructor del util en base a lo que ingresa el usuario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtBoxCodigoDeBarras.Text == "" || this.txtBoxMarca.Text == "" || this.txtBoxPrecio.Text == "")
            {
                MessageBox.Show("Llenar campos requeridos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                this.numeroUtil = int.Parse(this.txtBoxNumero.Text);
                this.codigoDeBarrasUtil = int.Parse(this.txtBoxCodigoDeBarras.Text);
                this.marcaUtil = this.txtBoxMarca.Text;
                this.precioUtil = double.Parse(this.txtBoxPrecio.Text);
                if (this.txtBoxPeso.Text != "")
                {
                    this.pesoUtil = short.Parse(this.txtBoxPeso.Text);
                }
                if (this.cbxGarantia.SelectedIndex == 1)
                {
                    this.garantiaUtil = true;
                }
                else if (this.cbxGarantia.SelectedIndex == 2)
                {
                    this.garantiaUtil = false;
                }
            }
        }
        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto "Codigo de barras" para validar la entrada de números.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtBoxCodigoDeBarras_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Maneja el evento KeyPress del cuadro de texto "Precio" para validar la entrada de números decimales con coma.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Maneja el evento KeyPress del cuadro de texto "Peso" para validar la entrada de números.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtBoxPeso_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Maneja el evento Click del botón Cancelar. Reinicia cbxboxes a predeterminado y txtboxes.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtBoxCodigoDeBarras.Text = "";
            this.txtBoxMarca.Text = "";
            this.txtBoxPrecio.Text = "";
            this.txtBoxPeso.Text = "";
            this.cbxGarantia.SelectedIndex = 0;
        }
        /// <summary>
        /// Maneja el evento Click del botón "Cerrar" para cancelar la operación de agregar/modificar y cerrar el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(this.agregar)
            {
                contadorUtiles--;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Maneja el evento KeyPress del cuadro de texto "Marca" para validar la entrada de texto.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtBoxMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.ValidarIngresoLetras(sender, e);
            }
            catch (OperacionInvalidaException ex)
            {
                MessageBox.Show(ex.ToString(), "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        /// <summary>
        /// Valida el ingreso de números en un campo de texto, si no es asi salta error y no permite escribir.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void ValidarIngresoNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // MessageBox.Show("Ingrese números", "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                throw new OperacionInvalidaException("Ingrese números.");

            }
        }
        /// <summary>
        /// Valida el ingreso de letras en un campo de texto, si no es asi salta error y no permite escribir.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void ValidarIngresoLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                throw new OperacionInvalidaException("Ingrese letras.");
                //MessageBox.Show("Ingrese letras", "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Valida el ingreso de números con coma en un campo de texto, si no es asi salta error y no permite escribir.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void ValidarIngresoNumerosConComa(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains(","))
            {
                // MessageBox.Show("Ya hay un punto en el texto", "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                throw new OperacionInvalidaException("Ya hay un punto en el texto.");
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                //MessageBox.Show("Ingrese números", "Operación inválida!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                throw new OperacionInvalidaException("Ingrese números.");
            }
        }
        /// <summary>
        /// Carga una lista de rutas de imágenes de acuerdo al tipo de formulario.
        /// </summary>
        /// <returns>Lista de objetos Bitmap que representan las rutas de imágenes.</returns>
        protected List<Bitmap> CargarImagenes()
        {
            Bitmap ruta;
            List<Bitmap> listaDeRutas = new List<Bitmap>();

            if (this is FormLapicera)
            {
                listaDeRutas.Add(Properties.Resources.lapicera01);
                listaDeRutas.Add(Properties.Resources.lapicera02);
                listaDeRutas.Add(Properties.Resources.lapicera03);
                listaDeRutas.Add(Properties.Resources.lapicera04);
            }
            else if (this is FormRegla)
            {
                listaDeRutas.Add(Properties.Resources.regla01);
                listaDeRutas.Add(Properties.Resources.regla02);
                listaDeRutas.Add(Properties.Resources.regla03);
                listaDeRutas.Add(Properties.Resources.regla04);
            }
            else if (this is FormSacapuntas)
            {
                listaDeRutas.Add(Properties.Resources.sacapuntas01);
                listaDeRutas.Add(Properties.Resources.sacapuntas02);
                listaDeRutas.Add(Properties.Resources.sacapuntas03);
                listaDeRutas.Add(Properties.Resources.sacapuntas04);
            }

            return listaDeRutas;
        }
        // <summary>
        /// Muestra imágenes de una lista en el control PictureBox en un bucle infinito con un retardo de 1000 milisegundos.
        /// </summary>
        /// <param name="listaDeRutas">Lista de objetos Bitmap que representan las rutas de imágenes.</param>
        protected void MostrarImagenes(List<Bitmap> listaDeRutas)
        {
            this.cancellationTokenSource = new CancellationTokenSource();

            int contador = 0;
            do
            {
                if (this.cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }
                this.ActualizarImagen(listaDeRutas[contador]);
                contador = (contador + 1) % 4;
                Thread.Sleep(1000);
            } while (true);
        }
        /// <summary>
        /// Actualiza la imagen del control PictureBox con la imagen proporcionada.
        /// </summary>
        /// <param name="ruta">Objeto Bitmap que representa la ruta de la imagen a mostrar.</param>
        protected void ActualizarImagen(Bitmap ruta)
        {
            if (this.picBoxUtil.InvokeRequired)
            {
                DelegadoDeLaImagen delegado = new DelegadoDeLaImagen(ActualizarImagen);
                object[] parametros = { ruta };

                this.picBoxUtil.Invoke(delegado, parametros);
            }
            else
            {
                this.picBoxUtil.Image = ruta;
            }
        }
        /// <summary>
        /// Detiene el bucle de la tarea en segundo plano al cancelar el token de cancelación.
        /// </summary>
        public void DetenerHilo()
        {
            cancellationTokenSource.Cancel();
        }
    }



}
