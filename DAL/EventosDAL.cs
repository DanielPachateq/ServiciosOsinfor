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
    public class EventosDAL
    {
        public List<ListEventos> Listar(string tituloevento, int tipo)
        {
            var eventos = new List<ListEventos>();            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Eventos where titulo like '%" + tituloevento + "%' and tipo=" + tipo, con);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var evento = new ListEventos
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                Fecha_ini = dr["fecha_ini"].ToString().Trim(),
                                Fecha_fin = dr["fecha_fin"].ToString().Trim(),                                
                                Estado = dr["Estado"].ToString().Trim()//Publicado //Creado                                  
                            };
                            // Agregamos el usuario a la lista generica

                            if (evento.Fecha_ini == evento.Fecha_fin)
                            {
                                evento.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy");
                            }
                            else
                            {
                                evento.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy") + " - " + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("yyyy");
                            }

                            eventos.Add(evento);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eventos;
        }
        public List<Videos> ListaVideos(int Id)
        {
            var videos = new List<Videos>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM EventosVideos WHERE IDEVENTO=@IDEVENTO", con);
                    SqlParameter Prm;

                    Prm = query.Parameters.AddWithValue("@IDEVENTO", Id);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var video = new Videos
                            {
                                Id = Convert.ToInt32(dr["IdEvento"].ToString()),
                                IdVideo = Convert.ToInt32(dr["Idvideo"].ToString()),
                                urlVideo = dr["urlVideo"].ToString().Trim()
                                
                            };
                            // Agregamos el usuario a la lista generica
                            videos.Add(video);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return videos;
        }
        public List<Ponentes> ListaPonentes(int Id)
        {
            var ponentes = new List<Ponentes>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM EventosPonentes WHERE IDEVENTO=@IDEVENTO", con);
                    SqlParameter Prm;

                    Prm = query.Parameters.AddWithValue("@IDEVENTO", Id);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var ponente = new Ponentes
                            {
                                Id = Convert.ToInt32(dr["IdEvento"].ToString()),
                                IdPonente= Convert.ToInt32(dr["IdPonentes"].ToString()),
                                NombresApellidos = dr["NombresyApellidos"].ToString().Trim(),
                                Cargo = dr["Cargo"].ToString().Trim(),
                                Institucion = dr["Institucion"].ToString().Trim(),
                                Resena= dr["Reseña"].ToString().Trim(),
                                foto = dr["foto"].ToString().Trim()

                            };
                            // Agregamos el usuario a la lista generica
                            ponentes.Add(ponente);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ponentes;
        }
        public List<Materiales> ListaMateriales(int Id)
        {
            var materiales = new List<Materiales>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM EventosMateriales WHERE IDEVENTO=@IDEVENTO" , con);
                    SqlParameter Prm;

                    Prm = query.Parameters.AddWithValue("@IDEVENTO", Id);
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var material = new Materiales
                            {
                                Id = Convert.ToInt32(dr["Idevento"].ToString()),
                                IdMaterial = Convert.ToInt32(dr["IdMaterial"].ToString()),
                                UrlMaterial = dr["urlAdjunto"].ToString().Trim()
                               
                            };
                            // Agregamos el usuario a la lista generica
                            materiales.Add(material);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return materiales;
        }
        public bool Obtener(int Id, ref Eventos evento)
        {
            bool respuesta = false;
            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from eventos where id=@ID", con);
                    SqlParameter Prm;

                    Prm = query.Parameters.AddWithValue("@ID", Id);
                    
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        string mes = "";
                        dr.Read();
                        if (dr.HasRows)
                        {
                            evento.Id = Convert.ToInt32(dr["Id"].ToString());
                            evento.Titulo = dr["Titulo"].ToString().Trim();
                            evento.Estado = dr["Estado"].ToString().Trim();
                            evento.Tipo = dr["Tipo"].ToString().Trim();
                            evento.Ubicacion = dr["Ubicacion"].ToString().Trim();
                            evento.Fecha_ini = dr["Fecha_ini"].ToString().Trim();
                            evento.Fecha_fin = dr["Fecha_fin"].ToString().Trim();
                            evento.Hora_Ini = dr["Hora_ini"].ToString().Trim();
                            evento.Hora_Fin = dr["Hora_fin"].ToString().Trim();
                            evento.Descripcion = dr["Descripcion"].ToString().Trim();
                            evento.LogoEvento = dr["LogoEvento"].ToString().Trim();

                            //mes = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM");
                            if (evento.Fecha_ini == evento.Fecha_fin)
                            {
                                evento.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) +','+ Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy");
                            }
                            else
                            {
                                evento.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) + ','+ Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy") + " - " + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("dd") + " "+ Mes(Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("yyyy");
                            }
                            respuesta = true;                                                
                        }
                        else
                        {
                            respuesta = false;
                        }

                    }                  

                    con.Close();

                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return respuesta;
        }

        public short InsertarFavoritos(Obtenerfavorito favorito, out string MsjError)
        {
            short _return = 0;
            string SQL;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
            {

                SqlCommand Cmd;
                SqlTransaction Trn;
                con.Open();

                Trn = con.BeginTransaction();

                MsjError = "Existe";
                try
                {
                    SQL = "INSERT INTO Favoritos (idEvento,idUsuario,Titulo,Fecha) VALUES(@idEvento, @idUsuario,@Titulo,@Fecha)";
                    Cmd = new SqlCommand(SQL, con, Trn);

                    SqlParameter Prm;
                    Prm = Cmd.Parameters.Add("@idEvento",System.Data.SqlDbType.Int);
                    Prm.Value = favorito.IdEvento;
                    Prm = Cmd.Parameters.Add("@idUsuario",System.Data.SqlDbType.Int);
                    Prm.Value = favorito.IdUsuario;
                    Prm = Cmd.Parameters.Add("@Titulo",System.Data.SqlDbType.Char);
                    Prm.Value = "";
                    Prm = Cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.Char);
                    Prm.Value = "";                   
                    Cmd.ExecuteNonQuery();
                    Cmd.Transaction.Commit();
                    MsjError = "Se agrego a favoritos";
                }
                catch (Exception ex)
                {
                    _return = -1;
                    MsjError = ex.Message;
                }
                con.Close();
            }

            return _return;
        }

        public List<Favoritos> ListaFavoritos(int IdUsuario, string titulo)
        {
            var favoritos = new List<Favoritos>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select a.IdEvento, a.IdUsuario, b.Titulo, b.Fecha_ini, b.Fecha_fin from favoritos a join Eventos b on a.IdEvento= b.Id  where a.idUsuario=@IdUsuario and b.Titulo like '%"+ titulo +"%'", con);
                    SqlParameter Prm;
                    Prm = query.Parameters.AddWithValue("@IdUsuario", IdUsuario);                    
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var favorito = new Favoritos
                            {
                                IdEvento = Convert.ToInt32(dr["IdEvento"].ToString()),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                Fecha_ini = dr["Fecha_ini"].ToString().Trim(),
                                Fecha_fin = dr["Fecha_fin"].ToString().Trim()                                                                 
                            };
                            // Agregamos el usuario a la lista generica

                            if (favorito.Fecha_ini == favorito.Fecha_fin)
                            {
                                favorito.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy");
                            }
                            else
                            {
                                favorito.Fecha = Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_ini"].ToString().Trim()).ToString("yyyy") + " - " + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("dd") + " " + Mes(Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("MM")) + ',' + Convert.ToDateTime(dr["fecha_fin"].ToString().Trim()).ToString("yyyy");
                            }

                            favoritos.Add(favorito);
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return favoritos;
        }
        public bool EliminarFavorito(Obtenerfavorito obtenerfavorito)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("delete favoritos where idevento=@IDEVENTO and idUsuario=@IDUSUARIO", con);
                    SqlParameter Prm;

                    Prm = cmd.Parameters.Add("@IDEVENTO", System.Data.SqlDbType.Int);
                    Prm.Value = obtenerfavorito.IdEvento;
                    Prm = cmd.Parameters.Add("@IDUSUARIO", System.Data.SqlDbType.Int);
                    Prm.Value = obtenerfavorito.IdUsuario;

                    cmd.ExecuteNonQuery();

                    respuesta = true;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool Autentificarse(string username, string password, ref Usuario usuario)
        {
            bool respuesta = false;
            //var usuarios = new Usuario();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM USUARIO WHERE CORREO=@CORREO and CLAVE=@CLAVE", con);
                    SqlParameter Prm;
                    Prm = query.Parameters.AddWithValue("@CORREO", username.ToString().Trim().ToUpper());
                    Prm = query.Parameters.AddWithValue("@CLAVE", password.ToString().Trim());

                    //query.ExecuteNonQuery();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            
                            usuario.Codigo = Convert.ToInt32(dr["IDUSUARIO"]);//CODIGO DEL NODO							
                            usuario.Nombres = dr["NOMBRES"].ToString().Trim();   
                            usuario.username = dr["CORREO"].ToString().Trim();
                            usuario.password = dr["CLAVE"].ToString().Trim();
                            respuesta = true;
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }
                    con.Close();                                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
        public bool ObtenerUsuario(string correo)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM USUARIO WHERE CORREO=@CORREO", con);
                    SqlParameter Prm;                    
                    Prm = query.Parameters.AddWithValue("@CORREO", correo.ToString().Trim().ToUpper());                    

                    //query.ExecuteNonQuery();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {                           
                            respuesta = true;
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }
                   
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
        public short InsertarUsuario(Usuario usuario, out string MsjError)
        {
            short _return = 0;
            string SQL;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
            {

                long numerador = 0;
                con.Open();
                var cmd = new SqlCommand("SELECT MAX(idUsuario) FROM Usuario", con);

                SqlDataReader Reader;

                Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    numerador = Convert.ToInt64(Reader[0].ToString().Trim()) + 1;
                }
                else
                {
                    numerador = 0;
                }
                con.Close();

                SqlCommand Cmd;
                SqlTransaction Trn;
                con.Open();


                Trn = con.BeginTransaction();

                MsjError = "Existe";
                try
                {
                    SQL = "INSERT INTO Usuario (idUsuario,Nombres,Correo,Clave,ClaveNueva) VALUES(@idUsuario, @Nombres,@Correo,@Clave,@ClaveNueva)";
                    Cmd = new SqlCommand(SQL, con, Trn);

                    SqlParameter Prm;
                    Prm = Cmd.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int);
                    Prm.Value =numerador;
                    Prm = Cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.Char);
                    Prm.Value = usuario.Nombres.ToUpper();
                    Prm = Cmd.Parameters.Add("@Correo", System.Data.SqlDbType.Char);
                    Prm.Value = usuario.username.ToUpper();
                    Prm = Cmd.Parameters.Add("@Clave", System.Data.SqlDbType.Char);
                    Prm.Value = usuario.password;
                    Prm = Cmd.Parameters.Add("@ClaveNueva", System.Data.SqlDbType.Char);
                    Prm.Value = usuario.password;
                    Cmd.ExecuteNonQuery();
                    Cmd.Transaction.Commit();
                    MsjError = "Se realizo el registro";
                }
                catch (Exception ex)
                {
                    _return = 1;
                    MsjError = ex.Message;
                }
                con.Close();
            }

            return _return;
        }
        public string Mes(string idmes)
        {
            string mes = "";

            if (idmes == null)
            {
                idmes = "0000";
            }

            switch (idmes.ToString())
            {
                case "01":
                    mes = "Enero";
                    break;
                case "02":
                    mes = "Febrero";
                    break;
                case "03":
                    mes = "Marzo";
                    break;
                case "04":
                    mes = "Abril";
                    break;
                case "05":
                    mes = "Mayo";
                    break;
                case "06":
                    mes = "Junio";
                    break;
                case "07":
                    mes = "Julio";
                    break;
                case "08":
                    mes = "Agosto";
                    break;
                case "09":
                    mes = "Septiembre";
                    break;
                case "10":
                    mes = "Octubre";
                    break;
                case "11":
                    mes = "Noviembre";
                    break;
                case "12":
                    mes = "Diciembre";
                    break;
                case "0000":
                    mes = "";
                    break;
            }
            return mes;
        }
        public bool RecuperarClave(string correo)
        {
            bool respuesta = false;
            string cuerpo = "";
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM USUARIO WHERE CORREO=@CORREO", con);
                    SqlParameter Prm;
                    Prm = query.Parameters.AddWithValue("@CORREO", correo.ToString().Trim().ToUpper());

                    //query.ExecuteNonQuery();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        dr.Read();
                        Usuario usuario = new Usuario();
                        if (dr.HasRows)
                        {
                            usuario.Nombres = dr["Nombres"].ToString().Trim();
                            usuario.password = dr["Clave"].ToString().Trim();
                            respuesta = true;

                            cuerpo = "<html><body><b>" + usuario.Nombres + "</b>,<br>";
                            cuerpo = cuerpo + "Tu clave para acceder al App de Eventos es:<b>" + usuario.password + "</b></body></html>";
                            EjecutarSPEnvioCorreo(correo, cuerpo);
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }


                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
        public void EjecutarSPEnvioCorreo(string correo, string cuerpo)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
                {
                    SqlCommand cmd;
                    con.Open();

                    cmd = new SqlCommand("SP_ENVIO_CORREO", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter Prm;
                    Prm = cmd.Parameters.Add("@CORREO", System.Data.SqlDbType.Char);
                    Prm.Value = correo;
                    Prm = cmd.Parameters.Add("@CUERPO", System.Data.SqlDbType.Char);
                    Prm.Value = cuerpo;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
        }
    }
}
