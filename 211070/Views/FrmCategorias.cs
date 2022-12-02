using System;
using System.Windows.Forms;
using _211070.Models;

namespace _211070.Views
{
    public partial class FrmCategorias : Form
    {
        Categoria ca;
        public FrmCategorias()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtId.Clear();
            txtCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            ca = new Categoria()
            {
                categoria = pesquisa
            };
            dgvCategorias.DataSource = ca.Consultar();
        }
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            ca = new Categoria()
            {
                categoria = txtCategoria.Text
            };
            ca.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void DgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.RowCount > 0)
            {
                txtId.Text = dgvCategorias.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCategorias.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;

            ca = new Categoria()
            {
                id = int.Parse(txtId.Text),
                categoria = txtCategoria.Text
            };
            ca.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;

            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ca = new Categoria()
                {
                    id = int.Parse(txtId.Text)
                };
                ca.Excluir();

                limpaControles();
                carregarGrid("");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
