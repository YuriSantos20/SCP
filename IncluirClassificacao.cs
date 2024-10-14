using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class IncluirClassificacao : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public IncluirClassificacao()
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

        // Método para Incluir Classificação no Banco de Dados
        private void IncluirClassificacaoProduto(int idClassificacaoProduto, string siglaClassificacaoProduto, string nomeClassificacaoProduto)
        {
            string query = "INSERT INTO classificacaoproduto (id_classificacaoProduto, sigla_classificacaoProduto, nome_classificacaoProduto) " +
                           "VALUES (@idClassificacaoProduto, @siglaClassificacaoProduto, @nomeClassificacaoProduto)";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Definir os parâmetros da consulta
                        cmd.Parameters.AddWithValue("@idClassificacaoProduto", idClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@siglaClassificacaoProduto", siglaClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@nomeClassificacaoProduto", nomeClassificacaoProduto);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a inclusão
                            if (result > 0)
                            {
                                MessageBox.Show("Classificação incluída com sucesso!");
                                // Limpar os campos após a inclusão
                                txtIdClassificacaoProduto.Clear();
                                txtSiglaClassificacaoProduto.Clear();
                                txtNomeClassificacaoProduto.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi inserido.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao incluir classificação: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Incluir Classificação
       
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se todos os campos foram preenchidos
                if (string.IsNullOrEmpty(txtIdClassificacaoProduto.Text) ||
                    string.IsNullOrEmpty(txtSiglaClassificacaoProduto.Text) ||
                    string.IsNullOrEmpty(txtNomeClassificacaoProduto.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }

                // Capturar os valores dos TextBoxes
                string siglaClassificacaoProduto = txtSiglaClassificacaoProduto.Text;
                string nomeClassificacaoProduto = txtNomeClassificacaoProduto.Text;

                // Chamar o método para incluir no banco de dados
                IncluirClassificacaoProduto(idClassificacaoProduto, siglaClassificacaoProduto, nomeClassificacaoProduto);
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

        private void txtIdClassificacaoProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
