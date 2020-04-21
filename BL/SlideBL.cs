using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
namespace BL
{
    public class SlideBL
    {
        private SlideDAL slideDAL = new SlideDAL();
        public List<Comunicados> Listar()
        {
            return slideDAL.Listar();
        }
    }
}
