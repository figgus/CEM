using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesModelo
{
    public class Usuario
    {
        private int idUsario;
        private string username;
        private string password;
        private string pnombre;
        private string snombre;
        private string appat;
        private string apmat;
        private string email;
        private string fonoCelular;
        private string fonoFijo;
        private int tipoUsuario;
        private int alumnoRegular;

        public Usuario()
        {
        }

        public Usuario(int idUsario, string username, string password, string pnombre, string snombre, string appat, string apmat, string email, string fonoCelular, string fonoFijo, int tipoUsuario, int alumnoRegular, int idCarrera)
        {
            this.IdUsuario = idUsario;
            this.Username = username;
            this.Password = password;
            this.Pnombre = pnombre;
            this.Snombre = snombre;
            this.Appat = appat;
            this.Apmat = apmat;
            this.Email = email;
            this.FonoCelular = fonoCelular;
            this.FonoFijo = fonoFijo;
            this.TipoUsuario = tipoUsuario;
            this.AlumnoRegular = alumnoRegular;
            this.IdCarrera = idCarrera;
        }

        public int IdCarrera { get; set; }
        public int IdUsuario { get => idUsario; set => idUsario = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Pnombre { get => pnombre; set => pnombre = value; }
        public string Snombre { get => snombre; set => snombre = value; }
        public string Appat { get => appat; set => appat = value; }
        public string Apmat { get => apmat; set => apmat = value; }
        public string Email { get => email; set => email = value; }
        public string FonoCelular { get => fonoCelular; set => fonoCelular = value; }
        public string FonoFijo { get => fonoFijo; set => fonoFijo = value; }
        public int TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public int AlumnoRegular { get => alumnoRegular; set => alumnoRegular = value; }
    }
}
