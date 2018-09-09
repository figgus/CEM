using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Negocio.ClasesModelo;

namespace CEM.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PanelAdmin()
        {
            return View();
        }

        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BorrarUsuario(int idBorrar)
        {
            string res = "false";
            OperacionesUsuarios opusu = new OperacionesUsuarios();
            if (opusu.Borrar(idBorrar))
            {
                res = "true";
            }
            return Json(res);
        }

        [HttpPost]
        public JsonResult CrearUsuarioPanel()
        {
            Usuario usu = new Usuario();
            string res = "false";
            usu.Username = Request["nombreUsuario"];
            usu.Password = Request["password"] ;
            usu.Pnombre= Request["pnombre"];
            usu.Snombre = Request["snombre"];
            usu.Appat = Request["apat"];
            usu.Apmat = Request["amat"];
            usu.Email= Request["email"];
            usu.FonoFijo= Request["fijo"];
            usu.FonoCelular= Request["movil"];
            usu.TipoUsuario = int.Parse( Request["tipoUsuario"]);
            usu.AlumnoRegular = int.Parse(Request["estado"]);
            usu.IdCarrera = int.Parse(Request["idCarrera"]);

            if (new OperacionesUsuarios().Insertar2(usu))
            {
                res = "true";
            }
            
            return Json(res);
        }


       

    }
}