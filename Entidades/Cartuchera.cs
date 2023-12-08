using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa una cartuchera que contiene útiles escolares.
    /// </summary>
    public class Cartuchera: IUtilizable
    {
        private string? nombre;
        private int ancho;
        private short cantidadUtilesMaximos;
        private List<UtilEscolar> listaDeUtiles;
        /// <summary>
        /// Obtiene o establece la lista de útiles escolares en la cartuchera.
        /// </summary>
        public List<UtilEscolar> ListaDeUtiles { get { return listaDeUtiles; } set { listaDeUtiles = value; } }
        /// <summary>
        /// Indexador que permite acceder a los útiles escolares en la cartuchera por su índice.
        /// </summary>
        /// <param name="indice">El índice del útil escolar.</param>
        /// <returns>El útil escolar en el índice especificado.</returns>
        public UtilEscolar this[int indice]
        {
            get
            {
                return listaDeUtiles[indice];
            }
            set
            {
                listaDeUtiles[indice] = value;
            }
        }
        private Cartuchera()
        {
            listaDeUtiles = new List<UtilEscolar>();
        }
        /// <summary>
        /// Crea una nueva instancia de la clase Cartuchera.
        /// </summary>
        /// <param name="cantidadUtilesMaximos">La cantidad máxima de útiles que puede contener la cartuchera.</param>
        /// <param name="nombre">El nombre de la cartuchera.</param>
        public Cartuchera(short cantidadUtilesMaximos, string nombre) : this ()
        {
            this.cantidadUtilesMaximos = cantidadUtilesMaximos;
            this.nombre = nombre;
        }
        /// <summary>
        /// Crea una nueva instancia de la clase Cartuchera.
        /// </summary>
        /// <param name="cantidadUtilesMaximos">La cantidad máxima de útiles que puede contener la cartuchera.</param>
        /// <param name="nombre">El nombre de la cartuchera.</param>
        /// <param name="listaDeUtiles">La lista de útiles escolares inicial de la cartuchera.</param>
        public Cartuchera(short cantidadUtilesMaximos, string nombre, List<UtilEscolar> listaDeUtiles) : this (cantidadUtilesMaximos, nombre)
        {
            this.listaDeUtiles = listaDeUtiles;
        }
        /// <summary>
        /// Crea una nueva instancia de la clase Cartuchera.
        /// </summary>
        /// <param name="cantidadUtilesMaximos">La cantidad máxima de útiles que puede contener la cartuchera.</param>
        /// <param name="nombre">El nombre de la cartuchera.</param>
        /// <param name="listaDeUtiles">La lista de útiles escolares inicial de la cartuchera.</param>
        /// <param name="ancho">El ancho de la cartuchera.</param>
        public Cartuchera(short cantidadUtilesMaximos, string nombre, List<UtilEscolar> listaDeUtiles, int ancho) : this(cantidadUtilesMaximos, nombre, listaDeUtiles)
        {
            this.ancho = ancho;
        }
        /// <summary>
        /// Compara dos útiles escolares y verifica si son iguales.
        /// </summary>
        /// <param name="cartuchera">La cartuchera en la que se busca el útil escolar.</param>
        /// <param name="utilEscolar">El útil escolar que se compara.</param>
        /// <returns>True si el útil escolar está en la cartuchera, de lo contrario, false.</returns>
        public static bool operator ==(Cartuchera cartuchera, UtilEscolar utilEscolar)
        {
            bool retornoAux = false;

            foreach (UtilEscolar util in cartuchera.listaDeUtiles)
            {
                if(util == utilEscolar)
                {
                    retornoAux = true;
                }
            }

            return retornoAux;
        }
        /// <summary>
        /// Compara dos útiles escolares y verifica si son diferentes.
        /// </summary>
        /// <param name="cartuchera">La cartuchera en la que se busca el útil escolar.</param>
        /// <param name="utilEscolar">El útil escolar que se compara.</param>
        /// <returns>True si el útil escolar no está en la cartuchera, de lo contrario, false.</returns>
        public static bool operator !=(Cartuchera cartuchera, UtilEscolar utilEscolar)
        {
            return !(cartuchera == utilEscolar);
        }
        /// <summary>
        /// Compara esta cartuchera con otro objeto para verificar si son iguales.
        /// </summary>
        /// <param name="obj">El objeto con el que se compara la cartuchera.</param>
        /// <returns>True si los objetos son iguales, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Cartuchera otraCartuchera)
            {
                return this.cantidadUtilesMaximos == otraCartuchera.cantidadUtilesMaximos &&
                       this.nombre == otraCartuchera.nombre &&
                       this.listaDeUtiles.SequenceEqual(otraCartuchera.listaDeUtiles);
            }

            return false;
        }
        /// <summary>
        /// Agrega un útil escolar a la cartuchera si hay espacio y no está repetido.
        /// </summary>
        /// <param name="cartuchera">La cartuchera a la que se agrega el útil escolar.</param>
        /// <param name="utilEscolar">El útil escolar que se agrega.</param>
        /// <returns>La cartuchera con el útil escolar agregado.</returns>
        public static Cartuchera operator +(Cartuchera cartuchera, UtilEscolar utilEscolar)
        {
            if (cartuchera.listaDeUtiles.Count < cartuchera.cantidadUtilesMaximos && cartuchera != utilEscolar)
            {
                cartuchera.listaDeUtiles.Add(utilEscolar);                    
            }

            return cartuchera;
        }
        /// <summary>
        /// Elimina un útil escolar de la cartuchera si está presente.
        /// </summary>
        /// <param name="cartuchera">La cartuchera de la que se elimina el útil escolar.</param>
        /// <param name="utilEscolar">El útil escolar que se elimina.</param>
        /// <returns>La cartuchera con el útil escolar eliminado.</returns>
        public static Cartuchera operator -(Cartuchera cartuchera, UtilEscolar utilEscolar)
        {
            if (cartuchera.listaDeUtiles.Count > 0 && cartuchera == utilEscolar)
            {
                cartuchera.listaDeUtiles.Remove(utilEscolar);
            }

            return cartuchera;
        }

        public static int OrdenarUtilesPorPrecioAscendente(UtilEscolar util1, UtilEscolar util2)
        {
            double precio1 = (double)util1; 
            double precio2 = (double)util2;

            if (precio1 < precio2)
                return -1;
            else if (precio1 > precio2)
                return 1;
            else
                return 0;
        }

        public static int OrdenarUtilesPorPrecioDescendente(UtilEscolar util1, UtilEscolar util2)
        {
            double precio1 = (double)util1;
            double precio2 = (double)util2;

            if (precio1 > precio2)
                return -1;
            else if (precio1 < precio2)
                return 1;
            else
                return 0;
        }

        public static int OrdenarUtilesPorNumeroAscendente(UtilEscolar util1, UtilEscolar util2)
        {
            if (util1.NumeroUtil < util2.NumeroUtil)
                return -1;
            else if (util1.NumeroUtil > util2.NumeroUtil)
                return 1;
            else
                return 0;
        }

        public static int OrdenarUtilesPorNumeroDescendente(UtilEscolar util1, UtilEscolar util2)
        {
            if (util1.NumeroUtil > util2.NumeroUtil)
                return -1;
            else if (util1.NumeroUtil < util2.NumeroUtil)
                return 1;
            else
                return 0;
        }
        public static int OrdenarUtilesPorMarcaAscendente(UtilEscolar util1, UtilEscolar util2)
        {
            string marca1 = (string)util1;
            string marca2 = (string)util2;

            return String.Compare(marca1, marca2);
        }
        public static int OrdenarUtilesPorMarcaDescendente(UtilEscolar util1, UtilEscolar util2)
        {
            string marca1 = (string)util1;
            string marca2 = (string)util2;

            return String.Compare(marca2, marca1);
        }
        /// <summary>
        /// Obtiene el código hash de la cartuchera.
        /// </summary>
        /// <returns>El código hash de la cartuchera.</returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode());
        }
        /// <summary>
        /// Método que simula el uso de la cartuchera, haciendo uso de interfaz.
        /// </summary>
        /// <returns>Una cadena que describe el uso de la cartuchera.</returns>
        public string Utilizar()
        {
            return "Abriendo cartuchera...";
        }
    }
}
