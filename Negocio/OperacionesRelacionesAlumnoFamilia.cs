using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ClasesModelo;
using System.Data;

namespace Negocio
{
    public class OperacionesRelacionesAlumnoFamilia:IDisposable
    {
        private Conexion ConexionOracle { get; set; }

        private bool alreadyDisposed = false;

        public OperacionesRelacionesAlumnoFamilia()
        {
            ConexionOracle = new Conexion();
            Dispose(false);
        }


        public bool Insertar(RelacionAlumnoFamilia rel)
        {
            bool res = false;
            string sql = string.Format("begin RELACIONAFINSERT({0},{1}); end;",rel.idAlumnoFK,rel.idFamiliaFK);
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }


        public List<RelacionAlumnoFamilia> TraerTodo()
        {
            List<RelacionAlumnoFamilia> res = new List<RelacionAlumnoFamilia>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from RELACIONALUMNOFAMILIA");
            foreach (DataRow row in tabla.Rows)
            {
                RelacionAlumnoFamilia rel = new RelacionAlumnoFamilia();
                rel.idRelacionAlumnoFamilia = int.Parse( row["IDRELACIONALUMNOFAMILIA"].ToString());
                rel.fecha = DateTime.Parse(row["FECHA"].ToString());
                rel.idAlumnoFK= int.Parse(row["IDALUMNOFK"].ToString());
                rel.idFamiliaFK= int.Parse(row["IDFAMILIAFK"].ToString());
                rel.estado = row["estado"].ToString();
                res.Add(rel);
            }
            return res;
        }

        public bool isRelacionado(int idUsuario)//determina si el usuario ingresado ya esta en una relacion alumno-familia
        {
            foreach (RelacionAlumnoFamilia rel in this.TraerTodo())
            {
                if (idUsuario==rel.idAlumnoFK || idUsuario==rel.idFamiliaFK)
                {
                    return true;
                }
            }
            return false;
        }


        public bool ConfirmarSeleccion(int idAlumno, int idFamilia)//cambia el valor del atributo estado a 'aprobado' significa que la famila confirma que hospedara al alumno
        {
            bool res = false;
            string sql = string.Format("begin CONFIRMARSELECCION({0},{1}); end;", idAlumno, idFamilia);
            ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposeManagedResourcesAlso)
        {
            if (alreadyDisposed) return;

            if (disposeManagedResourcesAlso)
            {
            }
            

        alreadyDisposed = true;
        }

    }
}
