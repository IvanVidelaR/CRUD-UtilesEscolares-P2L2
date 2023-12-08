using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase base abstracta que representa un util escolar.
    /// </summary>
    public abstract class UtilEscolar : IUtilizable
    {
        protected int numeroUtil;
        protected long codigoDeBarras;
        private string? marca;
        protected double precio;
        protected short peso;
        protected bool garantia;

        /// <summary>
        /// Obtiene o establece el número de util del util escolar.
        /// </summary>
        public int NumeroUtil { get { return numeroUtil; } set { numeroUtil = value; } }
        /// <summary>
        /// Obtiene o establece el código de barras del util escolar.
        /// </summary>
        public long CodigoDeBarras { get {  return codigoDeBarras; } set { codigoDeBarras = value; } }
        /// <summary>
        /// Obtiene o establece la marca del util escolar.
        /// </summary>
        public string? Marca { get { return marca; } set { marca = value; } }
        /// <summary>
        /// Obtiene o establece el precio del util escolar.
        /// </summary>
        public double Precio { get { return precio; } set { precio = value; } }
        /// <summary>
        /// Obtiene o establece el peso del util escolar en gramos.
        /// </summary>
        public short Peso { get { return peso; } set { peso = value; } }
        /// <summary>
        /// Obtiene o establece si el utensilio escolar tiene garantía.
        /// </summary>
        public bool Garantia { get { return garantia; } set { garantia = value; } }

        public UtilEscolar()
        {

        }
        /// <summary>
        /// Constructor privado de la clase UtilEscolar utilizado para establecer el peso y la garantía del util escolar.
        /// </summary>
        /// <param name="peso">El peso del util escolar en gramos.</param>
        /// <param name="garantia">Indica si el util escolar tiene garantía.</param>
        private UtilEscolar(short peso, bool garantia)
        {
            this.peso = peso;
            this.garantia = garantia;
        }
        /// <summary>
        /// Constructor protegido de la clase UtilEscolar utilizado para inicializar una instancia de la clase con ciertos parámetros, estableciendo el peso predeterminado y sin garantía.
        /// </summary>
        /// <param name="numeroUtil">Número del util escolar.</param>
        /// <param name="codigoDeBarras">Código de barras del util escolar.</param>
        /// <param name="marca">Marca del util escolar.</param>
        /// <param name="precio">Precio del util escolar.</param>
        protected UtilEscolar(int numeroUtil, long codigoDeBarras, string marca, double precio) 
            : this(300, false)
        {
            this.numeroUtil = numeroUtil;
            this.codigoDeBarras = codigoDeBarras;
            this.marca = marca;
            this.precio = precio;
        }
        /// <summary>
        /// Constructor protegido de la clase UtilEscolar utilizado para inicializar una instancia de la clase con ciertos parámetros, estableciendo el peso predeterminado.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras del util escolar.</param>
        /// <param name="marca">Marca del util escolar.</param>
        /// <param name="precio">Precio del util escolar.</param>
        /// <param name="peso">Peso del util escolar en gramos.</param>
        protected UtilEscolar(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso)
            :this(numeroUtil, codigoDeBarras, marca, precio)
        {
            this.peso = peso;
        }
        /// <summary>
        /// Constructor protegido de la clase UtilEscolar utilizado para inicializar una instancia de la clase con ciertos parámetros.
        /// </summary>
        /// <param name="numeroUtil">Número de util.</param>
        /// <param name="codigoDeBarras">Código de barras del util escolar.</param>
        /// <param name="marca">Marca del util escolar.</param>
        /// <param name="precio">Precio del util escolar.</param>
        /// <param name="peso">Peso del util escolar en gramos.</param>
        /// <param name="garantia">Indica si el util escolar tiene garantía.</param>

        protected UtilEscolar(int numeroUtil, long codigoDeBarras, string marca, double precio, short peso, bool garantia) 
            : this(numeroUtil, codigoDeBarras, marca, precio, peso)
        {
            this.garantia = garantia;
        }
        /// <summary>
        /// Método abstracto que debe ser implementado por las clases derivadas.
        /// Describe cómo se utiliza el util escolar.
        /// </summary>
        /// <returns>Una cadena que describe el uso del utensilio escolar.</returns>
        public abstract string Utilizar();
        /// <summary>
        /// Calcula el descuento aplicado al util escolar basado en ciertas condiciones.
        /// </summary>
        /// <returns>El monto del descuento aplicado.</returns>
        public virtual double CalcularDescuento()
        {
            double descuento = 0;

            if (this.precio >= 350 && this.numeroUtil >= 5)
            {
                descuento = this.precio * 0.25;
            }
            else if (this.precio >= 250 && this.numeroUtil >= 2)
            {
                descuento = this.precio * 0.10;
            }

            return descuento;
        }
        /// <summary>
        /// Calcula el descuento aplicado al utensilio escolar utilizando un porcentaje de descuento personalizado.
        /// </summary>
        /// <param name="descuentoPorcentaje">El porcentaje de descuento a aplicar.</param>
        /// <returns>El monto del descuento aplicado.</returns>
        public double CalcularDescuento(double descuentoPorcentaje)
        {
            return this.precio * (descuentoPorcentaje / 100);
        }
        /// <summary>
        /// Devuelve una representación en cadena del util escolar y sus propiedades.
        /// </summary>
        /// <returns>Una cadena que representa el util escolar y sus propiedades.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double descuento = 0;

            if(this.garantia == true && numeroUtil > 10 && precio >= 450)
            {
                descuento = this.CalcularDescuento(100);                
            }
            else
            {
                descuento = this.CalcularDescuento();
            }
            sb.AppendLine($"{this.numeroUtil} Código: {this.codigoDeBarras} Marca: {this.marca} Precio: {this.precio} Descuento: {descuento} Peso: {this.peso}g Garantía: {this.garantia}");

            return sb.ToString();
        }
        /// <summary>
        /// Compara dos utiles escolares para determinar si son iguales.
        /// </summary>
        /// <param name="util1">El primer util escolar a comparar.</param>
        /// <param name="util2">El segundo util escolar a comparar.</param>
        /// <returns>True si los utiles son iguales, de lo contrario, false.</returns>
        public static bool operator ==(UtilEscolar util1 , UtilEscolar util2)
        {
            return (util1.codigoDeBarras == util2.codigoDeBarras) && (util1.numeroUtil == util2.numeroUtil);
        }
        /// <summary>
        /// Compara dos utiles escolares para determinar si son diferentes.
        /// </summary>
        /// <param name="util1">El primer util escolar a comparar.</param>
        /// <param name="util2">El segundo util escolar a comparar.</param>
        /// <returns>True si los utiles son diferentes, de lo contrario, false.</returns>
        public static bool operator !=(UtilEscolar util1, UtilEscolar util2)
        {
            return !(util1 == util2);
        }
        /// <summary>
        /// Compara el util escolar actual con otro objeto para determinar si son iguales.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el util escolar actual.</param>
        /// <returns>True si el util escolar es igual al objeto, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retornoAux = false;

            if (obj is UtilEscolar)
            {
                retornoAux = this == (UtilEscolar)obj;
            }

            return retornoAux;
        }
        /// <summary>
        /// Obtiene el código hash del util escolar.
        /// </summary>
        /// <returns>El código hash del util escolar.</returns>
        public override int GetHashCode()
        {
            int hash = 3;

            hash = (hash * 5) + codigoDeBarras.GetHashCode();
            hash = (hash * 5) + numeroUtil.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Convierte el precio del util escolar a un valor de tipo double.
        /// </summary>
        /// <param name="util">El util escolar a convertir.</param>
        public static explicit operator double(UtilEscolar util)
        {
            return util.precio;
        }
        /// <summary>
        /// Convierte la marca del util escolar a un valor de tipo string.
        /// </summary>
        /// <param name="util">El util escolar a convertir</param>
        public static explicit operator string(UtilEscolar util)
        {
            string retorno = "";
            if(util.marca != null)
            {
                retorno = util.marca;
            }
            return retorno;
        }

    }
}