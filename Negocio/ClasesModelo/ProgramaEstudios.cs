using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProgramaEstudios
    {
        public int IDPROGRAMAESTUDIO { get; set; }
        public string NOMBREPROGRAMA { get; set; }
        public string DESCRIPCION { get; set; }
        public string IMAGEN { get; set; }
        public int CUPOS { get; set; }
        public int? IDCENTRO { get; set; }
        public string TIPOPERIODO { get; set; }
        public string AREAESCUELA { get; set; }
        public string REQUISITOS { get; set; }
        public string COSTOINCLUIDO { get; set; }
        public char PUBLICADO { get; set; }
        public DateTime FECHAPUBLICACION { get; set; }

    }
}
