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
    /// Clase para mostrar un formulario que permite visualizar registros de acceso a la aplicación.
    /// </summary>
    public partial class FormVisualizadorLogins : Form
    {
        /// <summary>
        /// Constructor publico sin parametros que inicializa los componentes.
        /// </summary>
        public FormVisualizadorLogins()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Maneja el evento Click del botón "Cerrar" para cerrar el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Maneja el evento Load del formulario para cargar registros de acceso desde un archivo y los muestra en un rich text box.
        /// </summary>

        private void FormVisualizadorLogins_Load(object sender, EventArgs e)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = ruta + @"\usuarios.log";

            try
            {
                if (File.Exists(rutaCompleta))
                {
                    using (StreamReader sr = new StreamReader(rutaCompleta))
                    {
                        this.rtxtBox.Text = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la lectura del archivo {rutaCompleta}: {ex}");
            }

        }

    }
}
