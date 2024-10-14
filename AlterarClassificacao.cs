using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class AlterarClassificacao : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarClassificacao()
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

        // Método para Preencher os Campos ao Inserir o ID da Classificação
        private void PreencherCamposClassificacao(int idClassificacaoProduto)
        {
            string query = "SELECT sigla_classificacaoProduto, nome_classificacaoProduto FROM classificacao_produto WHERE id_classificacaoProduto = @idClassificacaoProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idClassificacaoProduto", idClassificacaoProduto);

                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtSiglaClassificacaoProduto.Text = reader["sigla_classificacaoProduto"].ToString();
                                    txtNomeClassificacaoProduto.Text = reader["nome_classificacaoProduto"].ToString();
                                }
                                else
                                {
                                    txtSiglaClassificacaoProduto.Clear();
                                    txtNomeClassificacaoProduto.Clear();
                                    MessageBox.Show("Classificação não encontrada.");
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao buscar dados da classificação: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do TextBox txtIdClassificacaoProduto para Autocomplete
        private void txtIdClassificacaoProduto_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdClassificacaoProduto.Text, out int idClassificacaoProduto))
            {
                PreencherCamposClassificacao(idClassificacaoProduto);
            }
            else
            {
                txtSiglaClassificacaoProduto.Clear();
                txtNomeClassificacaoProduto.Clear();
            }
        }

        // Método para Atualizar a Classificação no Banco de Dados
        private void AtualizarClassificacaoProduto(int idClassificacaoProduto, string siglaClassificacaoProduto, string nomeClassificacaoProduto)
        {
            string query = "UPDATE classificacaoproduto SET sigla_classificacaoProduto = @siglaClassificacaoProduto, nome_classificacaoProduto = @nomeClassificacaoProduto " +
                           "WHERE id_classificacaoProduto = @idClassificacaoProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idClassificacaoProduto", idClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@siglaClassificacaoProduto", siglaClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@nomeClassificacaoProduto", nomeClassificacaoProduto);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a atualização
                            if (result > 0)
                            {
                                MessageBox.Show("Classificação atualizada com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID da classificação.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar classificação: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Atualizar a Classificação
    private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    if (string.IsNullOrEmpty(txtIdClassificacaoProduto.Text) ||
                        string.IsNullOrEmpty(txtSiglaClassificacaoProduto.Text) ||
                        string.IsNullOrEmpty(txtNomeClassificacaoProduto.Text))
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    int idClassificacaoProduto = Convert.ToInt32(txtIdClassificacaoProduto.Text);
                    string siglaClassificacaoProduto = txtSiglaClassificacaoProduto.Text;
                    string nomeClassificacaoProduto = txtNomeClassificacaoProduto.Text;

                    AtualizarClassificacaoProduto(idClassificacaoProduto, siglaClassificacaoProduto, nomeClassificacaoProduto);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Erro de formato nos dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
        }
        }
    }
}
