using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Negocio.ClasesModelo;

namespace CEM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult ProgramasEstudio()
        {
            return View();
        }

        [HttpPost]
        public string IngresoCredenciales()
        {
            string res = "false";
            string user = Request["username"];
            string pass = Request["password"];
            List<Usuario> lista = new OperacionesUsuarios().TraerTodo();
            foreach (Usuario usu in lista)
            {
                if (usu.Username==user && usu.Password==usu.Password)
                {
                    Session["usuario"] = usu;//quizas borrar
                    Session["idUsuario"]=usu.IdUsuario;
                    Session["username"] = usu.Username;
                    Session["tipo"] = usu.TipoUsuario as int?;
                    return "true"+usu.TipoUsuario;
                }
            }
            return res;
        }



        [HttpPost]
        public JsonResult CrearUsuarioAutoregistro()
        {
            string res = "false";
            Usuario user = new Usuario();
            user.Username = Request["nombreUsuario"];
            user.Password = Request["password"];
            user.Pnombre = Request["pnombre"];
            user.Snombre = Request["snombre"];
            user.Appat = Request["apat"];
            user.Apmat = Request["amat"];
            user.Email = Request["email"];
            user.FonoCelular = Request["fonoCelular"];
            user.FonoFijo = Request["fonoFijo"];
            string tipo = Request["tipoUsuario"];
            user.idInstitucion = int.Parse(Request["Institucion"]);
            switch (tipo)
            {
                case "Alumno":
                    user.TipoUsuario = 2;
                    break;
                case "Familia":
                    user.TipoUsuario = 5;
                    break;
                default:
                    throw new Exception("Tipo de usuario no valido");
            }

            user.AlumnoRegular = 1;
            //user.IdCarrera = 3;
            
            user.IdCarrera = int.Parse(Request["carrera"]);

            new OperacionesUsuarios().Insertar2(user);
            res = "true";
            return Json(res);
        }


    }

}