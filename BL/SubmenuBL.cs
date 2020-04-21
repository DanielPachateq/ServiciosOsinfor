using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
namespace BL
{
    public class SubmenuBL
    {
        
        private SubmenuDAL submenuDAL = new SubmenuDAL();
        public List<Submenu> Listar()
        {
            return submenuDAL.Listar();
        }
    }
}
