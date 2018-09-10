using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult EditarUsuario()
        {
            return View();
        }

        public ActionResult AgregarCentro()
        {
            return View();
        }

        public ActionResult AgregarPrograma()
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

        [HttpPost]
        public JsonResult ActualizarUsuarioPanel()
        {
            string res = "false";
            Usuario usu = new Usuario();
            usu.IdUsuario= int.Parse( Request["id"]);
            usu.Username = Request["nombreUsuario"];
            usu.Password = Request["password"];
            usu.Pnombre = Request["pnombre"];
            usu.Snombre = Request["snombre"];
            usu.Appat = Request["apat"];
            usu.Apmat = Request["amat"];
            usu.Email = Request["email"];
            usu.FonoFijo = Request["fijo"];
            usu.FonoCelular = Request["movil"];
            usu.TipoUsuario = int.Parse(Request["tipoUsuario"]);
            usu.AlumnoRegular = int.Parse(Request["estado"]);
            if (!string.IsNullOrEmpty(Request["idCarrera"])) {
                usu.IdCarrera = int.Parse(Request["idCarrera"]);
            }
            else
            {
                usu.IdCarrera = 22;
            }

            if( new OperacionesUsuarios().Actualizar(usu))
            {
                res = "true";
            }
            return Json(res);
        }


        [HttpPost]
        public JsonResult CrearCentro()
        {
            Institucion inst = new Institucion();
            string res = "false";
            inst.nomInstitucion= Request["nom"];
            

            if (new OperacionesInstitucion().Insertar(inst))
            {
                res = "true";
            }

            return Json(res);
        }

        [HttpPost]
        public ActionResult CrearPrograma()
        {
            string res = "false";
            ProgramaEstudios programa = new ProgramaEstudios();
            programa.NOMBREPROGRAMA = Request["nombre"].ToString();
            programa.DESCRIPCION = Request["Desc"];
            var a = Request.Files;
            if (a!=null)
            {
                var file = Request.Files[0];
                var path = Path.Combine(Server.MapPath("~/Scripts/images/Programas/"),file.FileName);
                file.SaveAs(path);
                programa.IMAGEN = file.FileName;
            }
            

            programa.CUPOS= int.Parse( Request["cupos"]);
            programa.TIPOPERIODO= Request["periodo"];
            programa.AREAESCUELA= Request["Area"];
            programa.REQUISITOS= Request["Requisitos"];
            programa.COSTOINCLUIDO = Request["Costo"];



            OperacionesProgramasEstudios opro = new OperacionesProgramasEstudios();
            opro.Insertar(programa);
            res = "true";
            return Json(res);
        }

        [HttpPost]
        public JsonResult PublicarPrograma(int idPrograma)
        {
            string res = "false";

            return Json(res);
        }
    }
}