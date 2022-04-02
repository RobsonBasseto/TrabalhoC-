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
            txtProtutoid.Text = pr.IdProduto.ToString();
            txtNomeProduto.Text = pr.NomeProduto;
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
                u.Unidade = txtUnidade.Text;
                u.NomeProduto = txtNomeProduto.Text;
                u.ValorVenda = decimal.Parse(txtValorVenda.Text);
                u.ValorCusto = decimal.Parse(txtCusto.Text);
                u.Quantidade = decimal.Parse(txtQuantidade.Text);

                if (txtProtutoid.Text != string.Empty)
                {
                    u.IdProduto = int.Parse(txtProtutoid.Text);
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
                del.DeletarProduto(int.Parse(txtProtutoid.Text));
                DesabilitarText();
                CarregarGridProduto();
            }
        }
    }
}
