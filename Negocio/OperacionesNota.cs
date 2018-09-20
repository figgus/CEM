using Datos;
using Negocio.ClasesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class OperacionesNota
    {
        public Conexion ConexionOracle { get; set; }

        public OperacionesNota()
        {
            ConexionOracle = new Conexion();
        }


        public bool Insertar(Nota nota)
        {
            bool res = false;

            string sql = "begin NOTAINSERT('"+nota.calificacion+"','"+nota.profesor+"',"+nota.idPostulanteFK+","+nota.idPogramaFK+"); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }



    }
}
