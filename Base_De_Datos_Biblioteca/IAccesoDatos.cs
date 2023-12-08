using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosBiblioteca
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de acceso a datos para objetos de tipo T.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto.</typeparam>
    public interface IAccesoDatos<T> where T : class
    {
        DataTable Tabla { get; }
        bool PruebaConexion();
        List<T> MostrarBaseDeDatos();
        bool AgregarEnBaseDeDatos(T objeto);
        bool ModificarEnBaseDeDatos(T objeto);
        bool EliminarEnBaseDeDatos(T objeto);
    }
}
