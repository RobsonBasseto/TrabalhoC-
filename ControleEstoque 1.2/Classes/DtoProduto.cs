using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque
{
    [Table("produto", Schema = "public")]
    public class DtoProduto
    {
        [Key]
        public int idproduto { get; set; }
        public string unidade { get; set; }
        public string nomeproduto { get; set; }
        public decimal? valorvenda { get; set; }
        public decimal? valorcusto { get; set; }
        public decimal? quantidade { get; set; }
        
    }
}
