using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una lapicera, un tipo de util escolar.
    /// </summary>
    public class Lapicera : UtilEscolar, IUtilizable
    {
        private short nivelTinta;
        private EColoresTinta colorTinta;

        /// <summary>
        /// Obtiene o establece el nivel de tinta de la lapicera.
        /// </summary>
        public short NivelTinta { get { return nivelTinta; } set { nivelTinta = value; } }
        /// <summary>
        /// Obtiene o establece el color de tinta de la lapicera.
        /// </summary>
        public EColoresTinta ColorTinta { get { return colorTinta; } set { colorTinta = value; } }
        public Lapicera()
        {

        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Lapicera con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la lapicera.</param>
        /// <param name="marca">Marca de la lapicera.</param>
        /// <param name="precio">Precio de la lapicera.</param>
        /// <param name="nivelTinta">Nivel de tinta de la lapicera.</param>
        /// <param name="colorTinta">Color de tinta de la lapicera.</param>
        public Lapicera(int numeroUtil, long codigoDeBarras, string marca, double precio, short nivelTinta, EColoresTinta colorTinta) 
            : base(numeroUtil, codigoDeBarras, marca, precio)
        {
            this.nivelTinta = nivelTinta;
            this.colorTinta = colorTinta;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Lapicera con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la lapicera.</param>
        /// <param name="marca">Marca de la lapicera.</param>
        /// <param name="precio">Precio de la lapicera.</param>
        /// <param name="peso">Peso de la lapicera.</param>
        /// <param name="nivelTinta">Nivel de tinta de la lapicera.</param>
        /// <param name="colorTinta">Color de tinta de la lapicera.</param>
        public Lapicera(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, short nivelTinta, EColoresTinta colorTinta) 
            : base(numeroUtil, codigoDeBarras, marca, precio, peso)
        {
            this.nivelTinta = nivelTinta;
            this.colorTinta = colorTinta;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Lapicera con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras de la lapicera.</param>
        /// <param name="marca">Marca de la lapicera.</param>
        /// <param name="precio">Precio de la lapicera.</param>
        /// <param name="peso">Peso de la lapicera.</param>
        /// <param name="garantia">Garantia de la lapicera.</param>
        /// <param name="nivelTinta">Nivel de tinta de la lapicera.</param>
        /// <param name="colorTinta">Color de tinta de la lapicera.</param>
        public Lapicera(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, bool garantia, short nivelTinta, EColoresTinta colorTinta) 
            : base(numeroUtil, codigoDeBarras, marca, precio, peso, garantia)
        {
            this.nivelTinta = nivelTinta;
            this.colorTinta = colorTinta;
        }
        /// <summary>
        /// Método que simula el uso de la lapicera, haciendo uso de interfaz.
        /// </summary>
        /// <returns>Una cadena que describe el uso de la lapicera.</returns>
        public override string Utilizar()
        {
            return "Probando lapicera - escribiendo con la lapicera...";
        }
        /// <summary>
        /// Calcula el descuento aplicado a la lapicera.
        /// </summary>
        /// <returns>El monto del descuento aplicado.</returns>
        public override double CalcularDescuento()
        {
            double sumaDescuento = 0;

            if (this.colorTinta == EColoresTinta.Verde || this.colorTinta == EColoresTinta.Roja)
            {
                sumaDescuento = this.precio / 5;
            }

            return base.CalcularDescuento() + sumaDescuento;
        }
        /// <summary>
        /// Devuelve una representación en cadena de la lapicera.
        /// </summary>
        /// <returns>Una cadena que representa la lapicera y sus propiedades.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Lapicera {base.ToString()} Tinta: {this.nivelTinta} Color: {this.colorTinta}");

            return sb.ToString();
        }

        /// <summary>
        /// Compara la lapicera actual con otra lapicera para determinar si son iguales, sumando el color de tinta como opcion.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si los objetos son iguales, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retornoAux = base.Equals(obj);

            if (obj is Lapicera)
            {
                retornoAux = base.Equals(obj) && this.colorTinta == ((Lapicera)obj).colorTinta;
            }

            return retornoAux;
        }
        /// <summary>
        /// Obtiene el código hash de la lapicera.
        /// </summary>
        /// <returns>El código hash de la lapicera.</returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode());
        }
    }
}
