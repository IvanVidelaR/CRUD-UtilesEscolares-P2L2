using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace WinFormCRUD
{
   
    /// <summary>
    /// Formulario de bienvenida que muestra una barra de progreso y realiza una tarea en segundo plano.
    /// </summary>
    public partial class FormBienvenida : Form
    {

        public Random random = new Random();
        private CancellationTokenSource cancellationTokenSource;
        private bool aplicacionCerrada;
        public event ProgresoAlcanzadoEventHandler ProgresoAlcanzado;
        /// <summary>
        /// Constructor predeterminado del formulario de bienvenida.
        /// </summary>
        public FormBienvenida()
        {
            InitializeComponent();
            this.aplicacionCerrada = false;
            ProgresoAlcanzado += new ProgresoAlcanzadoEventHandler(FormBienvenida_ProgresoAlcanzado);
        }
        /// <summary>
        /// Constructor del formulario de bienvenida que acepta un objeto Usuario.
        /// </summary>
        /// <param name="usuario">Objeto Usuario para mostrar información en el formulario.</param>
        public FormBienvenida(Usuario usuario) : this()
        {
            this.lblUser.Text = $"{usuario.nombre} {usuario.apellido}";
        }
        /// <summary>
        /// Inicia un hilo para ejecutar el proceso de cargando en segundo plano.
        /// </summary>
        private void IniciarHilo()
        {
            this.cancellationTokenSource = new CancellationTokenSource();

            Task t = Task.Run(() => IniciarProceso(progressBar1, lblPorcentaje), cancellationTokenSource.Token);

        }
        /// <summary>
        /// Método que simula un proceso en segundo plano y actualiza la barra de progreso.
        /// </summary>
        /// <param name="barraProgreso">Instancia de ProgressBar.</param>
        /// <param name="label">Instancia de Label.</param>
        private void IniciarProceso(ProgressBar barraProgreso, Label label)
        {
            do
            {
                if (barraProgreso.Value >= barraProgreso.Maximum || cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }
                Thread.Sleep(random.Next(10, 50));
                IncrementarBarraProgreso(barraProgreso, label);
            } while (true);

            this.aplicacionCerrada = true;
            cancellationTokenSource.Cancel();
            DialogResult = DialogResult.OK;

        }
        /// <summary>
        /// Incrementa la barra de progreso y actualiza la etiqueta asociada.
        /// </summary>
        /// <param name="barraProgreso">Instancia de ProgressBar a incrementar.</param>
        /// <param name="label">Instancia de Label a actualizar.</param>
        private void IncrementarBarraProgreso(ProgressBar barraProgreso, Label label)
        {

            if (this.InvokeRequired)
            {
                DelegadoBarraDeProgreso<ProgressBar,Label> delegadoBarraDeProgreso = IncrementarBarraProgreso;
                object[] parametros = new object[] { barraProgreso, label };
                Invoke(delegadoBarraDeProgreso, parametros);
            }
            else
            {
                barraProgreso.Increment(1);
                label.Text = $"{barraProgreso.Value}%";
                if (barraProgreso.Value == barraProgreso.Maximum / 2)
                {
                    ProgresoAlcanzado.Invoke(barraProgreso.Value);
                }

            }
        }
        /// <summary>
        /// Maneja el evento Load del formulario donde inicia el hilo.
        /// </summary>
        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            this.IniciarHilo();

        }
        /// <summary>
        /// Maneja el evento FormClosing del formulario.
        /// </summary>
        private void FormBienvenida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.aplicacionCerrada)
            {
                if (MessageBox.Show("¿Está seguro que quiere salir de la aplicación?", "Atención!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    MessageBox.Show("Gracias por usar nuestra aplicación.", "Saludos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// Maneja el evento ProgresoAlcanzado y muestra un mensaje cuando se alcanza cierto progreso.
        /// </summary>
        /// <param name="porcentaje">Porcentaje de progreso alcanzado.</param>
        private void FormBienvenida_ProgresoAlcanzado(int porcentaje)
        {
            MessageBox.Show($"¡Hemos alcanzado el {porcentaje}% de progreso!", "FALTA POCO!");
        }
    }
}
