using System.Text.Json;
using Entidades;

namespace WinFormCRUD
{
    /// <summary>
    /// Clase para gestionar el formulario de inicio de sesi�n en la aplicaci�n.
    /// </summary>

    public partial class Login : Form
    {
        private Usuario usuario;
        private int intentos;
        private bool aplicacionCerrada;
        public event CredencialesIncorrectasEventHandler credencialesIncorrectas;
        public event IntentosSuperadosEventHandler intentosSuperados;
        /// <summary>
        /// Obtiene el usuario que ha iniciado sesi�n en la aplicaci�n.
        /// </summary>
        public Usuario Usuario { get { return usuario; } }
        /// <summary>
        /// Constructor del formulario Login sin par�metros, inicializa el n�mero de intentos en 0 y setea la variable booleana en false.
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
        /// <param name="sender">El objeto que desencaden� el evento.</param>
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
        /// Maneja el evento Leave del campo de texto "Correo" para restaurar el texto de correo si est� vac�o.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
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
        /// Maneja el evento Enter del campo de contrase�a para borrar el texto de contrase�a y mostrar '*' para la contrase�a.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContrase�a_Enter(object sender, EventArgs e)
        {
            if (txtContrase�a.Text == "CONTRASE�A")
            {
                txtContrase�a.Text = "";
                txtContrase�a.PasswordChar = '*';
                txtContrase�a.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Maneja el evento Leave del campo de contrase�a para restaurar el texto de contrase�a y ocultar '*' para la contrase�a.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContrase�a_Leave(object sender, EventArgs e)
        {
            if (txtContrase�a.Text == "")
            {
                txtContrase�a.Text = "CONTRASE�A";
                txtContrase�a.PasswordChar = '\0';
                txtContrase�a.ForeColor = Color.DimGray;
            }
        }
        /// <summary>
        /// Maneja el evento Click del bot�n "Acceder" para verificar las credenciales del usuario y permitir el acceso si son correctas.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            bool credencialesValidas = VerificarCredenciales(txtCorreo.Text, txtContrase�a.Text);

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
        /// Verifica si las credenciales proporcionadas son v�lidas compar�ndolas con una lista de usuarios, antes deserializandolas de un archivo json.
        /// </summary>
        /// <param name="correo">El correo del usuario.</param>
        /// <param name="clave">La contrase�a del usuario.</param>
        /// <returns>True si las credenciales son v�lidas, de lo contrario, false.</returns>
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
        /// Maneja el evento Click del bot�n "Cancelar" para restablecer los campos de correo y contrase�a.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtCorreo.Text = "CORREO";
            txtCorreo.ForeColor = Color.DimGray;
            this.txtContrase�a.Text = "CONTRASE�A";
            txtContrase�a.PasswordChar = '\0';
            txtContrase�a.ForeColor = Color.DimGray;
        }
        /// <summary>
        /// Maneja el evento FormClosing del formulario para confirmar el cierre de la aplicaci�n.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.aplicacionCerrada)
            {
                if (MessageBox.Show("�Est� seguro que quiere salir de la aplicaci�n?", "Atenci�n!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    MessageBox.Show("Gracias por usar nuestra aplicaci�n.", "Saludos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// Restablece los valores predeterminados para los campos de correo y contrase�a.
        /// </summary>
        private void LimpiarCorreoContrase�a()
        {
            txtContrase�a.Text = "CONTRASE�A";
            txtContrase�a.PasswordChar = '\0';
            txtContrase�a.ForeColor = Color.DimGray;
            txtCorreo.Text = "CORREO";
            txtCorreo.ForeColor = Color.DimGray;
        }
        /// <summary>
        /// Maneja el evento CredencialesIncorrectas del formulario de inicio de sesi�n.
        /// Muestra un mensaje de error y limpia los campos de correo y contrase�a.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_CredencialesIncorrectas(object sender, EventArgs e)
        {
            MessageBox.Show($"Error en el correo y/o la clave. Intentos restantes: {3 - this.intentos}", "CREDENCIALES INCORRECTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCorreoContrase�a();
        }
        /// <summary>
        /// Maneja el evento IntentosSuperados del formulario de inicio de sesi�n.
        /// Muestra un mensaje de advertencia y cierra la aplicaci�n.
        /// </summary>
        /// <param name="sender">El objeto que desencaden� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_IntentosSuperados(object sender, EventArgs e)
        {
            MessageBox.Show("Cantidad de intentos superada - La aplicaci�n se cerrar�", "ATENCI�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.aplicacionCerrada = true;
            this.Close();
        }
    }
}