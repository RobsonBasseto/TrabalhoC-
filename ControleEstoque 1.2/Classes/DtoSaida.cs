using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ControleEstoque.Classes
{
    [Table("saidaproduto", Schema = "public")]
    public class DtoSaida
    {
        [Key]
        public int idsaida { get; set; }
        public int idproduto { get; set; }
        public decimal qtdproduto { get; set; }
        public decimal vlcustoproduto { get; set; }
        public decimal vltotalproduto { get; set; }
        public DateTime? dtcompra { get; set; }
    }
}
