﻿using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ClasesModelo;
using System.Data;

namespace Negocio
{
    public class OperacionesProgramasEstudios
    {
        private Conexion ConexionOracle { get; set; }

        public OperacionesProgramasEstudios()
        {
            ConexionOracle = new Conexion();
        }

        public bool Insertar(ProgramaEstudios programa)
        {
            bool res = false;
            string sql = "begin PROGRAMAESTUDIOINSERT('"+programa.NOMBREPROGRAMA+"','"+programa.DESCRIPCION+"','"+programa.IMAGEN+"',"+programa.CUPOS+",null,'"+programa.TIPOPERIODO+"'," +
                        "'"+programa.AREAESCUELA+"','"+programa.REQUISITOS+"','"+programa.COSTOINCLUIDO+"'); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

        public List<ProgramaEstudios> TraerTodo()
        {
            List<ProgramaEstudios> res = new List<ProgramaEstudios>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from programaestudio");
            foreach (DataRow row in tabla.Rows)
            {
                ProgramaEstudios pro = new ProgramaEstudios();
                pro.IDPROGRAMAESTUDIO = int.Parse(row["IDPROGRAMAESTUDIO"].ToString());
                pro.NOMBREPROGRAMA = row["NOMBREPROGRAMA"].ToString();
                pro.DESCRIPCION= row["DESCRIPCION"].ToString();
                pro.IMAGEN = row["IMAGEN"].ToString();
                pro.CUPOS = int.Parse( row["CUPOS"].ToString());
                try
                {
                    if (row["IDCENTRO"] != null)
                    {
                        pro.IDCENTRO = int.Parse(row["IDCENTRO"].ToString());
                    }
                }
                catch (Exception)
                {

                }
                
                pro.TIPOPERIODO= row["TIPOPERIODO"].ToString();
                pro.AREAESCUELA= row["AREAESCUELA"].ToString();
                pro.REQUISITOS= row["REQUISITOS"].ToString();
                pro.COSTOINCLUIDO= row["COSTOINCLUIDO"].ToString();
                pro.PUBLICADO= row["PUBLICADO"].ToString().ToCharArray()[0];
                pro.FECHAPUBLICACION= DateTime.Parse( row["FECHAPUBLICACION"].ToString());

                res.Add(pro);
            }
            return res;
        }


        public bool Publicar(int id)
        {
            bool res = false;
            ConexionOracle.Ejecutar("update programaestudio set PUBLICADO='1' where IDPROGRAMAESTUDIO="+id+"");
            res = true;
            return res;
        }

        public string TraerNombrePorId(int id)
        {
            DataTable dt= ConexionOracle.Ejecutar("select NOMBREPROGRAMA from programaestudio where idprogramaestudio=" + id+ " and ROWNUM=1");
            return dt.Rows[0]["NOMBREPROGRAMA"].ToString();
        }

        public ProgramaEstudios TraerPorId(int id)
        {
            foreach (ProgramaEstudios prog in this.TraerTodo())
            {
                if (prog.IDPROGRAMAESTUDIO==id)
                {
                    return prog;
                }
            }
            return new ProgramaEstudios();
        }

        public bool AsignarCentro(int idcentro,int idPrograma)
        {
            bool res = true;
            ConexionOracle.Ejecutar("UPDATE programaEstudio set idCentro=" + idcentro+" where idprogramaEstudio="+idPrograma+"");
            return res;
        }

        public List<Usuario> TraerAlumnosPostulantes(int idProg)
        {
            string sql = "select a.IDUSUARIO IDUSUARIO,a.USERNAME USERNAME,a.PASSWORD PASSWORD,a.PNOMBRE PNOMBRE,a.SNOMBRE SNOMBRE,a.APPAT APPAT,a.APMAT APMAT,a.EMAIL EMAIL,a.FONOCELULAR FONOCELULAR,a.FONOFIJO FONOFIJO,a.TIPOUSUARIO TIPOUSUARIO,a.ALUMNOREGULAR ALUMNOREGULAR,a.IDCARRERA IDCARRERA,a.IDINSTITUCION IDINSTITUCION from usuario a left join postulante b on a.idusuario = b.idusuariofk where b.idprogramaestudiofk = "+idProg+ " and b.ESTADOPOSTULACION='PENDIENTE'";
            DataTable dt= ConexionOracle.Ejecutar(sql);
            List<Usuario> usus = new List<Usuario>();
            foreach (DataRow row in dt.Rows)
            {
                Usuario user = new Usuario();
                user.IdUsuario = int.Parse(row["idUsuario"].ToString());
                user.Username = row["username"].ToString();
                user.Password = row["password"].ToString();
                user.Pnombre = row["pnombre"].ToString();
                user.Snombre = row["Snombre"].ToString();
                user.Appat = row["Appat"].ToString();
                user.Apmat = row["Apmat"].ToString();
                user.Email = row["Email"].ToString();
                user.FonoCelular = row["FonoCelular"].ToString();
                user.FonoFijo = row["FonoFijo"].ToString();
                user.TipoUsuario = int.Parse(row["tipoUsuario"].ToString());
                user.AlumnoRegular = int.Parse(row["AlumnoRegular"].ToString());
                user.IdCarrera = int.Parse(row["idUsuario"].ToString());
                user.idInstitucion = int.Parse(row["idUsuario"].ToString()) as int?;
                usus.Add(user);
            }
            return usus;
        }

        public List<Usuario> TraerAlumnosPostulantesSeleccionados(int idProg)
        {
            string sql = "select a.IDUSUARIO IDUSUARIO,a.USERNAME USERNAME,a.PASSWORD PASSWORD,a.PNOMBRE PNOMBRE,a.SNOMBRE SNOMBRE,a.APPAT APPAT,a.APMAT APMAT,a.EMAIL EMAIL,a.FONOCELULAR FONOCELULAR,a.FONOFIJO FONOFIJO,a.TIPOUSUARIO TIPOUSUARIO,a.ALUMNOREGULAR ALUMNOREGULAR,a.IDCARRERA IDCARRERA,a.IDINSTITUCION IDINSTITUCION from usuario a left join postulante b on a.idusuario = b.idusuariofk where b.idprogramaestudiofk = " + idProg + " and b.ESTADOPOSTULACION='APROBADO'";
            DataTable dt = ConexionOracle.Ejecutar(sql);
            List<Usuario> usus = new List<Usuario>();
            foreach (DataRow row in dt.Rows)
            {
                Usuario user = new Usuario();
                user.IdUsuario = int.Parse(row["idUsuario"].ToString());
                user.Username = row["username"].ToString();
                user.Password = row["password"].ToString();
                user.Pnombre = row["pnombre"].ToString();
                user.Snombre = row["Snombre"].ToString();
                user.Appat = row["Appat"].ToString();
                user.Apmat = row["Apmat"].ToString();
                user.Email = row["Email"].ToString();
                user.FonoCelular = row["FonoCelular"].ToString();
                user.FonoFijo = row["FonoFijo"].ToString();
                user.TipoUsuario = int.Parse(row["tipoUsuario"].ToString());
                user.AlumnoRegular = int.Parse(row["AlumnoRegular"].ToString());
                user.IdCarrera = int.Parse(row["idUsuario"].ToString());
                user.idInstitucion = int.Parse(row["idUsuario"].ToString()) as int?;
                usus.Add(user);
            }
            return usus;
        }

        public bool isCuposDisponibles(int id)
        {
            bool res = false;
            ProgramaEstudios programa = this.TraerPorId(id);
            int cuposTotales = programa.CUPOS;
            OperacionesPostulante opostu = new OperacionesPostulante();
            foreach (Postulante postulante in opostu.TraerTodo())
            {
                if (postulante.IDPROGRAMAESTUDIOFK==id)
                {
                    cuposTotales--;
                }
            }
            if (cuposTotales>0)
            {
                return true;
            }
            return res;
        }

        

    }
}
