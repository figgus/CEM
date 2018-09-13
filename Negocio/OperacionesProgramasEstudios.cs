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



    }
}