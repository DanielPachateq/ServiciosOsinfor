using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;
namespace DAL
{
    public class PublicacionesDAL
    {
        public List<Publicaciones> Listar()
        {
            var publicaciones = new List<Publicaciones>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM publicaciones", con);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario

                            var publicacion = new Publicaciones
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                Autor = dr["Autor"].ToString().Trim(),
                                Descripcion = dr["Descripcion"].ToString().Trim(),
                                Anexo = dr["Anexo"].ToString().Trim()
                                
                            };
                            // Agregamos el usuario a la lista generica
                            publicaciones.Add(publicacion);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return publicaciones;
        }
    }
}
