using BaseDeDatosBiblioteca;
using Entidades;
using Newtonsoft.Json;
using ExceptionBiblioteca;

namespace WinFormCRUD
{

    /// <summary>
    /// Clase principal que representa la ventana principal de la aplicación.
    /// </summary>
    public partial class FormPrincipal : Form
    {
        private Usuario UsuarioLogueado;
        private DateTime fechaLogin;
        private Cartuchera cartuchera;
        private int indiceLista;
        AccesoDatos<UtilEscolar> ado;
        /// <summary>
        /// Constructor predeterminado de la clase FormPrincipal, inicializa la cartuchera.
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            this.cartuchera = new Cartuchera(200, "cartuchera");
        }
        /// <summary>
        /// Constructor que recibe un usuario y la fecha de inicio de sesión. Lo muestra en un label y crea el login de usuarios
        /// </summary>
        /// <param name="usuario">El usuario que ha iniciado sesión.</param>
        /// <param name="fechaLogin">La fecha de inicio de sesión.</param>
        public FormPrincipal(Usuario usuario, DateTime fechaLogin) : this()
        {
            this.UsuarioLogueado = usuario;
            this.fechaLogin = fechaLogin;
            this.lblUsuarioConexion.Text = $"Usuario Logueado: {this.UsuarioLogueado.apellido} {this.UsuarioLogueado.nombre}\nPerfil: {this.UsuarioLogueado.perfil} - ";

            if (this.UsuarioLogueado.perfil == "administrador")
            {
                this.lblUsuarioConexion.Text += "Permisos: CRUD";
            }
            else if (this.UsuarioLogueado.perfil == "supervisor")
            {
                this.lblUsuarioConexion.Text += "Permisos: CRU";
            }
            else
            {
                this.lblUsuarioConexion.Text += "Permisos: R";
            }
            this.crearLoginUsuarios();
        }
        /// <summary>
        /// Maneja el evento FormClosed de un formulario de util escolar para agregar el útil a la cartuchera y actualizar el visor (lstbox).
        /// </summary>
        /// <param name="sender">El formulario de util escolar que se cerró.</param>
        /// <param name="e">Argumentos del evento FormClosed.</param>
        private void FormUtilEscolar_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is FormUtilEscolar)
            {
                FormUtilEscolar f = (FormUtilEscolar)sender;
                if (f.DialogResult == DialogResult.OK)
                {
                    f.DetenerHilo();
                    try
                    {
                        if (ado.AgregarEnBaseDeDatos(f.utilEscolar))
                        {
                            this.cartuchera += f.utilEscolar;
                            MessageBox.Show("Útil agregado correctamente", "Agregado con éxito!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.MostrarUtiles();
                        }
                        else
                        {
                            MessageBox.Show("Útil no agregado correctamente", "No agregado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (ErrorBaseDeDatoException ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (f.DialogResult == DialogResult.Cancel)
                {
                    f.DetenerHilo();
                }
            }
        }
        /// <summary>
        /// Maneja el evento FormClosed de un formulario de util escolar para modificar un útil en la cartuchera y actualizar el visor.
        /// </summary>
        /// <param name="sender">El formulario de util escolar que se cerró.</param>
        /// <param name="e">Argumentos del evento FormClosed.</param>
        private void FormUtilEscolarModificar_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is FormUtilEscolar)
            {
                FormUtilEscolar f = (FormUtilEscolar)sender;
                if (f.DialogResult == DialogResult.OK)
                {
                    f.DetenerHilo();
                    try
                    {
                        if (ado.ModificarEnBaseDeDatos(f.utilEscolar))
                        {
                            if (cartuchera == f.utilEscolar)
                            {
                                this.cartuchera.ListaDeUtiles[this.indiceLista] = f.utilEscolar;
                                MessageBox.Show("Útil modificado correctamente", "Modificado con éxito!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.MostrarUtiles();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Útil no modificado correctamente", "No modificado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (ErrorBaseDeDatoException ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (f.DialogResult == DialogResult.Cancel)
                {
                    f.DetenerHilo();
                }
            }
        }
        /// <summary>
        /// Muestra un formulario de util escolar (Agregar o Modificar) como un formulario secundario (hijo) dentro del formulario principal (padre).
        /// </summary>
        /// <param name="uso">Indica si se debe usar el formulario para "Agregar" o "Modificar" un útil.</param>
        /// <param name="f">El formulario de util escolar que se va a mostrar.</param>
        private void mostrarFormAgregarModificar(string uso, FormUtilEscolar f)
        {
            f.MdiParent = this;
            f.Location = new Point(20, 33);
            if (uso == "Agregar")
            {
                f.FormClosed += FormUtilEscolar_FormClosed;
            }
            else if (uso == "Modificar")
            {
                f.FormClosed += FormUtilEscolarModificar_FormClosed;
            }
            f.Show();
        }
        /// <summary>
        /// Maneja el evento Click del menú "Lapicera" para mostrar el formulario para agregar una lapicera.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void lapiceraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsuarioLogueado.perfil == "administrador" || this.UsuarioLogueado.perfil == "supervisor")
            {
                FormLapicera f = new FormLapicera();
                mostrarFormAgregarModificar("Agregar", f);
            }
            else
            {
                MessageBox.Show($"No tienes permisos para realizar está acción - Eres: {this.UsuarioLogueado.perfil}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Maneja el evento Click del menú "Sacapuntas" para mostrar el formulario para agregar un sacapuntas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void sacapuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsuarioLogueado.perfil == "administrador" || this.UsuarioLogueado.perfil == "supervisor")
            {
                FormSacapuntas f = new FormSacapuntas();
                mostrarFormAgregarModificar("Agregar", f);
            }
            else
            {
                MessageBox.Show($"No tienes permisos para realizar está acción - Eres: {this.UsuarioLogueado.perfil}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Maneja el evento Click del menú "Regla" para mostrar el formulario para agregar una regla.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void reglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsuarioLogueado.perfil == "administrador" || this.UsuarioLogueado.perfil == "supervisor")
            {
                FormRegla f = new FormRegla();
                mostrarFormAgregarModificar("Agregar", f);
            }
            else
            {
                MessageBox.Show($"No tienes permisos para realizar está acción - Eres: {this.UsuarioLogueado.perfil}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Actualiza el visor de la lista de útiles escolares en la interfaz de usuario, limpiando la lista actual
        /// y volviendo a cargar los elementos de la cartuchera.
        /// </summary>
        private void ActualizarVisor()
        {
            this.lstBoxUtiles.Items.Clear();
            foreach (UtilEscolar utilEscolar in this.cartuchera.ListaDeUtiles)
            {
                lstBoxUtiles.Items.Add(utilEscolar.ToString());
            }
        }
        /// <summary>
        /// Maneja el evento Click del menú "Modificar" para modificar un útil escolar en la lista.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsuarioLogueado.perfil == "administrador" || this.UsuarioLogueado.perfil == "supervisor")
            {
                this.indiceLista = this.lstBoxUtiles.SelectedIndex;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    this.indiceLista = dataGridView1.SelectedRows[0].Index;
                }

                if (this.indiceLista == -1)
                {
                    MessageBox.Show("Debe seleccionar una opción a modificar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                UtilEscolar util = this.cartuchera[this.indiceLista];

                if (util is Sacapuntas)
                {
                    FormSacapuntas f = new FormSacapuntas((Sacapuntas)util);
                    mostrarFormAgregarModificar("Modificar", f);
                }
                else if (util is Lapicera)
                {
                    FormLapicera f = new FormLapicera((Lapicera)util);
                    mostrarFormAgregarModificar("Modificar", f);
                }
                else if (util is Regla)
                {
                    FormRegla f = new FormRegla((Regla)util);
                    mostrarFormAgregarModificar("Modificar", f);
                }
            }
            else
            {
                MessageBox.Show($"No tienes permisos para realizar está acción - Eres: {this.UsuarioLogueado.perfil}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Maneja el evento Click del menú "Eliminar" para eliminar un útil escolar en la lista.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsuarioLogueado.perfil == "administrador")
            {
                this.indiceLista = this.lstBoxUtiles.SelectedIndex;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    this.indiceLista = dataGridView1.SelectedRows[0].Index;
                }

                if (this.indiceLista == -1)
                {
                    MessageBox.Show("Debe seleccionar una opción a eliminar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Cuidado!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UtilEscolar util = this.cartuchera[this.indiceLista];

                        try
                        {
                            if (ado.EliminarEnBaseDeDatos(util))
                            {
                                this.cartuchera -= util;
                                MessageBox.Show("Útil eliminado correctamente", "Eliminado con éxito!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.MostrarUtiles();
                                if (dataGridView1.Rows.Count == 0)
                                {
                                    try
                                    {
                                        _ = ado.ResetearTabla();
                                        FormUtilEscolar.contadorUtiles = 1;
                                    }
                                    catch (ErrorBaseDeDatoException ex)
                                    {
                                        MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Útil no eliminado correctamente", "No eliminado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (ErrorBaseDeDatoException ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"No tienes permisos para realizar está acción - Eres: {this.UsuarioLogueado.perfil}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ascendentePMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorMarcaAscendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void descendentePMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorMarcaDescendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ascendentePPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorPrecioAscendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void descendentePPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorPrecioDescendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ascendentePNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorNumeroAscendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void descendentePNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.cartuchera.ListaDeUtiles.Sort(Cartuchera.OrdenarUtilesPorNumeroDescendente);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ordenar de esta forma! Si desea ordenar en esta vista haga click encima del campo del que quiere que se ordene.", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Serializa los datos de la cartuchera a un archivo JSON, permitiendo guardar la información de los útiles escolares.
        /// </summary>
        private void SerializarJson()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos json | *.json";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string obj_json = JsonConvert.SerializeObject(this.cartuchera.ListaDeUtiles, Formatting.Indented);

                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    {
                        sw.WriteLine(obj_json);
                        MessageBox.Show("Información serializada con éxito", "Serialización Exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo json: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Maneja el evento Click del menú "Guardar" para serializar los datos de la cartuchera en un archivo JSON.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SerializarJson();
        }
        /// <summary>
        /// Deserializa los datos de un archivo JSON, recuperando la información de los útiles escolares y actualizando la cartuchera.
        /// Además setea el número de util a uno más del máximo que había en la lista, para que no genere complicaciones.
        /// </summary>
        private void DeserializarJson()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos json | *.json";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        string json_str = sr.ReadToEnd();
                        var objetos = JsonConvert.DeserializeObject<List<object>>(json_str);

                        this.cartuchera.ListaDeUtiles.Clear();

                        if (objetos != null)
                        {
                            foreach (var obj in objetos)
                            {
                                var utilEscolarData = JsonConvert.SerializeObject(obj);

                                int numeroUtil = 0;
                                if (utilEscolarData.Contains("NivelTinta"))
                                {
                                    Lapicera? lapicera = JsonConvert.DeserializeObject<Lapicera>(utilEscolarData);
                                    this.cartuchera += lapicera;
                                }
                                else if (utilEscolarData.Contains("Longitud"))
                                {
                                    Regla? regla = JsonConvert.DeserializeObject<Regla>(utilEscolarData);
                                    this.cartuchera += regla;
                                }
                                else if (utilEscolarData.Contains("TipoSacapuntas"))
                                {
                                    Sacapuntas? sacapuntas = JsonConvert.DeserializeObject<Sacapuntas>(utilEscolarData);
                                    this.cartuchera += sacapuntas;
                                }
                            }
                        }
                        this.ActualizarVisor();
                        this.eliminarToolStripMenuItem.Enabled = false;
                        this.modificarToolStripMenuItem.Enabled = false;
                        this.agregarToolStripMenuItem.Enabled = false;
                        MessageBox.Show("Información serializada recuperada con éxito", "Recuperación Exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al recuperar el archivo json: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Maneja el evento Click del menú "Recuperar" para deserializar datos desde un archivo JSON y actualizar la cartuchera.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void recuperarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarBasedeDatosToolStripMenuItem.Text == "Cambiar Diseño Base de Datos")
            {
                this.DeserializarJson();
            }
            else
            {
                MessageBox.Show("Tiene que estar en vista list box para poder ver el backup!", "Cambiar Diseño List Box!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Registra el acceso del usuario en un archivo de registro y guarda información sobre la conexión a la aplicación.
        /// </summary>
        private void crearLoginUsuarios()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = ruta + @"\usuarios.log";

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                using (StreamWriter sw = new StreamWriter(rutaCompleta, true))
                {
                    if (this.UsuarioLogueado != null)
                    {
                        sw.WriteLine($"Acceso a la aplicación: {this.fechaLogin:yyyy-MM-dd HH:mm:ss} - {this.UsuarioLogueado.ToString()}");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo {rutaCompleta}: {e}");
            }

        }
        /// <summary>
        /// Maneja el evento de cierre del formulario principal y solicita confirmación antes de salir de la aplicación y agradece o cancela.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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
        /// <summary>
        /// Maneja el evento Click del menú "Recuperar" para abrir el formulario de visualización de registros de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVisualizadorLogins f = new FormVisualizadorLogins();
            f.MdiParent = this;
            f.Location = new Point(20, 33);
            f.Show();
        }
        /// <summary>
        /// Maneja el evento Click del menú "Utilizar" para probar un útil escolar y mostrar su función.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void utilizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.indiceLista = this.lstBoxUtiles.SelectedIndex;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                this.indiceLista = dataGridView1.SelectedRows[0].Index;
            }

            if (this.indiceLista == -1)
            {
                MessageBox.Show("Debe seleccionar una opción a utilizar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                UtilEscolar util = this.cartuchera[this.indiceLista];
                MessageBox.Show($"{util.Utilizar()}", "Probando util", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ActualizarVisor();
            }
        }
        /// <summary>
        /// Maneja el evento Load del formulario FormPrincipal.
        /// Inicia un hilo para el bucle de tiempo, muestra los útiles y actualiza el contador de útiles.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Task t1 = Task.Run(() => { this.BucleTiempo(); });

            this.MostrarUtiles();
            int maxNumeroUtil = 0;
            foreach (UtilEscolar util in cartuchera.ListaDeUtiles)
            {
                if (util.NumeroUtil > maxNumeroUtil)
                {
                    maxNumeroUtil = util.NumeroUtil;
                }

                FormUtilEscolar.contadorUtiles = maxNumeroUtil + 1;
            }
        }
        /// <summary>
        /// Muestra los útiles en el formulario, actualiza el DataGridView y el visor.
        /// </summary>
        private void MostrarUtiles()
        {
            try
            {
                ado = new AccesoDatos<UtilEscolar>();
                this.cartuchera.ListaDeUtiles = ado.MostrarBaseDeDatos();
                dataGridView1.DataSource = ado.Tabla;
                this.ActualizarVisor();
            }
            catch (ErrorBaseDeDatoException ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Actualiza la etiqueta de fecha/hora en el formulario.
        /// </summary>
        /// <param name="fecha">Fecha actual para mostrar.</param>
        private void ActualizarFecha(DateTime fecha)
        {
            if (this.lblHora.InvokeRequired)
            {
                DelegadoActualizar d = new DelegadoActualizar(ActualizarFecha);
                object[] arrayParametro = { fecha };

                this.lblHora.Invoke(d, arrayParametro);
            }
            else
            {
                this.lblHora.Text = $"Fecha: {fecha.ToString()}";
            }
        }
        /// <summary>
        /// Bucle de tiempo que actualiza continuamente la etiqueta de fecha/hora cada segundo.
        /// </summary>
        private void BucleTiempo()
        {
            do
            {
                this.ActualizarFecha(DateTime.Now);
                Thread.Sleep(1000);
            } while (true);

        }
        /// <summary>
        /// Maneja el evento Click del menú para cambiar entre el diseño de ListBox y la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mostrarBasedeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstBoxUtiles.Visible)
            {
                mostrarBasedeDatosToolStripMenuItem.Text = "Cambiar Diseño List Box";
                this.lstBoxUtiles.Visible = false;
                this.dataGridView1.Visible = true;
                this.eliminarToolStripMenuItem.Enabled = true;
                this.modificarToolStripMenuItem.Enabled = true;
                this.agregarToolStripMenuItem.Enabled = true;
            }
            else
            {
                mostrarBasedeDatosToolStripMenuItem.Text = "Cambiar Diseño Base de Datos";
                this.MostrarUtiles();
                this.lstBoxUtiles.Visible = true;
                this.dataGridView1.Visible = false;
            }
        }
    }
}
