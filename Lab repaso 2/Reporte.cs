using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_2
{
    internal class Reporte
    {
        public string nombre { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public int modelo { get; set; }
        public string color { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public decimal costo_alquiler { get; set; }
    }
}
