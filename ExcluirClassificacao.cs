using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ExcluirClassificacao : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ExcluirClassificacao()
        {
            InitializeComponent();
        }

        // Método para Conectar ao Banco de Dados
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

        // Método para Excluir Classificação no Banco de Dados
        private void ExcluirClassificacaoProduto(int idClassificacaoProduto)
        {
            string query = "DELETE FROM classificacaoproduto WHERE id_classificacaoProduto = @idClassificacaoProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Definir o parâmetro
                        cmd.Parameters.AddWithValue("@idClassificacaoProduto", idClassificacaoProduto);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a exclusão
                            if (result > 0)
                            {
                                MessageBox.Show("Classificação excluída com sucesso!");
                                // Limpar o campo após a exclusão
                                txtIdClassificacaoProduto.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído. Verifique o ID da classificação.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir classificação: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Excluir Classificação
       
        

        // Evento para quando o campo ID da Classificação mudar
        private void txtIdClassificacaoProduto_TextChanged(object sender, EventArgs e)
        {
            // Aqui você pode colocar lógica extra, se necessário
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdClassificacaoProduto.Text))
                    {
                        MessageBox.Show("Por favor, insira o ID da classificação para exclusão.");
                        return;
                    }

                    int idClassificacaoProduto = Convert.ToInt32(txtIdClassificacaoProduto.Text);
                    ExcluirClassificacaoProduto(idClassificacaoProduto);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Erro de formato no ID da classificação: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
