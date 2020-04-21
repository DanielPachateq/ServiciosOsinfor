using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
namespace BL
{
    public class EventosBL
    {
        private EventosDAL eventoDAL = new EventosDAL();
        public bool ObtenerEvento(int Id, ref Eventos evento)
        {
            return eventoDAL.Obtener(Id, ref evento);
        }
        public List<ListEventos> Listar(string titulo, int tipo)
        {
            return eventoDAL.Listar(titulo, tipo);
        }
        public List<Materiales> ListaMateriales(int Id)
        {
            return eventoDAL.ListaMateriales(Id);
        }
        public List<Ponentes> ListaPonentes(int Id)
        {
            return eventoDAL.ListaPonentes(Id);
        }
        public List<Videos> ListaVideos(int Id)
        {
            return eventoDAL.ListaVideos(Id);
        }

        public short InsertarFavoritos(Obtenerfavorito favorito, out string MsjError)
        {
            return eventoDAL.InsertarFavoritos(favorito, out MsjError);
        }
        public List<Favoritos> ListaFavoritos(int IdUsuario, string titulo)
        {
            return eventoDAL.ListaFavoritos(IdUsuario,titulo);
        }
        public bool EliminarFavorito(Obtenerfavorito obtenerfavorito)
        {
            return eventoDAL.EliminarFavorito(obtenerfavorito);
        }
        public bool Autentificarse(string username, string password, ref Usuario usuario)
        {
            return eventoDAL.Autentificarse(username, password, ref usuario);
        }
        public short InsertarUsuario(Usuario usuario, out string MsjError)
        {
            return eventoDAL.InsertarUsuario(usuario, out MsjError);
        }
        public bool ObtenerUsuario(string correo)
        {
            return eventoDAL.ObtenerUsuario(correo);
        }
        public bool RecuperarClave(string correo)
        {
            return eventoDAL.RecuperarClave(correo);
        }
    }
}
