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

        public List<Nota> TraerTodo()
        {
            List<Nota> res = new List<Nota>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from notas");
            foreach (DataRow row in tabla.Rows)
            {
                Nota nota = new Nota();
                nota.idNotas =int.Parse( row["IDNOTAS"].ToString());
                nota.calificacion = float.Parse(row["CALIFICACION"].ToString());
                nota.profesor = row["PROFESOR"].ToString();
                nota.idPostulanteFK= int.Parse(row["IDPOSTULANTEFK"].ToString());
                nota.idPogramaFK= int.Parse(row["IDPROGRAMAFK"].ToString());
                nota.fecha = DateTime.Parse(row["fecha"].ToString());
                nota.numeral= int.Parse(row["NUMERAL"].ToString());
                res.Add(nota);
            }
            return res;
        }


        public bool InsertarNotasPorDefecto(int idPostu,int idProg)
        {
            bool res = false;
            for (int i=0;i<4;i++)
            {
                int cardi = 0;
                switch (i)
                {
                    case 0:
                        cardi = 1;
                        break;
                    case 1:
                        cardi = 2;
                        break;
                    case 2:
                        cardi = 3;
                        break;
                    case 3:
                        cardi = 4;
                        break;
                    default:
                        cardi =-1;
                        break;
                }
                string sql = "begin NOTAINSERT(1.0,'No asignado',"+ idPostu + ","+idProg+","+cardi+"); end;";
                this.ConexionOracle.Ejecutar(sql);
            }
            
            res = true;
            return res;
        }

        public List<Nota> TraeNotasDe(int idPostu)
        {
            List<Nota> res = new List<Nota>();
            foreach (Nota nota in this.TraerTodo())
            {
                if (nota.idPostulanteFK==idPostu)
                {
                    res.Add(nota);
                }
            }
            return res;
        }

        public bool Actualizar(int id, float calificacion)
        {
            bool res = false;
            string sql = string.Format("begin NOTAUPDATE({0},{1}); end;",calificacion,id);
            ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

    }
}
