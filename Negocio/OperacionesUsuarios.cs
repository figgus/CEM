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
    public class OperacionesUsuarios:IDisposable
    {
        public Conexion ConexionOracle { get; set; }
        private bool alreadyDisposed = false;

        public OperacionesUsuarios()
        {
            ConexionOracle = new Conexion();
            Dispose(false);
        }

        public bool Insertar2(Usuario user)
        {
            bool res = false;

            string sql = "begin USUARIOINSERT('" + user.Username + "','" + user.Password + "','" + user.Pnombre + "','" + user.Snombre + "','" + user.Appat + "','" + user.Apmat + "','" + user.Email + "','" + user.FonoCelular + "','" + user.FonoFijo + "'," + user.TipoUsuario + "," + user.AlumnoRegular + "," + user.IdCarrera + ","+user.idInstitucion+"); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
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
                user.TipoUsuario = int.Parse(row["tipoUsuario"].ToString());
                user.AlumnoRegular = int.Parse(row["AlumnoRegular"].ToString());
                user.IdCarrera = int.Parse(row["idUsuario"].ToString());
                user.idInstitucion=int.Parse(row["idUsuario"].ToString()) as int?;
                res.Add(user);
            }
            return res;
        }
        public bool Borrar(int idUsu)
        {
            bool res= false;
            string sql = "begin USUARIODELETE(" + idUsu + "); end;";
            ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

        public bool Actualizar(Usuario user)
        {
            bool res = false;
            string sql = "begin USUARIOUPDATE("+user.IdUsuario+",'" + user.Username + "','" + user.Password + "','" + user.Pnombre + "','" + user.Snombre + "','" + user.Appat + "','" + user.Apmat + "','" + user.Email + "','" + user.FonoCelular + "','" + user.FonoFijo + "'," + user.TipoUsuario + "," + user.AlumnoRegular + "," + user.IdCarrera + "); end;";
            this.ConexionOracle.Ejecutar(sql);
            res = true;
            return res;
        }

        public Usuario Traer(int id)
        {
            Usuario res=new Usuario();
            foreach (Usuario usu in this.TraerTodo())
            {
                if (usu.IdUsuario==id)
                {
                    return usu;
                }
            }
            return res;

        }

        public List<Usuario> TraerFamilias()//
        {
            List<Usuario> res=new List<Usuario>();
            List<Usuario> lista = this.TraerTodo();
            foreach (Usuario usu in lista)
            {
                if (usu.TipoUsuario==5)
                {
                    res.Add(usu);
                }
            }
            return res;
        }

        public List<Usuario> TraerFamiliasAsociadas(int idCentro)//trae familais asociadas a un centro de estudios
        {
            List<Usuario> res = new List<Usuario>();
            foreach (Usuario user in this.TraerFamilias())
            {
                if (user.idInstitucion==idCentro)
                {
                    res.Add(user);
                }
            }
            return res;
        }

        public List<Usuario> TraerFamiliasPorInstitucion(int id)
        {
            List<Usuario> res = new List<Usuario>();
            List<Usuario> lista = this.TraerTodo();
            foreach (Usuario usu in lista)
            {
                if (usu.TipoUsuario == 5 && usu.idInstitucion==id)
                {
                    res.Add(usu);
                }
            }
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
