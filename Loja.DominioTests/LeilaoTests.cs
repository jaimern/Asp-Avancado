using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Tests
{
    [TestClass()]
    public class LeilaoTests
    {
        [TestMethod()]
        public void validarSucessoTest()
        {
            //Arrange
            var leilao = new Leilao();
            leilao.id = 1;
            leilao.Nomelote = "teste";
            leilao.preco = 90;
            leilao.Produtos = new List<Produto>
            { new Produto{
                Preco=100

            } };

            //Act

            var erros = leilao.validar();

            //Assert

            Assert.IsTrue(erros.Count == 0);

        }

        public void validarSemSucessoTest()
        {
            //Arrange
            var leilao = new Leilao();
            leilao.id = 1;
            leilao.Nomelote = "teste";
            leilao.preco = 89.9m;
            leilao.Produtos = new List<Produto>
            { new Produto{
                Preco=100

            } };

            //Act

            var erros = leilao.validar();

            //Assert

            Assert.IsTrue(erros.Contains ("Desconto máximo excedido!"));

        }
    }
}