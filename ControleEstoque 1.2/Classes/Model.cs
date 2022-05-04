using ControleEstoque.Classes;
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
            DtoProduto produto = db.produto.FirstOrDefault(p => p.idproduto == pd.idproduto);
            produto.idproduto = pd.idproduto;
            produto.unidade = pd.unidade;
            produto.nomeproduto = pd.nomeproduto;
            produto.valorvenda = pd.valorvenda;
            produto.valorcusto = pd.valorcusto;
            produto.quantidade = pd.quantidade;
            db.SaveChanges();
        }

        public void DeletarProduto(int idproduto)
        {
            Context db = new Context();

            DtoProduto pd = db.produto.FirstOrDefault(p => p.idproduto == idproduto);
            db.produto.Remove(pd);
            db.SaveChanges();
        }

        public List<DtoProduto2> ListProdutos()
        {
            Context db = new Context();

            List<DtoProduto2> result = (from pd in db.produto
                                        select new DtoProduto2
                                        {
                                            idproduto = pd.idproduto,
                                            nomeproduto = pd.nomeproduto,
                                            quantidade = pd.quantidade
                                        }).ToList();

            return new List<DtoProduto2>(result);
        }

        public List<DtoProduto2> ListProdutosNome(string text)
        {
            Context db = new Context();

            List<DtoProduto2> result = (from pd in db.produto
                                        where pd.nomeproduto.Contains(text)
                                        select new DtoProduto2
                                        {
                                            idproduto = pd.idproduto,
                                            nomeproduto = pd.nomeproduto,
                                            quantidade = pd.quantidade
                                        }).ToList();

            return result;
        }
        public DtoProduto GetProdutoid(int idproduto)
        {
            Context db = new Context();
            DtoProduto e = db.produto.FirstOrDefault(p => p.idproduto == idproduto);
            return e;
        }

        public DtoProduto2 GetProdutoID(int id)
        {
            Context db = new Context();

            var result = (from pd in db.produto
                          where pd.idproduto == id
                          select new DtoProduto2
                          {
                              idproduto = pd.idproduto,
                              nomeproduto = pd.nomeproduto,
                              quantidade = pd.quantidade
                          }
                          ).FirstOrDefault();

            var result1 = db.produto.Where(p => p.idproduto == id).FirstOrDefault();
            return result;
        }
        public void SetSaida(DtoSaida pd)
        {
            Context db = new Context();

            db.saida.Add(pd);
            db.SaveChanges();
        }
        public void SalvarSaida(DtoProduto pd)
        {
            Context db = new Context();
            var a = db.produto.FirstOrDefault(p => p.idproduto == pd.idproduto);

            a.quantidade = a.quantidade - pd.quantidade;

            db.SaveChanges();
        }
        public void SetEntrada(DtoEntrada pd)
        {
            Context db = new Context();
            
            db.entrada.Add(pd);
            db.SaveChanges();
        }
        public void SalvarEntrada(DtoProduto pd)
        {
            Context db = new Context();
            var a = db.produto.FirstOrDefault(p => p.idproduto == pd.idproduto);

            a.quantidade = a.quantidade + pd.quantidade;

            db.SaveChanges();
        }
    }
}
