using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Dominio.Tests
{
    [TestClass()]
    public class BaralhoTests
    {
        [TestMethod()]
        public void MontarBaralhoTest()
        {
            var Baralho = new Baralho();

            Assert.IsTrue(Baralho.Cartas.Count == 52);
        }
        [TestMethod()]
        public void QuantidadeOuro()
        {
            var Baralho = new Baralho();
            var ouro = Baralho.Cartas.Where(c => c.Naipe== Naipe.Ouros).ToList();

            Assert.IsTrue(ouro.Count == 13);
        }
        [TestMethod()]
        public void QuantidadeNaipe()
        {
            var Baralho = new Baralho();
            var naipe = Baralho.Cartas.GroupBy(c => c.Naipe);

            Assert.IsTrue(naipe.Count() == 4);
        }

        [TestMethod()]
        public void CartasOuro()
        {
            var Baralho = new Baralho();
            var naipe = Baralho.Cartas.GroupBy(c => c.Naipe);
            var ouros = Baralho.Cartas.Where(c => c.Naipe == Naipe.Ouros).ToList();
            var face = 1;

            foreach (var ouro in ouros)
            {
                Assert.IsTrue(Convert.ToInt32(ouro.Face) == face++);
            }
            
        }
    }
}