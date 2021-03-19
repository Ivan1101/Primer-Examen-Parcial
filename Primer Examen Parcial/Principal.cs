using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_Examen_Parcial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 v1 = new Form1();
            v1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar v2 = new Mostrar();
            v2.Show();
            this.Hide();
        }
    }
}
