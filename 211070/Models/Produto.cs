using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace _211070.Models
{
    internal class Produto
    {
		public int Id { get; set; }
        public string descricao { get; set; }
		
        public DataTable Consultar()
        {
            try
            {
                Banco.Comando = new MySqlCommand("SELECT p.*, m.marca, c.categoria FROM " +
                                                 "Produtos p inner join Marcas m on (m.id = p.idMarca)" +
                                                 "inner join Categorias c on (c.id = p.idCategoria) " +
                                                 "where p.descricao like @descricao order by p.descricao", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void atualizaEstoque(double qtde)
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand(
                "Update produtos set estoque = estoque - @qtde where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@id", Id);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
