using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trampo
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string AnoFabricacao { get; set; }
        public double Preco { get; set; }
        public List<int> UnidadesVendidas { get; set; }
        public string InformacaoExtra { get; set; }

        public Produto(string nome, int codigo, string anoFabricacao, double preco, List<int> unidadesVendidas, string informacaoExtra)
        {
            Nome = nome;
            Codigo = codigo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            UnidadesVendidas = unidadesVendidas;
            InformacaoExtra = informacaoExtra;
        }
    }
}
