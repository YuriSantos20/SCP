using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ExcluirProduto : Form
    {
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ExcluirProduto()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();  // Tentar abrir a conexão
                return connection;  // Retorna a conexão se estiver aberta
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;  // Retorna null se falhar ao abrir
            }
        }

        // Método para Excluir Produto no Banco de Dados
        private void ExcluirProdutodoBanco(int idProduto)
        {
            string query = "DELETE FROM produto WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a exclusão
                            if (result > 0)
                            {
                                MessageBox.Show("Produto excluído com sucesso!");
                                txtIdProduto.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído. Verifique o ID do produto.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Excluir Produto
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProduto.Text))
                {
                    MessageBox.Show("Por favor, insira o ID do produto para exclusão.");
                    return;
                }

                int idProduto = Convert.ToInt32(txtIdProduto.Text);
                ExcluirProdutodoBanco(idProduto);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro de formato no ID do produto: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
