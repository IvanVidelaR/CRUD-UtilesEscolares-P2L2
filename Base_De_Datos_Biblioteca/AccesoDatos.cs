using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using ExceptionBiblioteca;
using System;

namespace BaseDeDatosBiblioteca
{
    /// <summary>
    /// Clase que implementa la interfaz IAccesoDatos<T> para el acceso a datos relacionados con objetos de tipo UtilEscolar.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto que hereda de UtilEscolar.</typeparam>
    public class AccesoDatos<T> : IAccesoDatos<T> 
        where T : UtilEscolar
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlDataReader lector;
        private DataTable tabla;
        private SqlCommand comando;

        /// <summary>
        /// Obtiene la tabla utilizada para almacenar los datos.
        /// </summary>
        public DataTable Tabla { get => tabla; }
        /// <summary>
        /// Inicializa la cadena de conexión estática.
        /// </summary>
        static AccesoDatos() 
        {
            AccesoDatos<T>.cadena_conexion = Properties.Resources.miConexion;
        }
        /// <summary>
        /// Constructor que inicializa la conexión y la tabla.
        /// </summary>
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos<T>.cadena_conexion);
            this.tabla = new DataTable();
        }
        /// <summary>
        /// Realiza una prueba de conexión a la base de datos.
        /// </summary>
        /// <returns>True si la conexión es exitosa; de lo contrario, False.</returns>
        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
        /// <summary>
        /// Asigna los parámetros relacionados con un objeto UtilEscolar al comando de SQL.
        /// </summary>
        /// <param name="util">Objeto UtilEscolar.</param>
        private void AsignarParametrosUtilEscolar(T util)
        {
            this.comando.Parameters.AddWithValue(@"id_contador_utiles", util.NumeroUtil);
            this.comando.Parameters.AddWithValue("@codigo_barras", util.CodigoDeBarras);
            this.comando.Parameters.AddWithValue("@marca", util.Marca);
            this.comando.Parameters.AddWithValue("@precio", util.Precio);
            this.comando.Parameters.AddWithValue("@peso", util.Peso);
            this.comando.Parameters.AddWithValue("@garantia", util.Garantia ? 1 : 0);

            if(util is Lapicera lapicera)
            {
                this.comando.Parameters.AddWithValue("@tipo_util", "Lapicera");
                this.comando.Parameters.AddWithValue("@nivel_tinta", lapicera.NivelTinta);
                this.comando.Parameters.AddWithValue("@color_tinta", lapicera.ColorTinta.ToString());
                this.comando.Parameters.AddWithValue("@longitud", DBNull.Value);
                this.comando.Parameters.AddWithValue("@es_flexible", DBNull.Value);
                this.comando.Parameters.AddWithValue("@tipo_sacapuntas", DBNull.Value);
                this.comando.Parameters.AddWithValue("@material", DBNull.Value);
            }
            else if(util is Regla regla)
            {
                this.comando.Parameters.AddWithValue("@tipo_util", "Regla");
                this.comando.Parameters.AddWithValue("@nivel_tinta", DBNull.Value);
                this.comando.Parameters.AddWithValue("@color_tinta", DBNull.Value);
                this.comando.Parameters.AddWithValue("@longitud", regla.Longitud);
                this.comando.Parameters.AddWithValue("@es_flexible", regla.EsFlexible ? 1 : 0);
                this.comando.Parameters.AddWithValue("@tipo_sacapuntas", DBNull.Value);
                this.comando.Parameters.AddWithValue("@material", DBNull.Value);
            }
            else if(util is Sacapuntas sacapuntas)
            {
                this.comando.Parameters.AddWithValue("@tipo_util", "Sacapuntas");
                this.comando.Parameters.AddWithValue("@nivel_tinta", DBNull.Value);
                this.comando.Parameters.AddWithValue("@color_tinta", DBNull.Value);
                this.comando.Parameters.AddWithValue("@longitud", DBNull.Value);
                this.comando.Parameters.AddWithValue("@es_flexible", DBNull.Value);
                this.comando.Parameters.AddWithValue("@tipo_sacapuntas", sacapuntas.TipoSacapuntas.ToString());
                this.comando.Parameters.AddWithValue("@material", sacapuntas.Material.ToString());
            }
        }
        /// <summary>
        /// Obtiene una lista de objetos UtilEscolar desde la base de datos.
        /// </summary>
        /// <returns>Lista de objetos UtilEscolar.</returns>
        public List<T> MostrarBaseDeDatos()
        {
            List<T> listaUtiles = new List<T>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "Select * from utilesEscolares";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                this.tabla.Load(this.lector);

                foreach (DataRow fila in tabla.Rows)
                {
                    int id = (int)fila["id_contador_utiles"];
                    int codigoDeBarras = (int)fila["codigo_barras"];
                    string? marca = fila["marca"].ToString().TrimEnd();
                    double precio = Convert.ToDouble(fila["precio"]);
                    int pesoInt = Convert.ToInt32(fila["peso"]);
                    short peso = Convert.ToInt16(pesoInt);
                    bool garantia = Convert.ToBoolean(fila["garantia"]);
                    if (fila["tipo_util"].ToString().Trim() == "Lapicera")
                    {
                        int nivelTintaInt = Convert.ToInt32(fila["nivel_tinta"]);
                        short nivelTinta = Convert.ToInt16(nivelTintaInt);
                        string colorTintaStr = fila["color_tinta"].ToString();
                        EColoresTinta colorTinta = (EColoresTinta)Enum.Parse(typeof(EColoresTinta), colorTintaStr);

                        Lapicera lapicera = new Lapicera(id, codigoDeBarras, marca, precio, peso, garantia, nivelTinta, colorTinta);

                        listaUtiles.Add((T)(UtilEscolar)lapicera);
                    }
                    else if (fila["tipo_util"].ToString().Trim() == "Regla")
                    {
                        double longitud = Convert.ToDouble(fila["longitud"]);
                        bool es_flexible = Convert.ToBoolean(fila["es_flexible"]);

                        Regla regla = new Regla(id, codigoDeBarras, marca, precio, peso, garantia, longitud, es_flexible);
                        listaUtiles.Add((T)(UtilEscolar)regla);
                    }
                    else if (fila["tipo_util"].ToString().Trim() == "Sacapuntas")
                    {
                        string tipoSacapuntasStr = fila["tipo_sacapuntas"].ToString();
                        ETipoSacapuntas tipoSacapuntas = (ETipoSacapuntas)Enum.Parse(typeof(ETipoSacapuntas), tipoSacapuntasStr);
                        string materialSacapuntasStr = fila["material"].ToString();
                        EMaterialSacapuntas materialSacapuntas = (EMaterialSacapuntas)Enum.Parse(typeof(EMaterialSacapuntas), materialSacapuntasStr);

                        Sacapuntas sacapuntas = new Sacapuntas(id, codigoDeBarras, marca, precio, peso, garantia, tipoSacapuntas, materialSacapuntas);
                        listaUtiles.Add((T)(UtilEscolar)sacapuntas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ErrorBaseDeDatoException("Error al traer datos de la base de datos", ex);
            }
            finally
            {
                if (this.lector != null && !this.lector.IsClosed)
                {
                    this.lector.Close();
                }

                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaUtiles;
        }
        /// <summary>
        /// Agrega un objeto UtilEscolar a la base de datos.
        /// </summary>
        /// <param name="objeto">Objeto UtilEscolar a agregar.</param>
        /// <returns>True si la operación es exitosa; de lo contrario, False.</returns>
        public bool AgregarEnBaseDeDatos(T objeto)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "INSERT INTO utilesEscolares (tipo_util,codigo_barras, marca, " +
                    "precio, peso, garantia, nivel_tinta, color_tinta, longitud, es_flexible, tipo_sacapuntas, material) " +
                    "VALUES(@tipo_util,@codigo_barras, @marca, @precio, @peso, @garantia, @nivel_tinta, " +
                    "@color_tinta, @longitud, @es_flexible, @tipo_sacapuntas, @material)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.AsignarParametrosUtilEscolar(objeto);
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorBaseDeDatoException("Error al tratar de agregar datos en la base de datos", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }

            }

            return retorno;
        }
        /// <summary>
        /// Modifica un objeto UtilEscolar en la base de datos.
        /// </summary>
        /// <param name="objeto">Objeto UtilEscolar a modificar.</param>
        /// <returns>True si la operación es exitosa; de lo contrario, False.</returns>
        public bool ModificarEnBaseDeDatos(T objeto)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "UPDATE utilesEscolares SET tipo_util = @tipo_util, codigo_barras = @codigo_barras, marca = @marca, " +
                    "precio = @precio, peso = @peso, garantia = @garantia, nivel_tinta = @nivel_tinta, color_tinta = @color_tinta, longitud = @longitud, " +
                    "es_flexible = @es_flexible, tipo_sacapuntas = @tipo_sacapuntas, material = @material WHERE id_contador_utiles = @id_contador_utiles";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.AsignarParametrosUtilEscolar(objeto);
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorBaseDeDatoException("Error al tratar de modificar datos de la base de datos", ex);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }

            }

            return retorno;
        }
        /// <summary>
        /// Elimina un objeto UtilEscolar de la base de datos.
        /// </summary>
        /// <param name="objeto">Objeto UtilEscolar a eliminar.</param>
        /// <returns>True si la operación es exitosa; de lo contrario, False.</returns>
        public bool EliminarEnBaseDeDatos(T objeto)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "DELETE FROM utilesEscolares WHERE id_contador_utiles = @id_contador_utiles";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.comando.Parameters.AddWithValue(@"id_contador_utiles", objeto.NumeroUtil);
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorBaseDeDatoException("Error al tratar de eliminar datos de la base de datos", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }

            }

            return retorno;
        }
        /// <summary>
        /// Resetea la identificación de la tabla en la base de datos.
        /// </summary>
        /// <returns>True si la operación es exitosa; de lo contrario, False.</returns>
        public bool ResetearTabla()
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "DBCC CHECKIDENT ('utilesEscolares', RESEED, 0)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorBaseDeDatoException("Error al tratar de resetear datos de la base de datos", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }
    }
}
