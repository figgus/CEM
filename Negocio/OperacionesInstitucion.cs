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
    public class OperacionesInstitucion
    {
        public Conexion ConexionOracle { get; set; }

        public OperacionesInstitucion()
        {
            ConexionOracle = new Conexion();
        }

        public List<Institucion> TraerTodo()
        {
            List<Institucion> res = new List<Institucion>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from INSTITUCION");
            foreach (DataRow row in tabla.Rows)
            {
                Institucion user = new Institucion();
                user.idInstitucion = int.Parse(row["IDINSTITUCION"].ToString());
                user.nomInstitucion = row["NOMINSTITUCION"].ToString();
                
                res.Add(user);
            }
            return res;
        }


        public bool Insertar(Institucion insti)
        {
            bool res = false;
            string sql = "begin InstitucionInsert('"+insti.nomInstitucion+"');end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }
    }
}
