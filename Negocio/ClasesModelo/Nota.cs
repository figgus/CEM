using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesModelo
{
    public class Nota
    {
        public int idNotas { get; set; }
        public float calificacion { get; set; }
        public string profesor { get; set; }
        public int idPostulanteFK { get; set; }
        public int idPogramaFK{ get; set; }
        public DateTime fecha { get; set; }
        public int numeral { get; set; }
    }
}
