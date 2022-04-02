using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
    public class Context:DbContext
    {
        public Context(): base("BD")
        {

        }

        public DbSet<DtoUsuario> usuario { get; set; }

        public DbSet<DtoProduto> produto { get; set; }
        
    }
}
