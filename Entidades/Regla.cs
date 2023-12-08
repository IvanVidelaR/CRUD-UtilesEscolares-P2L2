using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una regla, un tipo de util escolar.
    /// </summary>
    public class Regla : UtilEscolar, IUtilizable
    {
        private double longitud;
        private bool esFlexible;
        /// <summary>
        /// Obtiene o establece la longitud de la regla en centímetros.
        /// </summary>
        public double Longitud { get { return longitud; } set { longitud = value; } }
        /// <summary>
        /// Obtiene o establece si la regla es flexible o no.
        /// </summary>
        public bool EsFlexible { get { return esFlexible; } set { esFlexible = value; } }
        public Regla()
        {

        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Regla con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la regla.</param>
        /// <param name="marca">Marca de la regla.</param>
        /// <param name="precio">Precio de la regla.</param>
        /// <param name="longitud">Longitud de la regla en centímetros.</param>
        /// <param name="esFlexible">Indica si la regla es flexible.</param>
        public Regla(int numeroUtil, long codigoDeBarras, string marca, double precio, double longitud, bool esFlexible)
            : base(numeroUtil, codigoDeBarras, marca, precio)
        {
            this.longitud = longitud;
            this.esFlexible = esFlexible;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Regla con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la regla.</param>
        /// <param name="marca">Marca de la regla.</param>
        /// <param name="precio">Precio de la regla.</param>
        /// <param name="peso">Peso de la regla.</param>
        /// <param name="longitud">Longitud de la regla en centímetros.</param>
        /// <param name="esFlexible">Indica si la regla es flexible.</param>
        public Regla(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, double longitud, bool esFlexible)
            : base(numeroUtil, codigoDeBarras, marca, precio, peso)
        {
            this.longitud = longitud;
            this.esFlexible = esFlexible;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Regla con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la regla.</param>
        /// <param name="marca">Marca de la regla.</param>
        /// <param name="precio">Precio de la regla.</param>
        /// <param name="peso">Peso de la regla.</param>
        /// <param name="garantia">Garantía de la regla.</param>
        /// <param name="longitud">Longitud de la regla en centímetros.</param>
        /// <param name="esFlexible">Indica si la regla es flexible.</param>
        public Regla(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, bool garantia, double longitud, bool esFlexible) 
            : base(numeroUtil, codigoDeBarras, marca, precio, peso, garantia)
        {
            this.longitud = longitud;
            this.esFlexible = esFlexible;
        }
        /// <summary>
        /// Método que simula el uso de la regla, haciendo uso de interfaz.
        /// </summary>
        /// <returns>Una cadena que describe el uso de la regla.</returns>
        public override string Utilizar()
        {
            return "Probando regla - midiendo con la regla...";
        }
        /// <summary>
        /// Devuelve una representación en cadena de la regla.
        /// </summary>
        /// <returns>Una cadena que representa la regla y sus propiedades.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Regla {base.ToString()} Long: {this.longitud}cm Flex: {this.esFlexible}");

            return sb.ToString();
        }
        /// <summary>
        /// Compara la regla actual con otra la lapicera para determinar si son iguales, sumando la longitud como opcion.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si los objetos son iguales, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retornoAux = base.Equals(obj);

            if (obj is Regla)
            {
                retornoAux = base.Equals(obj) && this.longitud == ((Regla)obj).longitud;
            }

            return retornoAux;
        }
        /// <summary>
        /// Obtiene el código hash de la regla.
        /// </summary>
        /// <returns>El código hash de la regla.</returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode());
        }
    }
}
