using Entidades;

namespace Unit_Testing
{
    [TestClass]
    public class UtilEscolarTest
    {
        [TestMethod]
        public void Equals_CuandoComparoUtilsEscolaresIguales_DeberiaRetornarTrue()
        {
            UtilEscolar util1 = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            UtilEscolar util2 = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);

            Assert.AreEqual(util1, util2);
        }

        [TestMethod]
        public void Equals_CuandoComparoUtilsEscolaresDiferentes_DeberiaRetornarFalse()
        {
            UtilEscolar util1 = new Lapicera(1, 123, "Marca1", 10, 50, true, 5, EColoresTinta.Azul);
            UtilEscolar util2 = new Lapicera(2, 456, "Marca2", 15, 60, false, 7, EColoresTinta.Negra);

            Assert.AreNotEqual(util1, util2);
        }

        [TestMethod]
        public void CalcularDescuento_CuandoPrecioMayorIgual350YNumeroUtilMayorIgual5_DeberiaCalcularDescuento25PorCiento()
        {
            UtilEscolar util = new Lapicera(5, 123, "Marca1", 400, 50, true, 5, EColoresTinta.Azul);

            double descuento = util.CalcularDescuento();

            Assert.AreEqual(100, descuento);
        }

        [TestMethod]
        public void CalcularDescuento_CuandoPrecioMayorIgual250YNumeroUtilMayorIgual2YMenor5_DeberiaCalcularDescuento10PorCiento()
        {
            UtilEscolar util = new Lapicera(3, 123, "Marca1", 300, 50, true, 3, EColoresTinta.Azul);

            double descuento = util.CalcularDescuento();

            Assert.AreEqual(30, descuento);
        }

        [TestMethod]
        public void CalcularDescuento_CuandoPrecioMenor250_DeberiaNoCalcularDescuento()
        {
            UtilEscolar util = new Lapicera(1, 123, "Marca1", 200, 50, true, 3, EColoresTinta.Azul);

            double descuento = util.CalcularDescuento();

            Assert.AreEqual(0, descuento);
        }
    }
}
