using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
    public class Model
    {
        public void SetUsuario(DtoUsuario u)
        {
            Context db = new Context();
            db.usuario.Add(u);
            db.SaveChanges();
        }

        public void AlterarUsuario(DtoUsuario u)
        {
            Context db = new Context();
            DtoUsuario usuario = db.usuario.FirstOrDefault(p => p.id == u.id);
            usuario.nome = u.nome;
            usuario.login = u.login;
            usuario.senha = u.senha;
            db.SaveChanges();
        }
        public void DeletarUsuario(int id)
        {
            Context db = new Context();

            DtoUsuario u = db.usuario.FirstOrDefault(p =>p.id == id);
            db.usuario.Remove(u);
            db.SaveChanges();
        }
      

        public List<DtoUsuario2> ListUsuarios()
        {
            Context db = new Context();

            List<DtoUsuario2> result = (from u in db.usuario
                                         select new DtoUsuario2
                                         {
                                             id = u.id,
                                             nome = u.nome
                                         }).ToList();

            return new List<DtoUsuario2>(result);
        }

        public DtoUsuario2 GetUsuarioID(int id)
        {
            Context db = new Context();

            var result = (from a in db.usuario
                          where a.id == id
                          select new DtoUsuario2
                          {
                              id = a.id,
                              nome = a.nome
                          }
                          ).FirstOrDefault();

            var result1 = db.usuario.Where(p => p.id == id).FirstOrDefault();
            return result;
        }

        //produto

        public void SetProduto(DtoProduto pd)
        {
            Context db = new Context();
            db.produto.Add(pd);
            db.SaveChanges();
        }
        public void AlterarProduto(DtoProduto pd)
        {
            Context db = new Context();
            DtoProduto produto = db.produto.FirstOrDefault(p => p.IdProduto == pd.IdProduto);
            produto.IdProduto = pd.IdProduto;
            produto.Unidade = pd.Unidade;
            produto.NomeProduto = pd.NomeProduto;
            produto.ValorVenda = pd.ValorVenda;
            produto.ValorCusto = pd.ValorCusto;
            produto.Quantidade = pd.Quantidade;
            db.SaveChanges();
        }

        public void DeletarProduto(int id)
        {
            Context db = new Context();

            DtoProduto pd = db.produto.FirstOrDefault(p => p.IdProduto == id);
            db.produto.Remove(pd);
            db.SaveChanges();
        }

        public List<DtoProduto2> ListProdutos()
        {
            Context db = new Context();

            List<DtoProduto2> result = (from pd in db.produto
                                        select new DtoProduto2
                                        {
                                            IdProduto = pd.IdProduto,
                                            NomeProduto = pd.NomeProduto
                                        }).ToList();

            return new List<DtoProduto2>(result);
        }
        public DtoProduto2 GetProdutoID(int id)
        {
            Context db = new Context();

            var result = (from pd in db.produto
                          where pd.IdProduto == id
                          select new DtoProduto2
                          {
                              IdProduto = pd.IdProduto,
                              NomeProduto = pd.NomeProduto
                          }
                          ).FirstOrDefault();

            var result1 = db.produto.Where(p => p.IdProduto == id).FirstOrDefault();
            return result;
        }
    }
}
