using ControleEstoque.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class frmEntrada : ControleEstoque.frmBase
    {
        public frmEntrada()
        {
            InitializeComponent();
            DesabilitarText();
        }

        private void txtProduto_Leave(object sender, EventArgs e)
        {
            Model get = new Model();
            DtoProduto produto = get.GetProdutoid(int.Parse(txtProduto.Text));
            txtNomeProduto.Text = produto.nomeproduto;
        }

        private void txtUnitario_Leave(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(txtQuantidade.Text) * decimal.Parse(txtUnitario.Text);
            txtTotal.Text = total.ToString();
        }

        private void bntConsulta_Click(object sender, EventArgs e)
        {
            frmConsulta c = new frmConsulta();
            c.ShowDialog();
            if (c.idProduto != 0)
            {
                txtProduto.Text = c.idProduto.ToString();
                txtProduto.Focus();
            }
        }

        private void HabilitarText()
        {

            txtProduto.Enabled = true;
            txtNomeProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtUnitario.Enabled = true;
            txtTotal.Enabled = true;

        }
        private void DesabilitarText()
        {
            txtID.Enabled = false;
            txtProduto.Enabled = false;
            txtNomeProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtUnitario.Enabled = false;
            txtTotal.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtID.Text = String.Empty;
            txtProduto.Text = String.Empty;
            txtNomeProduto.Text = String.Empty;
            txtQuantidade.Text = String.Empty;
            txtUnitario.Text = String.Empty;
            txtTotal.Text = String.Empty;
            HabilitarText();
            txtProduto.Focus();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Model set = new Model();
                DtoEntrada u = new DtoEntrada();
                u.idproduto = int.Parse(txtProduto.Text);
                u.qtdproduto = Decimal.Parse(txtQuantidade.Text);
                u.vltotalproduto = Decimal.Parse(txtTotal.Text);
                u.vlcustoproduto = Decimal.Parse(txtUnitario.Text);
                u.dtcompra = DateTime.Now;

                set.SetEntrada(u);
                                
                DtoProduto ua = new DtoProduto();
                ua.idproduto = int.Parse(txtProduto.Text);
                ua.valorvenda = decimal.Parse(txtTotal.Text);
                ua.quantidade = decimal.Parse(txtQuantidade.Text);
                ua.valorcusto = decimal.Parse(txtUnitario.Text);

                set.SalvarEntrada(ua);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
            
    }
}   
      

