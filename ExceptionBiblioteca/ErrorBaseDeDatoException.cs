namespace ExceptionBiblioteca
{
    /// <summary>
    /// Excepción personalizada para representar errores relacionados con la base de datos.
    /// </summary>
    public class ErrorBaseDeDatoException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase sin mensaje.
        /// </summary>
        public ErrorBaseDeDatoException()
            : base("Error en base de datos")
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje especificado.
        /// </summary>
        /// <param name="message">Mensaje de la excepción.</param>
        public ErrorBaseDeDatoException(string message) : base(message)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje especificado.
        /// </summary>
        /// <param name="message">Mensaje de la excepción.</param>
        public ErrorBaseDeDatoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase con un mensaje, una excepción interna y un origen específico del error.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción.</param>
        /// <param name="innerException">Excepción interna que causó la excepción actual.</param>
        /// <param name="origenError">Origen específico del error.</param>
        public ErrorBaseDeDatoException(string mensaje, Exception innerException, string origenError)
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
            return $"ERROR BASE DE DATOS - {base.Message}: {base.InnerException.Message} - Origen: {base.Source}";
        }
    }
}