using MeuProjeto;
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
    public partial class CadastroProdutos : Form
    {
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";
        public CadastroProdutos()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("Erro: " + ex.Message);
            }

            return connection;
        }

        // Método para Inserir Produto no Banco de Dados
        private void InserirProduto(string nome, double preco, int quantidade)
        {
            string query = "INSERT INTO produto (nome, preco, quantidade) VALUES (@nome, @preco, @quantidade)";

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao inserir produto: " + ex.Message);
                    }
                }
            }
        }

        

private void button3_Click(object sender, EventArgs e)
        {
            ExcluirProduto form2 = new ExcluirProduto();
            form2.Show();
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            incluirProdutos form2 = new incluirProdutos();
            form2.Show();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            AlterarProdutos form2 = new AlterarProdutos();
            form2.Show();
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            ConsultarProduto form2 = new ConsultarProduto();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {

        }
    }
}
