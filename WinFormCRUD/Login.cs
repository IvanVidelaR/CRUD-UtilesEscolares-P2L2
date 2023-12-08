using System.Text.Json;
using Entidades;

namespace WinFormCRUD
{
    /// <summary>
    /// Clase para gestionar el formulario de inicio de sesión en la aplicación.
    /// </summary>

    public partial class Login : Form
    {
        private Usuario usuario;
        private int intentos;
        private bool aplicacionCerrada;
        public event CredencialesIncorrectasEventHandler credencialesIncorrectas;
        public event IntentosSuperadosEventHandler intentosSuperados;
        /// <summary>
        /// Obtiene el usuario que ha iniciado sesión en la aplicación.
        /// </summary>
        public Usuario Usuario { get { return usuario; } }
        /// <summary>
        /// Constructor del formulario Login sin parámetros, inicializa el número de intentos en 0 y setea la variable booleana en false.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.intentos = 0;
            this.aplicacionCerrada = false;
            credencialesIncorrectas += new CredencialesIncorrectasEventHandler(this.Login_CredencialesIncorrectas);
            intentosSuperados += new IntentosSuperadosEventHandler(this.Login_IntentosSuperados);
        }
        /// <summary>
        /// Maneja el evento Enter del campo de texto "Correo" para borrar el texto de correo cuando uno entra.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "CORREO")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Maneja el evento Leave del campo de texto "Correo" para restaurar el texto de correo si está vacío.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "CORREO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }
        /// <summary>
        /// Maneja el evento Enter del campo de contraseña para borrar el texto de contraseña y mostrar '*' para la contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.PasswordChar = '*';
                txtContraseña.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Maneja el evento Leave del campo de contraseña para restaurar el texto de contraseña y ocultar '*' para la contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.PasswordChar = '\0';
                txtContraseña.ForeColor = Color.DimGray;
            }
        }
        /// <summary>
        /// Maneja el evento Click del botón "Acceder" para verificar las credenciales del usuario y permitir el acceso si son correctas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            bool credencialesValidas = VerificarCredenciales(txtCorreo.Text, txtContraseña.Text);

            if (credencialesValidas)
            {
                DialogResult = DialogResult.OK;
                this.aplicacionCerrada = true;
            }
            else
            {
                this.intentos++;
                if (this.intentos < 3)
                {
                    credencialesIncorrectas.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    intentosSuperados.Invoke(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Verifica si las credenciales proporcionadas son válidas comparándolas con una lista de usuarios, antes deserializandolas de un archivo json.
        /// </summary>
        /// <param name="correo">El correo del usuario.</param>
        /// <param name="clave">La contraseña del usuario.</param>
        /// <returns>True si las credenciales son válidas, de lo contrario, false.</returns>
        private bool VerificarCredenciales(string correo, string clave)
        {
            bool retornoAux = false;

            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\MOCK_DATA.json"))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json_string = sr.ReadToEnd();

                    List<Usuario>? usuariosValidos = JsonSerializer.Deserialize<List<Usuario>>(json_string, opciones);

                    if (usuariosValidos != null)
                    {
                        foreach (Usuario usuario in usuariosValidos)
                        {
                            if (usuario.correo == correo && usuario.clave == clave)
                            {
                                retornoAux = true;
                                this.usuario = usuario;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return retornoAux;
        }
        /// <summary>
        /// Maneja el evento Click del botón "Cancelar" para restablecer los campos de correo y contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtCorreo.Text = "CORREO";
            txtCorreo.ForeColor = Color.DimGray;
            this.txtContraseña.Text = "CONTRASEÑA";
            txtContraseña.PasswordChar = '\0';
            txtContraseña.ForeColor = Color.DimGray;
        }
        /// <summary>
        /// Maneja el evento FormClosing del formulario para confirmar el cierre de la aplicación.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Restablece los valores predeterminados para los campos de correo y contraseña.
        /// </summary>
        private void LimpiarCorreoContraseña()
        {
            txtContraseña.Text = "CONTRASEÑA";
            txtContraseña.PasswordChar = '\0';
            txtContraseña.ForeColor = Color.DimGray;
            txtCorreo.Text = "CORREO";
            txtCorreo.ForeColor = Color.DimGray;
        }
        /// <summary>
        /// Maneja el evento CredencialesIncorrectas del formulario de inicio de sesión.
        /// Muestra un mensaje de error y limpia los campos de correo y contraseña.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_CredencialesIncorrectas(object sender, EventArgs e)
        {
            MessageBox.Show($"Error en el correo y/o la clave. Intentos restantes: {3 - this.intentos}", "CREDENCIALES INCORRECTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCorreoContraseña();
        }
        /// <summary>
        /// Maneja el evento IntentosSuperados del formulario de inicio de sesión.
        /// Muestra un mensaje de advertencia y cierra la aplicación.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_IntentosSuperados(object sender, EventArgs e)
        {
            MessageBox.Show("Cantidad de intentos superada - La aplicación se cerrará", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.aplicacionCerrada = true;
            this.Close();
        }
    }
}