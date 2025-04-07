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
    public partial class FormClientes : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public FormClientes()
        {
            InitializeComponent();
        }
        private void Mostrar()
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.nit = txtNit.Text;
            cliente.nombre = txtNombre.Text;
            cliente.direccion = txtDireccion.Text;

            clientes.Add(cliente);

            ClienteArchivo clienteArchivo = new ClienteArchivo();

            clienteArchivo.Guardar("../../Clientes.json", clientes);

            txtNit.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            FormVehiculos formVehiculos = new FormVehiculos();
            formVehiculos.Show();
            this.Close();
        }

        private void btnAlquiler_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
