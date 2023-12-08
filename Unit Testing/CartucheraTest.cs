using Entidades;

namespace UnitTesting
{
    [TestClass]
    public class CartucheraTest
    {
        [TestMethod]
        public void AgregarUtil_CuandoCartucheraNoEstaLlenaYUtilNoEstaPresente_DeberiaAgregarUtil()
        {
            Cartuchera cartuchera = new Cartuchera(5, "CartucheraTest");
            Lapicera lapicera = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            int cantidadInicial = cartuchera.ListaDeUtiles.Count;

            cartuchera += lapicera;

            Assert.AreEqual(cantidadInicial + 1, cartuchera.ListaDeUtiles.Count);
            Assert.IsTrue(cartuchera.ListaDeUtiles.Contains(lapicera));
        }

        [TestMethod]
        public void AgregarUtil_CuandoCartucheraEstaLlena_DeberiaNoAgregarUtil()
        {
            Cartuchera cartuchera = new Cartuchera(2, "CartucheraTest");
            Lapicera lapicera1 = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            Lapicera lapicera2 = new Lapicera(2, 124, "Marca2", 15, 60, false, 3, EColoresTinta.Negra);
            Lapicera lapicera3 = new Lapicera(3, 125, "Marca3", 20, 70, true, 8, EColoresTinta.Roja);

            cartuchera += lapicera1;
            cartuchera += lapicera2;
            cartuchera += lapicera3; // Esta no debería agregarse

            Assert.AreEqual(2, cartuchera.ListaDeUtiles.Count);
            Assert.IsFalse(cartuchera.ListaDeUtiles.Contains(lapicera3));
        }

        [TestMethod]
        public void QuitarUtil_CuandoUtilEstaPresente_DeberiaQuitarUtil()
        {
            Cartuchera cartuchera = new Cartuchera(5, "CartucheraTest");
            Lapicera lapicera = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            cartuchera += lapicera;
            int cantidadInicial = cartuchera.ListaDeUtiles.Count;

            cartuchera -= lapicera;

            Assert.AreEqual(cantidadInicial - 1, cartuchera.ListaDeUtiles.Count);
            Assert.IsFalse(cartuchera.ListaDeUtiles.Contains(lapicera));
        }

        [TestMethod]
        public void QuitarUtil_CuandoUtilNoEstaPresente_DeberiaNoQuitarUtil()
        {
            Cartuchera cartuchera = new Cartuchera(5, "CartucheraTest");
            Lapicera lapicera = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            int cantidadInicial = cartuchera.ListaDeUtiles.Count;

            cartuchera -= lapicera;

            Assert.AreEqual(cantidadInicial, cartuchera.ListaDeUtiles.Count);
            Assert.IsFalse(cartuchera.ListaDeUtiles.Contains(lapicera));
        }

        [TestMethod]
        public void Equals_CuandoComparoCartucherasIguales_DeberiaRetornarTrue()
        {
            Cartuchera cartuchera1 = new Cartuchera(5, "CartucheraTest");
            Cartuchera cartuchera2 = new Cartuchera(5, "CartucheraTest");
            Lapicera lapicera = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            cartuchera1 += lapicera;
            cartuchera2 += lapicera;

            Assert.AreEqual(cartuchera1, cartuchera2);
        }

        [TestMethod]
        public void Equals_CuandoComparoCartucherasDiferentes_DeberiaRetornarFalse()
        {
            Cartuchera cartuchera1 = new Cartuchera(5, "CartucheraTest1");
            Cartuchera cartuchera2 = new Cartuchera(5, "CartucheraTest2");
            Lapicera lapicera = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            cartuchera1 += lapicera;
            cartuchera2 += lapicera;

            Assert.AreNotEqual(cartuchera1, cartuchera2);
        }
    }
}