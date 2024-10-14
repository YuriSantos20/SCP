using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class IncluirClientes : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public IncluirClientes()
        {
            InitializeComponent();
        }

        // Método para Conectar ao Banco de Dados
        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Conexão bem-sucedida!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
            }

            return connection;
        }

        // Método para Inserir Cliente no Banco de Dados
        private void InserirCliente(string nome, string cpfCnpj, string logradouro, string numero, string complemento,
                                    string bairro, string cidade, string estado, string cep, string telefone, string email)
        {
            string query = "INSERT INTO cliente (nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email) " +
                           "VALUES (@nome, @cpfCnpj, @logradouro, @numero, @complemento, @bairro, @cidade, @estado, @cep, @telefone, @email)";

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Passando os parâmetros
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                    cmd.Parameters.AddWithValue("@logradouro", logradouro);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@complemento", complemento);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@email", email);

                    try
                    {
                        // Executa o comando
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cliente cadastrado com sucesso!");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao inserir cliente: " + ex.Message);
                    }
                }
            }
        }

        // Evento do Botão para Cadastrar Cliente
        
        

        private void cadastroClientes_Load(object sender, EventArgs e)
        {
            // Você pode colocar alguma lógica de inicialização aqui, se necessário
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Captura os valores dos TextBoxes
                string nome = txtNome.Text;
                string cpfCnpj = txtCpfCnpj.Text;
                string logradouro = txtLogradouro.Text;
                string numero = txtNumero.Text;
                string complemento = txtComplemento.Text;
                string bairro = txtBairro.Text;
                string cidade = txtCidade.Text;
                string estado = txtEstado.Text;
                string cep = txtCep.Text;
                string telefone = txtTelefone.Text;
                string email = txtEmail.Text;

                // Chama o método para inserir no banco de dados
                InserirCliente(nome, cpfCnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
