using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un sacapuntas, un tipo de util escolar.
    /// </summary>
    public class Sacapuntas : UtilEscolar, IUtilizable
    {
        private ETipoSacapuntas tipoSacapuntas;
        private EMaterialSacapuntas material;
        /// <summary>
        /// Obtiene o establece el tipo de sacapuntas.
        /// </summary>
        public ETipoSacapuntas TipoSacapuntas { get { return  tipoSacapuntas; } set { tipoSacapuntas = value; } }
        /// <summary>
        /// Obtiene o establece el material del sacapuntas.
        /// </summary>
        public EMaterialSacapuntas Material { get { return material; } set { material = value; } }

        public Sacapuntas()
        {

        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Sacapuntas con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras del sacapuntas.</param>
        /// <param name="marca">Marca del sacapuntas.</param>
        /// <param name="precio">Precio del sacapuntas.</param>
        /// <param name="tipoSacapuntas">Tipo de sacapuntas.</param>
        /// <param name="material">Material del sacapuntas.</param>
        public Sacapuntas(int numeroUtil, long codigoDeBarras, string marca, double precio, ETipoSacapuntas tipoSacapuntas, EMaterialSacapuntas material)
            : base(numeroUtil, codigoDeBarras, marca, precio)
        {
            this.tipoSacapuntas = tipoSacapuntas;
            this.material = material;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Sacapuntas con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras del sacapuntas.</param>
        /// <param name="marca">Marca del sacapuntas.</param>
        /// <param name="precio">Precio del sacapuntas.</param>
        /// <param name="peso">Peso del sacapuntas.</param>
        /// <param name="tipoSacapuntas">Tipo de sacapuntas.</param>
        /// <param name="material">Material del sacapuntas.</param>
        public Sacapuntas(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, ETipoSacapuntas tipoSacapuntas, EMaterialSacapuntas material) 
            : base(numeroUtil, codigoDeBarras, marca, precio, peso)
        {
            this.tipoSacapuntas = tipoSacapuntas;
            this.material = material;
        }
        /// <summary>
        /// Constructor que inicializa una instancia de la clase Sacapuntas con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras del sacapuntas.</param>
        /// <param name="marca">Marca del sacapuntas.</param>
        /// <param name="precio">Precio del sacapuntas.</param>
        /// <param name="peso">Peso del sacapuntas.</param>
        /// <param name="garantia">Garantía del sacapuntas.</param>
        /// <param name="tipoSacapuntas">Tipo de sacapuntas.</param>
        /// <param name="material">Material del sacapuntas.</param>
        public Sacapuntas(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, bool garantia, ETipoSacapuntas tipoSacapuntas, EMaterialSacapuntas material) 
            : base(numeroUtil, codigoDeBarras, marca, precio, peso, garantia)
        {
            this.tipoSacapuntas = tipoSacapuntas;
            this.material = material;
        }
        /// <summary>
        /// Calcula el descuento aplicado al sacapuntas, si es de tipo doble se agrega descuento de 1/5 del precio.
        /// </summary>
        /// <returns>El monto del descuento aplicado.</returns>
        public override double CalcularDescuento()
        {
            double sumaDescuento = 0;

            if(this.tipoSacapuntas == ETipoSacapuntas.Doble)
            {
                sumaDescuento = this.precio / 5; 
            }

            return base.CalcularDescuento() + sumaDescuento;
        }
        /// <summary>
        /// Método que simula el uso del sacapuntas, haciendo uso de interfaz.
        /// </summary>
        /// <returns>Una cadena que describe el uso del sacapuntas.</returns>
        public override string Utilizar()
        {
            return "Probando sacapuntas - afilando lápiz con el sacapuntas...";
        }
        /// <summary>
        /// Devuelve una representación en cadena del sacapuntas.
        /// </summary>
        /// <returns>Una cadena que representa el sacapuntas y sus propiedades.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Sacapuntas {base.ToString()} Tipo: {this.tipoSacapuntas} Material: {this.material}");
            return sb.ToString();
        }
        /// <summary>
        /// Compara el sacapuntas actual con otro sapuntas para determinar si son iguales, sumando el tipo de sacapuntas como opcion.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si los objetos son iguales, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retornoAux = base.Equals(obj);

            if (obj is Sacapuntas)
            {
                retornoAux = base.Equals(obj) && this.tipoSacapuntas == ((Sacapuntas)obj).tipoSacapuntas;
            }

            return retornoAux;
        }
        /// <summary>
        /// Obtiene el código hash del sacapuntas.
        /// </summary>
        /// <returns>El código hash del sacapuntas.</returns>
        public override int GetHashCode()
        {
            return(base.GetHashCode());
        }
    }
}
