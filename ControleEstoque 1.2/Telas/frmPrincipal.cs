using ControleEstoque.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            frmProduto f = new frmProduto();
            f.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmUsuario f = new frmUsuario();
            f.Show();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frmEntrada f = new frmEntrada();
            f.Show();
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            frmSaida f = new frmSaida();
            f.Show();
        }
    }
}
