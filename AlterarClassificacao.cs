using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace MeuProjeto
{
    public partial class AlterarClassificacao : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarClassificacao()
        {
            InitializeComponent();
            CarregarClassificacoes();
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

        // Método para Carregar Classificações no DataGridView
        private void CarregarClassificacoes()
        {
            string query = "SELECT id_classificacaoProduto, sigla_classificacaoProduto, nome_classificacaoProduto FROM classificacaoproduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewClassificacoes1.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Método para Preencher os Campos ao Inserir o ID da Classificação
        private void PreencherCamposClassificacao(int idClassificacaoProduto)
        {
            string query = "SELECT sigla_classificacaoProduto, nome_classificacaoProduto FROM classificacaoproduto WHERE id_classificacaoProduto = @idClassificacaoProduto";

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
                                    txtSiglaClassificacaoProduto1.Text = reader["sigla_classificacaoProduto"].ToString();
                                    txtNomeClassificacaoProduto1.Text = reader["nome_classificacaoProduto"].ToString();
                                }
                                else
                                {
                                    txtSiglaClassificacaoProduto1.Clear();
                                    txtNomeClassificacaoProduto1.Clear();
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
            if (int.TryParse(txtIdClassificacaoProduto1.Text, out int idClassificacaoProduto))
            {
                PreencherCamposClassificacao(idClassificacaoProduto);
            }
            else
            {
                txtSiglaClassificacaoProduto1.Clear();
                txtNomeClassificacaoProduto1.Clear();
            }
        }

        // Método para Atualizar a Classificação no Banco de Dados
        private void AtualizarClassificacaoProduto(int idClassificacaoProduto, string siglaClassificacaoProduto, string nomeClassificacaoProduto)
        {
            string query = "UPDATE classificacaoproduto SET sigla_classificacaoProduto = @siglaClassificacaoProduto, nome_classificacaoProduto = @nome_classificacaoProduto " +
                           "WHERE id_classificacaoProduto = @idClassificacaoProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idClassificacaoProduto", idClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@siglaClassificacaoProduto", siglaClassificacaoProduto);
                        cmd.Parameters.AddWithValue("@nome_classificacaoProduto", nomeClassificacaoProduto);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a atualização
                            if (result > 0)
                            {
                                MessageBox.Show("Classificação atualizada com sucesso!");
                                CarregarClassificacoes(); // Recarregar após a atualização

                                // Limpar os campos após a atualização
                                txtIdClassificacaoProduto1.Clear();
                                txtSiglaClassificacaoProduto1.Clear();
                                txtNomeClassificacaoProduto1.Clear();
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



        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AlterarClassificacao_Load(object sender, EventArgs e)
        {
            CarregarClassificacoes(); // Carregar classificações ao abrir o formulário
        }

        
        

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Verificar se todos os campos estão preenchidos
                    if (string.IsNullOrEmpty(txtIdClassificacaoProduto1.Text) ||
                        string.IsNullOrEmpty(txtSiglaClassificacaoProduto1.Text) ||
                        string.IsNullOrEmpty(txtNomeClassificacaoProduto1.Text))
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    // Tentar converter o ID da classificação para inteiro
                    if (!int.TryParse(txtIdClassificacaoProduto1.Text, out int idClassificacaoProduto))
                    {
                        MessageBox.Show("ID da classificação inválido.");
                        return;
                    }

                    // Capturar os valores dos campos
                    string siglaClassificacaoProduto = txtSiglaClassificacaoProduto1.Text;
                    string nomeClassificacaoProduto = txtNomeClassificacaoProduto1.Text;

                    // Chamar o método de atualização
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewClassificacoes1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0) // Verifica se a linha é válida
                {
                    DataGridViewRow row = dataGridViewClassificacoes1.Rows[e.RowIndex];
                    int idClassificacaoProduto = Convert.ToInt32(row.Cells["id_classificacaoProduto"].Value);
                    txtIdClassificacaoProduto1.Text = idClassificacaoProduto.ToString(); // Preencher o TextBox
                    PreencherCamposClassificacao(idClassificacaoProduto);
                }
            }
        }
    }
}
