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
    public partial class Form1 : Form
    {
        List<Departamentos> departamentos = new List<Departamentos>();
        string archivo1 = "Departamentos.txt";
        List<Temperatura> temperaturas = new List<Temperatura>();
        string archivo2 = "Mediciones.txt";
        List<Mediciones> mediciones = new List<Mediciones>();
        string archivo3 = "Departamento Medición.txt";
        public Form1()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = false;

            button2.Visible = true;
        }
        public void leer_datos()// función para leer los datos de todas las clases
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
       public void guardar_datos()
        {
            FileStream stream = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < temperaturas.Count; i++)
            {
                writer.WriteLine(temperaturas[i].Numero_Identificación);
                writer.WriteLine(temperaturas[i].Medición);
                writer.WriteLine(temperaturas[i].Fecha1);
            }
            writer.Close();
            FileStream stream1 = new FileStream(archivo3, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer1 = new StreamWriter(stream1);

            for (int i = 0; i < mediciones.Count; i++)
            {
                writer1.WriteLine(mediciones[i].Nombre);
                writer1.WriteLine(mediciones[i].Mediciones1);
                //writer1.WriteLine(mediciones[i].Fecha1);
            }
            writer1.Close();


        }
        public void mostrar_departamento()
        {       // Función para mostrar los dpis de los propietarios ingresados
            comboBox1.Text = null;
            comboBox1.DisplayMember = "Departamento";
            comboBox1.ValueMember = "Departamento";
            comboBox1.DataSource = departamentos;
            comboBox1.Refresh();
        }
        public void limpiar_ingreso()
        {
           
            comboBox1.Text = null;
            textBox1.Text = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Temperatura asignartemp = new Temperatura();
            Departamentos departamentotemp = new Departamentos();
            Mediciones asignadotemp = new Mediciones();
           
            asignartemp.Medición = textBox1.Text;
            asignadotemp.Mediciones1 = textBox1.Text;
            asignartemp.Fecha1=Convert.ToDateTime(dateTimePicker1.Text);
            string tempnumero_identificación = " ";
            string tempnombre = " ";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = departamentos;
            tempnumero_identificación = comboBox1.SelectedValue.ToString();
            comboBox1.ValueMember = "Departamento";
            comboBox1.DataSource = departamentos;
            tempnombre = comboBox1.SelectedValue.ToString();
            asignadotemp.Nombre = tempnombre;
            // Se concatena las dos variables de clase dueño para mostrarlo

            asignartemp.Numero_Identificación = tempnumero_identificación;
            temperaturas.Add(asignartemp);
            mediciones.Add(asignadotemp);
            guardar_datos();
            limpiar_ingreso();
            MessageBox.Show("Ingreso correcta");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leer_datos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrar_departamento(); // Se muestran los carnets ingresados en el combo
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox1.Enabled = true;

            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal V = new Principal();
            V.Show();
            this.Hide();
        }
    }
}
