using Entidades;
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
    /// Formulario para la gestión de Sacapuntas.
    /// </summary>
    public partial class FormSacapuntas : FormUtilEscolar
    {
        /// <summary>
        /// Constructor por defecto del formulario de Sacapuntas, inicializa componentes, comboboxes y suma en uno el contador de útiles.
        /// </summary>
        public FormSacapuntas()
        {
            InitializeComponent();
            InicializarComboBoxTipoSacapuntas();
            InicializarComboBoxMaterial();
            contadorUtiles++;
        }
        /// <summary>
        /// Constructor sobrecargado del formulario para modificar un Sacapuntas existente, setea comboboxes en base a lo que está en el sacapuntas existente.
        /// </summary>
        /// <param name="sacapuntas">El Sacapuntas existente que se mostrará en el formulario para su modificación.</param>
        public FormSacapuntas(Sacapuntas sacapuntas) : base(sacapuntas)
        {
            InitializeComponent();
            InicializarComboBoxTipoSacapuntas();
            InicializarComboBoxMaterial();

            switch (sacapuntas.TipoSacapuntas)
            {
                case ETipoSacapuntas.Simple:
                    this.cbxTipoSacapuntas.SelectedIndex = 1;
                    break;
                case ETipoSacapuntas.Doble:
                    this.cbxTipoSacapuntas.SelectedIndex = 2;
                    break;
            }

            switch (sacapuntas.Material)
            {
                case EMaterialSacapuntas.Plástico:
                    this.cbxMaterial.SelectedIndex = 1;
                    break;
                case EMaterialSacapuntas.Madera:
                    this.cbxMaterial.SelectedIndex = 2;
                    break;
                case EMaterialSacapuntas.Metal:
                    this.cbxMaterial.SelectedIndex = 3;
                    break;
            }
        }
        /// <summary>
        /// Inicializa el ComboBox para seleccionar el tipo de Sacapuntas con los valores disponibles.
        /// </summary>
        private void InicializarComboBoxTipoSacapuntas()
        {
            this.cbxTipoSacapuntas.Items.Add("Tipo de sacapuntas (Requerido)");
            ETipoSacapuntas[] tiposDeSacapuntas = (ETipoSacapuntas[])Enum.GetValues(typeof(ETipoSacapuntas));
            foreach (ETipoSacapuntas tipoSacapuntas in tiposDeSacapuntas)
            {
                this.cbxTipoSacapuntas.Items.Add(tipoSacapuntas);
            }
            this.cbxTipoSacapuntas.SelectedIndex = 0;
        }
        /// <summary>
        /// Inicializa el ComboBox para seleccionar el material del Sacapuntas con los valores disponibles.
        /// </summary>
        private void InicializarComboBoxMaterial()
        {
            this.cbxMaterial.Items.Add("Material del sacapuntas (Requerido)");
            EMaterialSacapuntas[] materialesSacapuntas = (EMaterialSacapuntas[])Enum.GetValues(typeof(EMaterialSacapuntas));
            foreach (EMaterialSacapuntas materialSacapuntas in materialesSacapuntas)
            {
                this.cbxMaterial.Items.Add(materialSacapuntas);
            }
            this.cbxMaterial.SelectedIndex = 0;
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
            if (this.cbxTipoSacapuntas.SelectedIndex == 0 || this.cbxMaterial.SelectedIndex == 0)
            {
                MessageBox.Show("Llenar campos requeridos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                ETipoSacapuntas tipoSacapuntas = (ETipoSacapuntas)this.cbxTipoSacapuntas.SelectedIndex - 1;
                EMaterialSacapuntas materialSacapuntas = (EMaterialSacapuntas)this.cbxMaterial.SelectedIndex - 1;
                if (this.cbxGarantia.SelectedIndex == 0 && this.txtBoxPeso.Text == "")
                {
                    this.utilEscolar = new Sacapuntas(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, tipoSacapuntas, materialSacapuntas);
                }
                else if (this.cbxGarantia.SelectedIndex == 0)
                {
                    this.utilEscolar = new Sacapuntas(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, tipoSacapuntas, materialSacapuntas);
                }
                else
                {
                    this.utilEscolar = new Sacapuntas(this.numeroUtil, this.codigoDeBarrasUtil, this.marcaUtil, this.precioUtil, this.pesoUtil, this.garantiaUtil, tipoSacapuntas, materialSacapuntas);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Maneja el evento Click del botón Cancelar. Reutiliza la de la clase padre y reinicia cbxboxes a predeterminado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>

        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            base.btnCancelar_Click(sender, e);
            this.cbxTipoSacapuntas.SelectedIndex = 0;
            this.cbxMaterial.SelectedIndex = 0;
        }
        /// <summary>
        /// Maneja el evento Load del formulario FormSacapuntas.
        /// Carga una lista de imágenes en segundo plano utilizando la clase Task.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormSacapuntas_Load(object sender, EventArgs e)
        {
            List<Bitmap> listaDeRutas = this.CargarImagenes();
            Task t = Task.Run(() => MostrarImagenes(listaDeRutas));
        }
        
    }
}
