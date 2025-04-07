using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_2
{
    internal class AlquilerArchivo
    {
        public void Guardar(string archivo, List<Alquiler> alquilers)
        {
            string json = JsonConvert.SerializeObject(alquilers);
            System.IO.File.WriteAllText(archivo, json);

        }
        public List<Alquiler> Leer(string archivo)
        {
            List<Alquiler> lista = new List<Alquiler>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            lista = JsonConvert.DeserializeObject<List<Alquiler>>(json);
            return lista;
        }
    }
}
