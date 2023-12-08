using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz que define el comportamiento de un objeto que puede ser utilizado.
    /// </summary>
    public interface IUtilizable
    {
        /// <summary>
        /// Método que describe la acción de utilizar el objeto.
        /// </summary>
        /// <returns>Una cadena que representa la acción de utilizar el objeto.</returns>
        string Utilizar();
    }
}
