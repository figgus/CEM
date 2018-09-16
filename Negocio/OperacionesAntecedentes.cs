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
    public class OperacionesAntecedentes
    {
        public Conexion ConexionOracle { get; set; }

        public OperacionesAntecedentes()
        {
            ConexionOracle = new Conexion();
        }

        public List<Antecedente> TraerTodo()
        {
            List<Antecedente> res = new List<Antecedente>();
            DataTable tabla = this.ConexionOracle.Ejecutar("select * from Antecendente");
            foreach (DataRow row in tabla.Rows)
            {
                Antecedente ante = new Antecedente();
                ante.idAntecedente = int.Parse(row["idAntecedente"].ToString());
                ante.docadjunto = row["docadjunto"].ToString();
                ante.tipoDoc= row["tipoDoc"].ToString();
                ante.idUsuarioFK= int.Parse( row["idUsuarioFK"].ToString());
                res.Add(ante);
            }
            return res;
        }

        public List<Antecedente> TraerDe(int id)
        {
            List<Antecedente> res =this.TraerTodo();
            List<Antecedente> lista = new List<Antecedente>();
            foreach (Antecedente ante in res)
            {
                if (ante.idUsuarioFK==id)
                {
                    lista.Add(ante);
                }
            }
            
            return lista;
        }


        public bool Insertar(Antecedente ante)
        {
            bool res = false;
            string sql = "begin ANTECEDENTEINSERT('"+ante.docadjunto+"','"+ante.tipoDoc+"',"+ante.idUsuarioFK+");end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

    }
}
