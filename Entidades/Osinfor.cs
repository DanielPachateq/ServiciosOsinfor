using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entidades
{
    public class Osinfor
    {

    }

    public class Comunicados
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Archivo")]
        public string UrlImagen { get; set; }
    }
    public class Eventos
    {
        public int Id { get; set; }        
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_ini { get; set; }
        public string Fecha_fin { get; set; }
        public string Fecha { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }        
        public string Hora_Ini { get; set; }
        public string Hora_Fin { get; set; }        
        
        public string Hora { get; set; } 
        public string Ubicacion { get; set; }
        public string LogoEvento { get; set; }        

    }
    public class ListEventos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Fecha_ini { get; set; }
        public string Fecha_fin { get; set; }
        public string Fecha { get; set; }

        public string Estado { get; set; }

    }

    public class Ponentes
    { 
        public int Id { get; set; }
        public int IdPonente { get; set; }
        public string NombresApellidos { get; set; }
        public string Institucion { get; set; }
        public string Cargo { get;set; }
        public string Resena { get; set; }
        public string foto { get; set; }
    }

    public class Videos
    {
        public int Id { get; set; }
        public int IdVideo { get; set; }
        public string urlVideo {get;set;}
   
    }

    public class Materiales
    { 
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        public string UrlMaterial { get; set; }
    }
    public class Publicaciones
    {
        public int Id { get; set; }
        public string Titulo {get;set;}
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string Anexo { get; set; }

    }

    public class ObtenerEvento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }               
        public string Tipo { get; set; }
        public string Estado { get; set; }      
        public string Hora { get; set; }
        public string Ubicacion { get; set; }
        public string LogoEvento { get; set; }

        public List<Videos> listVideos { get; set; }
        public List<Ponentes> listPonentes {get;set;}
        public List<Materiales> ListMateriales { get; set; }
    }
    public class Submenu
    { 
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Url { get; set; }

    }
    public class EventoId
    {
        public int Id { get; set; }        

    }
    public class Login
    {
        public string usuario { get; set; }//correo
        public string clave { get; set; }

    }
    public class RptaLogin
    { 
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string mensaje { get; set; }
        public string correo { get; set; }
        public string nombres { get; set; }
        public string estado { get; set; }

    }
    public class User
    { 
        public int Id { get; set; }

        public string nombres { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string clavenueva { get; set; }

    }
    public class Favoritos
    { 
        public int IdEvento { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Fecha_ini { get; set; }
        public string Fecha_fin { get; set; }
        public string Fecha { get; set; }
    }
    public class enviarCorreo
    { 
        public string Correo { get; set; }
    }
    public class Obtenerfavorito
    { 
        public int IdUsuario { get; set; }
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
    }
    public class RptaObtenerfavorito
    { 
        public int codigo { get; set; }
        public string Mensaje { get; set; }
    }
    public class RptaUsuario
    {
        public int codigo { get; set; }
        public string Mensaje { get; set; }
    }
    public class ObtenerUsuario
    { 
        public string correo { get; set; }
        public string clave { get; set; }
    }
    public class BuscarEvento
    {
        public string Evento { get; set; }
        
    }
    public class RecuperarClave
    {
        public string Correo { get; set; }
    }
}
