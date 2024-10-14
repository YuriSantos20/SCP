using MeuProjeto;
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
    public partial class Fornecedor : Form
    {
        public Fornecedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncluirFornecedor cadastroclassificacao = new IncluirFornecedor();
            cadastroclassificacao.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlterarFornecedores cadastroclassificacao = new AlterarFornecedores();
            cadastroclassificacao.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcluirFornecedores cadastroclassificacao = new ExcluirFornecedores();
            cadastroclassificacao.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarFornecedores cadastroclassificacao = new ConsultarFornecedores();
            cadastroclassificacao.Show();
        }
    }
}
