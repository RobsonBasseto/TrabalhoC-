using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.Classes
{
    [Table("entradaproduto", Schema = "public")]
    public class DtoEntrada
    {
        [Key]
        public int identrada { get; set; }
        public int idproduto { get; set; }
        public decimal qtdproduto { get; set; }
        public decimal vlcustoproduto { get; set; }
        public decimal vltotalproduto { get; set; }
        public DateTime? dtcompra { get; set; }
    }
}
