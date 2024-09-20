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
    public partial class Classificacao : Form
    {
        public Classificacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncluirClassificacao form2 = new IncluirClassificacao();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlterarClassificacao form2 = new AlterarClassificacao();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcluirClassificacao form2 = new ExcluirClassificacao();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarClassificacao form2 = new ConsultarClassificacao();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
