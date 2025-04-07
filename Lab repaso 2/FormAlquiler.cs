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
    public partial class FormAlquiler : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquiler> alquilers = new List<Alquiler>();
        List<Reporte> reportes = new List<Reporte>();
        public FormAlquiler()
        {
            InitializeComponent();
        }
        private void FormAlquiler_Load(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();

            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");

            cmbNIT.DataSource = clientes;
            cmbNIT.DisplayMember = "nit";


            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");



            cmbPlaca.DisplayMember = "placa";
            cmbPlaca.DataSource = vehiculos;

            AlquilerArchivo alquilerArchivo = new AlquilerArchivo();
            List<Alquiler> alquilers = alquilerArchivo.Leer("../../Alquilers.json");
            int mayor = alquilers.Max(a => a.kilometros_recorridos);
            labelMayor.Visible = true;
            labelMayor.Text = mayor.ToString();
        }

        private void mostrar()
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");

            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");


            AlquilerArchivo alquilerArchivo = new AlquilerArchivo();
            alquilers = alquilerArchivo.Leer("../../Alquilers.json");

            foreach (var cliente in clientes)
            {
                foreach (var alquiler in alquilers)
                {
                    if (alquiler.nit.Trim() == cliente.nit.Trim())
                    {
                        foreach (var vehiculo in vehiculos)
                        {
                            if (alquiler.placa.Trim().ToLower() == vehiculo.placa.Trim().ToLower())
                            {

                                Reporte reporte = new Reporte
                                {
                                    nombre = cliente.nombre,
                                    placa = vehiculo.placa,
                                    marca = vehiculo.marca,
                                    modelo = vehiculo.modelo,
                                    color = vehiculo.color,
                                    fecha_devolucion = alquiler.fecha_devolucion,
                                    costo_alquiler = alquiler.costo_alquiler
                                };

                                reportes.Add(reporte);
                            }
                        }
                    }
                }
            }



            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            List<Cliente> clientes = clienteArchivo.Leer("../../Clientes.json");

            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            List<Vehiculo> vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");

            foreach (var cliente in clientes)
            {
                foreach (var vehiculo in vehiculos)
                {
                    if (cmbNIT.Text == cliente.nit)
                    {
                        Alquiler alquiler = new Alquiler();
                        alquiler.nit = cmbNIT.Text;
                        alquiler.placa = cmbPlaca.Text;
                        alquiler.fecha_alquiler = dateTimePickerAlquiler.Value.Date;
                        alquiler.fecha_devolucion = dateTimePickerDevolucion.Value.Date;
                        alquiler.kilometros_recorridos = Convert.ToInt16(numericUpDownKm.Value);
                        alquiler.costo_alquiler = vehiculo.precio_kilometro * alquiler.kilometros_recorridos;

                        alquilers.Add(alquiler);

                        AlquilerArchivo alquilerArchivo = new AlquilerArchivo();

                        alquilerArchivo.Guardar("../../Alquilers.json", alquilers);


                    }

                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
