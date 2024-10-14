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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncluirClientes cadastroclassificacao = new IncluirClientes();
            cadastroclassificacao.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarClientes cadastroclassificacao = new ConsultarClientes();
            cadastroclassificacao.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlterarClientes cadastroclassificacao = new AlterarClientes();
            cadastroclassificacao.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcluirCliente cadastroclassificacao = new ExcluirCliente();
            cadastroclassificacao.Show();
        }
    }
}
