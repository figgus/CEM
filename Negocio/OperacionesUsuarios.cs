using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocio.ClasesModelo;

namespace Negocio
{
    public class OperacionesUsuarios
    {
        public Conexion ConexionOracle { get; set; }

        public OperacionesUsuarios()
        {
            ConexionOracle = new Conexion();
        }

        public bool Insertar(Usuario user)
        {
            string sql = string.Format("insert into usuario values (AUTOUSUARIO.nextval,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11})",
                user.Username, user.Password, user.Pnombre, user.Snombre, user.Appat, user.Apmat, user.Email, user.FonoCelular, user.FonoFijo, user.TipoUsuario, user.AlumnoRegular, user.IdCarrera);
            this.ConexionOracle.Ejecutar(sql);
            return true;
        }

        public List<Usuario> TraerTodo()
        {
            List<Usuario> res = new List<Usuario>();
            DataTable tabla= this.ConexionOracle.Ejecutar("select * from usuario");
            foreach (DataRow row in tabla.Rows)
            {
                Usuario user = new Usuario();
                user.IdUsuario = int.Parse( row["idUsuario"].ToString());
                user.Username = row["username"].ToString();
                user.Password = row["password"].ToString();
                user.Pnombre = row["pnombre"].ToString();
                user.Snombre = row["Snombre"].ToString();
                user.Appat = row["Appat"].ToString();
                user.Apmat = row["Apmat"].ToString();
                user.Email = row["Email"].ToString();
                user.FonoCelular = row["FonoCelular"].ToString();
                user.FonoFijo= row["FonoFijo"].ToString();
                user.TipoUsuario = int.Parse(row["idUsuario"].ToString());
                user.AlumnoRegular = int.Parse(row["AlumnoRegular"].ToString());
                user.IdCarrera = int.Parse(row["idUsuario"].ToString());
                res.Add(user);
            }
            return res;
        }
        public bool Borrar()
        {
            return true;
        }

        public bool Actualizar()
        {
            return true;
        }
    }
}
