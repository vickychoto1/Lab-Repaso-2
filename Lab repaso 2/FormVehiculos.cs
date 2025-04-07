using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_repaso_2
{
    public partial class FormVehiculos : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        public FormVehiculos()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = vehiculos;
            dataGridView1.Refresh();
        }
        private void btnAgregarVehi_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            vehiculo.placa = txtPlaca.Text;
            vehiculo.marca = txtMarca.Text;
            vehiculo.modelo = Convert.ToInt16(txtModelo.Text);
            vehiculo.color = txtColor.Text;
            vehiculo.precio_kilometro = Convert.ToDecimal(txtPrecio.Text);

            vehiculos.Add(vehiculo);

            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();

            vehiculoArchivo.Guardar("../../Vehiculos.json", vehiculos);

            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtColor.Clear();
            txtPrecio.Clear();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();
            this.Close();
        }

        private void btnAlquiler_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
