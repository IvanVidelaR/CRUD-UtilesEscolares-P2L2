using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionBiblioteca
{
    /// <summary>
    /// Excepción personalizada para representar errores relacionados con operaciones inválidas.
    /// </summary>
    public class OperacionInvalidaException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase sin mensaje.
        /// </summary>
        public OperacionInvalidaException()
            : base("Error en base de datos")
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje especificado.
        /// </summary>
        /// <param name="message">Mensaje de la excepción.</param>
        public OperacionInvalidaException(string message) : base(message)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje y una excepción interna.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción.</param>
        /// <param name="innerException">Excepción interna que causó la excepción actual.</param>
        public OperacionInvalidaException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje, una excepción interna y un origen específico del error.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción.</param>
        /// <param name="innerException">Excepción interna que causó la excepción actual.</param>
        /// <param name="origenError">Origen específico del error.</param>
        public OperacionInvalidaException(string mensaje, Exception innerException, string origenError)
            : base(mensaje, innerException)
        {
            base.Source = origenError;
        }
        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Cadena que representa la excepción.</returns>
        public override string ToString()
        {
            return $"ERROR OPERACIÓN INVÁLIDA - {base.Message}";
        }
    }
}
