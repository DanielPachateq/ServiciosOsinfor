using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entidades;
using System.IO;

namespace ServiciosNacionCrema.Controllers
{
    public class ComunicadosController : Controller
    {
        // GET: Comunicados
        private ComunicadosBL comunicadosBL = new ComunicadosBL();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    var Comunicados = comunicadosBL.ListaComunicados();
        //    return View(Comunicados);
        //}
        [HttpPost]
        public JsonResult ListaComunicados()
        {
            var lista = comunicadosBL.ListaComunicados();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Salir()
        {
            //SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
        public ActionResult Eliminar(int Id)
        {
            var eliminar = comunicadosBL.Eliminar(Id);
            return View("Index");
        }
        public ActionResult Nuevo(int id = 0)
        {
            return View(new Comunicados());
        }

        public ActionResult Guardar(Comunicados comunicados)
        {
            //Comunicados comunicados = new Comunicados();
            //var lista = comunicadosBL.ListaComunicados();
            //if (lista.Count() < 4)
            //{
            //    string extension = Path.GetExtension(Archivo.FileName);
            //    if (Archivo != null)
            //    {
            //        // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
            //        string archivo = DateTime.Now.ToString("yyyyMMdd_") + Path.GetFileName(Archivo.FileName);
            //        // La ruta donde lo vamos guardar
            //        Archivo.SaveAs(Server.MapPath("~/Archivos/" + archivo));
            //        string root = "~/Archivos/" + archivo;
            //        // Establecemos en nuestro modelo el nombre del archivo
            //        comunicados.UrlImagen = archivo;
            //        var registronuevo = comunicadosBL.Registrar(comunicados);
            //    }
            //}
            //else
            //{

            //}
            return Redirect("Index");

        }

        public ActionResult Actualizar(int Id, HttpPostedFileBase Archivo)
        {
            string extension = Path.GetExtension(Archivo.FileName);
            if (Archivo != null)
            {
                // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                string archivo = DateTime.Now.ToString("yyyyMMdd_") + Path.GetFileName(Archivo.FileName);
                // La ruta donde lo vamos guardar
                Archivo.SaveAs(Server.MapPath("~/Archivos/" + archivo));
                string root = "~/Archivos/" + archivo;
                // Establecemos en nuestro modelo el nombre del archivo


                var actualizar = comunicadosBL.Actualizar(Id, archivo);
            }
            return Redirect("Index");
        }

        public ActionResult Editar(int id)
        {
            Comunicados comunicado = new Comunicados();

            comunicadosBL.Obtener(id, ref comunicado);

            return View(comunicado);
        }        
    }
}