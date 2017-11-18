using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Leilao
    {
        public const decimal DescontoMaximo = 0.1m;
        public int id { get; set; }
        public string Nomelote { get; set; }
        public decimal preco { get; set; }
        public List<Produto> Produtos { get; set; }

        public List<string> validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(Nomelote?.Trim()) ||
                string.IsNullOrWhiteSpace(Nomelote))
            {
                erros.Add("Nome do lote é obrigatório!");
            }

            var somaProdutos = Produtos.Sum(p => p.Preco);

            if (somaProdutos - preco > somaProdutos * DescontoMaximo)
            {
                erros.Add("Desconto máximo excedido!");
            }
            return erros;
        }
    }
}
