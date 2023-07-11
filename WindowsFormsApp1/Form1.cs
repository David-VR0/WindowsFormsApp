using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using WindowsFormsApp1.Dato;
using WindowsFormsApp1.Modelo;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private DataTable dt;
        VehiculoAdmin admin = new VehiculoAdmin();
        public Form1()
        {
            InitializeComponent();
            
            Consultar();
        }

        private void inicializar()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Marca");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Color");
            dataGridView1.DataSource = dt;


        }

        private void Consultar()
        {
            inicializar();
            List<vehiculo> lista = admin.Consultar();
            foreach(var item in lista)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Marca"] = item.marca;
                row["Precio"] = item.precio;
                row["Color"] = item.color;
                dt.Rows.Add(row);
            }
        }

        private void Guardar()
        {
            vehiculo modelo = new vehiculo()
            {
                marca = textBox2.Text,
                precio = int.Parse(textBox3.Text),
                color = textBox4.Text
            };
            admin.Guardar(modelo);
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Consultar();
            Limpiar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
