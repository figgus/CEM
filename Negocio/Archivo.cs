using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ClasesModelo;
using Spire.Doc;

namespace Negocio
{
    public class Archivo
    {
        public string RutaCarpetaCertificados { get; set; }


        public bool GenerarCertificado(Usuario usuarioAlumno,string curso,string rutaEntrada,string rutaSalida)
        {
            using (Document doc=new Document())
            {
                doc.LoadFromFile(rutaEntrada);
                doc.Replace("[nombre]",string.Format("{0} {1} {2} {3}",usuarioAlumno.Pnombre,usuarioAlumno.Snombre,usuarioAlumno.Appat,usuarioAlumno.Apmat),true,true);
                doc.Replace("[Carrera]", curso, true, true);
                doc.Replace("[fecha]", string.Format("{0} de {1} del {2}",DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year), true, true);
                doc.SaveToFile(rutaSalida);
                return true;
            }
        }
    }
}
