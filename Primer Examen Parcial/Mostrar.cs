using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_Examen_Parcial
{
    public partial class Mostrar : Form
    {
        List<Departamentos> departamentos = new List<Departamentos>();
        string archivo1 = "Departamentos.txt";
        List<Temperatura> temperaturas = new List<Temperatura>();
        string archivo2 = "Mediciones.txt";
        List<Mediciones> mediciones = new List<Mediciones>();
        string archivo3 = "Departamento Medición.txt";
        public Mostrar()
        {
            InitializeComponent();
            label1.Visible = false;
        }
        public void leer_datos()
        {

            FileStream stream1 = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);
            while (reader1.Peek() > -1)
            {
                Departamentos tempmostrar = new Departamentos();
                tempmostrar.Codigo = reader1.ReadLine();
                tempmostrar.Departamento = reader1.ReadLine();
                departamentos.Add(tempmostrar);

            }
            reader1.Close();

            FileStream stream = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Temperatura tempmostrar = new Temperatura();
                tempmostrar.Numero_Identificación = reader.ReadLine();
                tempmostrar.Medición = reader.ReadLine();
                tempmostrar.Fecha1 = Convert.ToDateTime(reader.ReadLine());

                temperaturas.Add(tempmostrar);

            }
            reader.Close();
            FileStream stream2 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Mediciones tempmostrar = new Mediciones();
                tempmostrar.Nombre = reader2.ReadLine();
                tempmostrar.Mediciones1 = reader2.ReadLine();
                mediciones.Add(tempmostrar);

            }
            reader2.Close();
        }
        public void mostrar1() // función para mostrar los datos en el dataGridView
        {
            dataGridView1.Text = null;
            dataGridView1.DataSource = mediciones;
            dataGridView1.Refresh();
        }
        private void Mostrar_Load(object sender, EventArgs e)
        {
            leer_datos();
            mostrar1();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal V = new Principal();
            V.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mediciones= mediciones.OrderByDescending(cuota => cuota.Mediciones1).ToList();
            mostrar1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Visible = true;
            Mediciones mayor = mediciones.OrderByDescending(al => al.Mediciones1).First();
            label1.Text = mayor.Mediciones1;
        }
    }
}
