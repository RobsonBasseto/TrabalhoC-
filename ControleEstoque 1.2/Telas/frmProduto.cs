using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class frmProduto : ControleEstoque.frmBase
    {
        public frmProduto()
        {
            InitializeComponent();
            CarregarGridProduto();
            DesabilitarText();
        }
        private void HabilitarText()
        {
            txtUnidade.Enabled = true;
            txtNomeProduto.Enabled = true;
            txtValorVenda.Enabled = true;
            txtCusto.Enabled = true;    
            txtQuantidade.Enabled = true;
        }
        private void DesabilitarText()
        {
            txtUnidade.Enabled = false;
            txtNomeProduto.Enabled = false;
            txtValorVenda.Enabled = false;
            txtCusto.Enabled = false;
            txtQuantidade.Enabled = false;
        }
     
        private void CarregarGridProduto()
        {
            Model get = new Model();
            List<DtoProduto2> lista = get.ListProdutos();
            this.ProdutoView.DataSource = lista;
            this.ProdutoView.Refresh();
        }

        private void ProdutoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)ProdutoView.CurrentRow.Cells[0].Value;
            Model get = new Model();
            DtoProduto2 pr = get.GetProdutoID(ID);
            txtProtutoid.Text = pr.idproduto.ToString();
            txtNomeProduto.Text = pr.nomeproduto;
            HabilitarText();
            txtNomeProduto.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtUnidade.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtValorVenda.Text = string.Empty;
            txtCusto.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            HabilitarText();
            txtNomeProduto.Focus();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                DtoProduto u = new DtoProduto();
                u.unidade = txtUnidade.Text;
                u.nomeproduto = txtNomeProduto.Text;
                u.valorvenda = decimal.Parse(txtValorVenda.Text);
                u.valorcusto = decimal.Parse(txtCusto.Text);
                u.quantidade = decimal.Parse(txtQuantidade.Text);

                if (txtProtutoid.Text != string.Empty)
                {
                    u.idproduto = int.Parse(txtProtutoid.Text);
                    set.AlterarProduto(u);
                }
                else
                {
                    set.SetProduto(u);
                }

                DesabilitarText();
                CarregarGridProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarText();
            txtProtutoid.Focus();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtProtutoid.Text != String.Empty)
            {
                Model del = new Model();
                del.DeletarUsuario(int.Parse(txtProtutoid.Text));
                DesabilitarText();
                CarregarGridProduto();
            }
        }
    }
}
