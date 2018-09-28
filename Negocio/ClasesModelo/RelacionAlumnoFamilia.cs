using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesModelo
{
    public class RelacionAlumnoFamilia
    {
        public int idRelacionAlumnoFamilia { get; set; }
        public DateTime fecha{ get; set; }
        public int idAlumnoFK{ get; set; }
        public int idFamiliaFK { get; set; }
        public string estado { get; set; }
    }
}
