using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_2
{
    internal class Alquiler
    {
        public string nit { get; set; }
        public string placa { get; set; }
        public DateTime fecha_alquiler { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public int kilometros_recorridos { get; set; }
        public decimal costo_alquiler { get; set; }
    }
}
