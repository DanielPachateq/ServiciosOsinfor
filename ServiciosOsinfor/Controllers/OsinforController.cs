using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entidades;
using Newtonsoft.Json;

namespace ServiciosNacionCrema.Controllers
{    
    public class OsinforController : ApiController
    {
        private SubmenuBL submenuBL = new SubmenuBL();
        private PublicacionesBL publicacionBL = new PublicacionesBL();
        private SlideBL comunicadoBL = new SlideBL();
        private EventosBL eventoBL = new EventosBL();
        private Eventos evento = new Eventos();
        // GET api/<controller>
        [HttpGet]
        [ActionName("Submenu")]
        public List<Submenu> GetSubmenu()
        {
            List<Submenu> listsubmenu = new List<Submenu>();
            var obtener = submenuBL.Listar();
            foreach (var item in obtener)
            {
                listsubmenu.Add(item);
            }
            return listsubmenu;
        }

        [HttpGet]
        [ActionName("publicaciones")]
        public List<Publicaciones> GetPublicaciones()
        {
            List<Publicaciones> listpublicaciones = new List<Publicaciones>();
            var obtener = publicacionBL.Listar();
            foreach (var item in obtener)
            {
                listpublicaciones.Add(item);                
            }
            return listpublicaciones;
        }
        [HttpGet]
        [ActionName("comunicados")]
        public List<Comunicados> GetComunicados()
        {

            List<Comunicados> listcomunicados = new List<Comunicados>();
            var obtener = comunicadoBL.Listar();
            foreach (var item in obtener)
            {


                listcomunicados.Add(item);                
            }
            return listcomunicados;
        }
        [HttpPost]
        [ActionName("eventosproximos")]
        public List<ListEventos> GetEventosProximos([FromBody]BuscarEvento buscaevento)
        {
            ListEventos evento_ = new ListEventos();
            List<ListEventos> listeventos = new List<ListEventos>();
            var obtener = eventoBL.Listar(buscaevento.Evento, 0);

            foreach (var item in obtener)
            {
                listeventos.Add(item);
            }
            return listeventos;
        }
        [HttpPost]
        [ActionName("eventospasados")]
        public List<ListEventos> GetEventosPasados([FromBody]BuscarEvento buscaevento)
        {

            ListEventos evento_ = new ListEventos();
            List<ListEventos> listeventos = new List<ListEventos>();
            var obtener = eventoBL.Listar(buscaevento.Evento, 1);
           
            foreach (var item in obtener)
            {                
                listeventos.Add(item);
            }
            return listeventos;
        }

        [HttpPost]
        [ActionName("obtenerfavoritos")]
        public List<Favoritos> PostFavoritos([FromBody]Obtenerfavorito obtenerfavorito)
        {
          
            List<Favoritos> listeventos = new List<Favoritos>();
            var lisFavoritos = eventoBL.ListaFavoritos(obtenerfavorito.IdUsuario, obtenerfavorito.Titulo);
            foreach (var item in lisFavoritos)
            {
                listeventos.Add(item);
            }
            return listeventos;
        }

        [HttpPost]
        [ActionName("InsertarFavorito")]
        public RptaObtenerfavorito Insertfavorito([FromBody]Obtenerfavorito obtenerfavorito)
        {
            RptaObtenerfavorito respuesta = new RptaObtenerfavorito();
            String msjError="";
            var rpta = eventoBL.InsertarFavoritos(obtenerfavorito, out msjError);

            if (rpta == 0)
            {
                respuesta.codigo = 0;
                respuesta.Mensaje = "El evento se agrego a favoritos";
            }
            else {
                respuesta.codigo = -1;
                respuesta.Mensaje = "El evento ya se encuentra en favoritos.";
            }
            
            return respuesta;
        }
        [HttpPost]
        [ActionName("EliminarFavorito")]
        public RptaObtenerfavorito Deletefavorito([FromBody]Obtenerfavorito obtenerfavorito)
        {
            RptaObtenerfavorito respuesta = new RptaObtenerfavorito();            
            bool rpta =eventoBL.EliminarFavorito(obtenerfavorito);

            if (rpta == true)
            {
                respuesta.codigo = 0;
                respuesta.Mensaje = "Se eliminó el registro de favoritos.";
            }
            else {
                respuesta.codigo = -1;
                respuesta.Mensaje = "No se eliminó el registro de favoritos";
            }
            
            return respuesta;
        }

