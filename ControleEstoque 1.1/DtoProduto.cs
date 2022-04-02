using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
    [Table("produto", Schema = "public")]
    public class DtoProduto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Unidade { get; set; }
        public string NomeProduto { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal? Quantidade { get; set; }
        
    }
}
