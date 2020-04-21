using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class SubmenuDAL
    {       
        public List<Submenu> Listar()
        {
            var submenus = new List<Submenu>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Submenu", con);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario

                            var submenu = new Submenu
                            {
                                Id = Convert.ToInt32(dr["ID"].ToString()),
                                Descripcion = dr["DESCRIPCION"].ToString().Trim(),
                                Imagen = dr["IMAGENURL"].ToString().Trim(),
                                Url = dr["URL"].ToString().Trim()                           
                            };

                            // Agregamos el usuario a la lista generica
                            submenus.Add(submenu);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return submenus;
        }
    }
}
