using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesModelo
{
    public class Antecedente
    {
        public int idAntecedente { get; set; }
        public string docadjunto{ get; set; }
        public string tipoDoc{ get; set; }
        public int idUsuarioFK { get; set; }
    }
}
