using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ControleEstoque
{
    public partial class frmUsuario : ControleEstoque.frmBase
    {
        public frmUsuario()
        {
            InitializeComponent();
            CarregarGrid();
            DesabilitarText();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            HabilitarText();
            txtNome.Focus();
        }
        private void HabilitarText()
        {
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
        }
        private void DesabilitarText()
        {
            txtNome.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try{
                Model set = new Model();
                DtoUsuario u = new DtoUsuario();
                u.nome = txtNome.Text;
                u.login = txtLogin.Text;
                u.senha = txtSenha.Text;

                if (txtId.Text != string.Empty)
                {
                    u.id = int.Parse(txtId.Text);
                    set.AlterarUsuario(u);
                }
                else
                {
                    set.SetUsuario(u);
                }
                
                DesabilitarText();
                CarregarGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        private void CarregarGrid()
        {
            Model get = new Model();
            List<DtoUsuario2> lista = get.ListUsuarios();
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Refresh();
        }
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            Model get = new Model();
            DtoUsuario2 d = get.GetUsuarioID(ID);
            txtId.Text = d.id.ToString();
            txtNome.Text = d.nome;
            HabilitarText();
            txtNome.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarText();
            txtId.Focus();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != String.Empty)
            {
                Model del = new Model();
                del.DeletarUsuario(int.Parse(txtId.Text));
                DesabilitarText();
                CarregarGrid();
            }
        }
    }
}