        [HttpPost]
        [ActionName("ObtenerEvento")]
        public ObtenerEvento Post([FromBody]EventoId eventoid)
        {
            ObtenerEvento respuesta = new ObtenerEvento();
            Eventos evento_ = new Eventos();
            List<Materiales> listmateriales = new List<Materiales>();
            List<Videos> listvideos = new List<Videos>();
            List<Ponentes> listponentes = new List<Ponentes>();
                       
            eventoBL.ObtenerEvento(eventoid.Id, ref evento_);
            listponentes = eventoBL.ListaPonentes(eventoid.Id);
            listvideos = eventoBL.ListaVideos(eventoid.Id);
            listmateriales = eventoBL.ListaMateriales(eventoid.Id);

            listponentes.Where(x => x.Id == eventoid.Id);
            listvideos.Where(x => x.Id == eventoid.Id);
            listmateriales.Where(x => x.Id == eventoid.Id);

            respuesta.Id = evento_.Id;
            respuesta.Titulo = evento_.Titulo;
            respuesta.Descripcion = evento_.Descripcion;
            respuesta.Fecha = evento_.Fecha;
            respuesta.Hora = evento_.Hora_Ini +  " - " + evento_.Hora_Fin;
            respuesta.LogoEvento = evento_.LogoEvento;
            respuesta.Ubicacion = evento_.Ubicacion;
            respuesta.Tipo = evento_.Tipo;
            respuesta.Estado = evento_.Estado;
            respuesta.ListMateriales = listmateriales;
            respuesta.listPonentes = listponentes;
            respuesta.listVideos = listvideos;

            return respuesta;
        }
        [HttpPost]
        [ActionName("InsertarUsuario")]
        public RptaUsuario InsertUsuario([FromBody]Usuario usuario)
        {
            RptaUsuario respuesta = new RptaUsuario();
            String msjError = "";
            var existe = eventoBL.ObtenerUsuario(usuario.username);

            if (existe == true)
            {
                respuesta.codigo = -1;
                respuesta.Mensaje = "usuario ya se encuentra registrado";
            }
            else {
                respuesta.codigo = 0;
                eventoBL.InsertarUsuario(usuario, out msjError);                
                respuesta.Mensaje = msjError.ToString();
            }
            return respuesta;
        }
        [HttpPost]
        [ActionName("Login")]
        public RptaLogin PostUsuario([FromBody]ObtenerUsuario obtenerusuario)
        {
            Usuario usuario = new Usuario();
            RptaLogin rptalogin = new RptaLogin();

            var r= eventoBL.Autentificarse(obtenerusuario.correo, obtenerusuario.clave, ref usuario);
            if (r == true)
            {
                rptalogin.Codigo = 0;
                rptalogin.Id = usuario.Codigo;                
                rptalogin.nombres = usuario.Nombres;
                rptalogin.correo = usuario.username;
            }
            else {                
                rptalogin.Codigo = -1;
                rptalogin.mensaje = "Usuario no registrado en el APP.";
            }

            return rptalogin;
        }
        [HttpPost]
        [ActionName("RecuperarCuenta")]
        public RptaUsuario PostRecuperarCuenta([FromBody]RecuperarClave recuperarclave)
        {
            RptaUsuario respuesta = new RptaUsuario();
            var existe = eventoBL.RecuperarClave(recuperarclave.Correo);
            if (existe == true)
            {
                respuesta.Mensaje = "Se envio el Correo de recuperación";
            }
            else
            {
                respuesta.Mensaje = "No se encuentra resgistrado el Usuario";
            }

            return respuesta;
        }

    }
}