using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesModelo
{
    public class Postulante
    {
        public int IDPOSTULANTE { get; set; }
        public string ESTADOPOSTULACION { get; set; }
        public DateTime FECHAPOSTULACION { get; set; }
        public int IDPROGRAMAESTUDIOFK { get; set; }
        public int IDUSUARIOFK { get; set; }
    }
}
