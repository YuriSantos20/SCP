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
    public partial class ControleCadastro : Form
    {
        public ControleCadastro()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            ConsultarProduto form2 = new ConsultarProduto();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarClassificacao form2 = new ConsultarClassificacao();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarFornecedores cadastroclassificacao = new ConsultarFornecedores();
            cadastroclassificacao.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarClientes cadastroclassificacao = new ConsultarClientes();
            cadastroclassificacao.Show();
        }
    }
}
