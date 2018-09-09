using Datos;
using Negocio.ClasesModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class OperacionesCarrera
    {
        private Conexion ConexionOracle { get; set; }

        public OperacionesCarrera()
        {
            ConexionOracle = new Conexion();
        }

        public bool Insertar(Carrera car)
        {
            
            return true;
        }

        public List<Carrera> TraerTodo()
        {
            List<Carrera> res = new List<Carrera>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from Carrera");
            foreach (DataRow row in tabla.Rows)
            {
                Carrera carr = new Carrera();
                carr.idCarrera = int.Parse(row["idCarrera"].ToString());
                carr.nombreCarrera = row["nombreCarrera"].ToString();
                carr.idInstitucion= int.Parse(row["idCarrera"].ToString());
                res.Add(carr);
            }
            return res;
        }
        //public bool Borrar(int idUsu)
        //{
        //    bool res = false;
        //    ConexionOracle.Ejecutar("begin USUARIODELETE(" + idUsu + "); end;");
        //    res = true;
        //    return res;
        //}

        //public bool Actualizar()
        //{
        //    return true;
        //}
    }
}
