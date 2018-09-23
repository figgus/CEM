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
            if (this.YaPostulo(postulante.IDUSUARIOFK,postulante.IDPROGRAMAESTUDIOFK))
            {
                return false;
            }
            string sql = "begin POSTULANTEINSERT('"+postulante.ESTADOPOSTULACION+"',"+postulante.IDPROGRAMAESTUDIOFK+","+postulante.IDUSUARIOFK+"); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }


        public List<Postulante> TraerTodo()
        {
            List<Postulante> res = new List<Postulante>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from Postulante");
            foreach (DataRow row in tabla.Rows)
            {
                Postulante postu = new Postulante();
                postu.IDPOSTULANTE = int.Parse(row["IDPOSTULANTE"].ToString());
                postu.ESTADOPOSTULACION = row["ESTADOPOSTULACION"].ToString();
                postu.FECHAPOSTULACION = DateTime.Parse(row["FECHAPOSTULACION"].ToString());
                postu.IDPROGRAMAESTUDIOFK = int.Parse(row["IDPROGRAMAESTUDIOFK"].ToString());
                postu.IDUSUARIOFK = int.Parse(row["IDUSUARIOFK"].ToString());
                res.Add(postu);
            }
            return res;
        }


        public List<Postulante> TraerDe(int? idPorgrama)//Trae los postulantes a un programa de estudios
        {
            List<Postulante> res = new List<Postulante>();
            foreach (Postulante post in this.TraerTodo())
            {
                if (post.IDPROGRAMAESTUDIOFK==idPorgrama)
                {
                    res.Add(post);
                }
            }
            return res;
        }

        public bool SeleccionarPostulante(int idUsuPostu,int idPrograma)
        {
            bool res = false;
            ConexionOracle.Ejecutar("UPDATE postulante set estadopostulacion='APROBADO' where idusuariofk="+idUsuPostu+ " and idprogramaestudiofk="+idPrograma+"");
            res = true;
            return res;
        }

        public Postulante Traer(int idUsuPostu, int idPrograma)
        {
            foreach (Postulante pos in this.TraerTodo())
            {
                if (pos.IDUSUARIOFK==idUsuPostu && pos.IDPROGRAMAESTUDIOFK==idPrograma)
                {
                    return pos;
                }
            }
            return new Postulante();
        }

        public int GetIdForUser(int idUsuario)
        {
            foreach (Postulante pos in this.TraerTodo())
            {
                if (pos.IDUSUARIOFK==idUsuario)
                {
                    return pos.IDPOSTULANTE;
                }
            }
            return 0;
        }


        private bool EsRegular()
        {
            return true;
        }

        private bool YaPostulo(int idAlu,int idProg)
        {
            foreach (Postulante pos in this.TraerTodo())
            {
                if (pos.IDUSUARIOFK==idAlu && pos.IDPROGRAMAESTUDIOFK==idProg)
                {
                    return true;
                }
            }
            return false;
        }




    }
}
