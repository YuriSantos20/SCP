using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaComercio1
{
    public partial class ContaReceber : Form
    {
        private string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        
        public ContaReceber()
        {
            InitializeComponent();
            CarregarContasReceber(); // Chama o método ao inicializar a janela
        }
        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;
            }
        }
        
        private void CarregarContasReceber()
        {
            string query = @"
        SELECT 
            cr.id_conta_receber, 
            cr.descricao, 
            c.nome AS nome_cliente, 
            cr.data_lancamento, 
            cr.data_vencimento, 
            cr.valor, 
            cr.recebido
        FROM conta_receber cr
        JOIN cliente c ON cr.id_cliente = c.id_cliente"; // Faz o JOIN entre conta_receber e cliente

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Exibe os dados no DataGridView
                            dataGridViewContasReceber.DataSource = dataTable;

                            // Configuração dos cabeçalhos das colunas
                            dataGridViewContasReceber.Columns["id_conta_receber"].HeaderText = "ID Conta Receber";
                            dataGridViewContasReceber.Columns["descricao"].HeaderText = "Descrição";
                            dataGridViewContasReceber.Columns["nome_cliente"].HeaderText = "Nome do Cliente"; // Agora exibe o nome do cliente
                            dataGridViewContasReceber.Columns["data_lancamento"].HeaderText = "Data Lançamento";
                            dataGridViewContasReceber.Columns["data_vencimento"].HeaderText = "Data Vencimento";
                            dataGridViewContasReceber.Columns["valor"].HeaderText = "Valor";
                            dataGridViewContasReceber.Columns["recebido"].HeaderText = "Recebido";

                            // Ajusta o tamanho das colunas, se necessário
                            dataGridViewContasReceber.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar contas a receber: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
