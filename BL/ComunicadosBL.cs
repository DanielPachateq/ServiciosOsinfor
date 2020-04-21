using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class ComunicadosBL
    {
        private ComunicadosDAL comunicadosDAL = new ComunicadosDAL();
        public bool Registrar(Comunicados comunicados)
        {
            return comunicadosDAL.Registrar(comunicados);
        }
        public List<Comunicados> ListaComunicados()
        {
            return comunicadosDAL.ListaComunicados();
        }
        public bool Eliminar(int id)
        {
            return comunicadosDAL.Eliminar(id);
        }
        public bool Obtener(int Id, ref Comunicados comunicados)
        {
            return comunicadosDAL.Obtener(Id, ref comunicados);
        }
        public bool Actualizar(int id, string Archivo)
        {
            return comunicadosDAL.Actualizar(id, Archivo);
        }
    }
}
