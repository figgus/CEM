using Datos;
using Negocio.ClasesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class OperacionesPostulante
    {
        private Conexion ConexionOracle { get; set; }

        public OperacionesPostulante()
        {
            ConexionOracle = new Conexion();
        }


        public bool Insertar(Postulante postulante)
        {
            bool res = false;

            string sql = "begin POSTULANTEINSERT('"+postulante.ESTADOPOSTULACION+"',"+postulante.IDPROGRAMAESTUDIOFK+","+postulante.IDUSUARIOFK+"); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

    }
}
