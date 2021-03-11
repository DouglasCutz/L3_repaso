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

namespace L3_repaso
{
    public partial class Form1 : Form
    {
          List<Propietario> propietarios = new List<Propietario>();
          List<Propiedades> Propiedades = new List<Propiedades>();
        public Form1()
        {
            InitializeComponent();
        }
        void LimpiarPro()
        {
            tx_dpi.Text = "";
            tx_nombre.Text = "";
            tx_apellido.Text = "";
        }
        void MostrarPro()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propietarios;
            dataGridView1.Refresh();
        }
        void GuardarPro(String archivo, String dpi, String nom, String ape)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(stream);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            //writer.WriteLine(texto);

            writer.WriteLine(dpi);
            writer.WriteLine(nom);
            writer.WriteLine(ape);

            //Cerrar el archivo
            writer.Close();
        }
        void Cargar(string filename)
        {
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
               
                Propietario pro = new Propietario();
                pro.Dpi = reader.ReadLine();
                pro.Nombre = reader.ReadLine();
                pro.Apellido = reader.ReadLine();
                propietarios.Add(pro);
             }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void LimpiarPP()
        {
            tx_numcasa.Text = "";
            tx_dpidueño.Text = "";
            tx_cuota.Text = "";
        }
        void MostrarPP()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Propiedades;
            dataGridView2.Refresh();
        }
        void GuardarPP(String archivo, String numcasa, String dpi, String cuota)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(stream);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            //writer.WriteLine(texto);

            writer.WriteLine(numcasa);
            writer.WriteLine(dpi);
            writer.WriteLine(cuota);

            //Cerrar el archivo
            writer.Close();
        }
        void CargarPP(string filename)
        {
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {

                Propiedades pro = new Propiedades();
                pro.Numcasa = reader.ReadLine();
                pro.Dpi = reader.ReadLine();
                pro.Cuota = Convert.ToInt32( reader.ReadLine());
                Propiedades.Add(pro);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            Propietario propietario = new Propietario();

            if ((tx_dpi.Text != "") && (tx_nombre.Text != "") && (tx_apellido.Text != ""))
            {
                propietario.Dpi = tx_dpi.Text;
                propietario.Nombre = tx_nombre.Text;
                propietario.Apellido = tx_apellido.Text;
                propietarios.Add(propietario);
                MessageBox.Show(" Agregado correctamente");
                MostrarPro();
                GuardarPro("Propietarios.txt", tx_dpi.Text, tx_nombre.Text, tx_apellido.Text);
                LimpiarPro();

            }
            else
                MessageBox.Show(" Por favor llene todos los campos");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar("Propietarios.txt");
            MostrarPro();
            CargarPP("Propiedades.txt");
            MostrarPP();
        }

        private void propiedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //F_Propiedades f_Pro = new F_Propiedades();
            //f_Pro.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tx_dpi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tx_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tx_apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Propiedades propiedades = new Propiedades();

            propiedades.Numcasa = tx_numcasa.Text;
            propiedades.Dpi = tx_dpidueño.Text;
            propiedades.Cuota = Convert.ToInt32(tx_cuota.Text);

            bool bandera = false;
            for (int i = 0; i < propietarios.Count; i++)
            {
                if (propiedades.Dpi == propietarios[i].Dpi)
                    bandera = true;
            }
            if (bandera == true)
            {
                if((tx_numcasa.Text != "") && (tx_dpidueño.Text != "") && (tx_cuota.Text != ""))
                {
                    Propiedades.Add(propiedades);
                    MessageBox.Show(" Agregado correctamente");
                    MostrarPP();
                    GuardarPP("Propiedades.txt", tx_numcasa.Text, tx_dpidueño.Text, tx_cuota.Text);
                    LimpiarPP();
                }
                else
                    MessageBox.Show(" Por favor llene todos los campos");
            }
            else
                MessageBox.Show(" Por favor registre DPI del propietario primero");
        }
    }
}
