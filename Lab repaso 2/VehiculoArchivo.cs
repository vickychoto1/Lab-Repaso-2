using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_2
{
    internal class VehiculoArchivo
    {
        public void Guardar(string archivo, List<Vehiculo> vehiculos)
        {
            string json = JsonConvert.SerializeObject(vehiculos);
            System.IO.File.WriteAllText(archivo, json);
        }

        public List<Vehiculo> Leer(string archivo)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            lista = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
            return lista;
        }
    }
    
}
