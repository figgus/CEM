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
    public class OperacionesTipoUsuario
    {
        private Conexion ConexionOracle { get; set; }

        public OperacionesTipoUsuario()
        {
            ConexionOracle = new Conexion();
        }

        public bool Insertar(TipoUsuario car)
        {

            return true;
        }

        public List<TipoUsuario> TraerTodo()
        {
            List<TipoUsuario> res = new List<TipoUsuario>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from tipoUsuario");
            foreach (DataRow row in tabla.Rows)
            {
                TipoUsuario carr = new TipoUsuario();
                carr.idTipoUsuario= int.Parse(row["idTipoUsuario"].ToString());
                carr.nombreTipo = row["nombreTipo"].ToString();
                res.Add(carr);
            }
            return res;
        }
    }
}
