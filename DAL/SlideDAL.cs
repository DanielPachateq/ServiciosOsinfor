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
    public class SlideDAL
    {
        public List<Comunicados> Listar()
        {
            var comunicados = new List<Comunicados>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Comunicados", con);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario

                            var comunicado = new Comunicados
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                UrlImagen = dr["UrlImagen"].ToString().Trim()
                                
                            };

                            // Agregamos el usuario a la lista generica
                            comunicados.Add(comunicado);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return comunicados;
        }
    }
}
