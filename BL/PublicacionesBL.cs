using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class PublicacionesBL
    {
        private PublicacionesDAL publicacionDAL = new PublicacionesDAL();
        public List<Publicaciones> Listar()
        {
            return publicacionDAL.Listar();
        }       
    }
}
