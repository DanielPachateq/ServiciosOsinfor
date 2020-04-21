using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Entidades;
using System.Data.SqlClient;

namespace DAL
{
    public class ComunicadosDAL
    {
		/// <summary>
		/// Registro de Imagen de inicio
		/// </summary>
		/// <param name="comunicados"></param>
		/// <returns></returns>
		public bool Registrar(Comunicados comunicados)
		{

			bool respuesta = false;

			SqlTransaction Trn;

			try
			{
				using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
				{
					con.Open();
					Trn = con.BeginTransaction();

					var cmd = new SqlCommand("INSERT INTO Comunicados(UrlImagen)VALUES(@UrlImagen)", con, Trn);

					SqlParameter Prm;

					Prm = cmd.Parameters.Add("@urlImagen", SqlDbType.VarChar);
					Prm.Value = comunicados.UrlImagen.Trim();

					cmd.ExecuteNonQuery();
					cmd.Transaction.Commit();

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
		/// <summary>
		/// Lista de Imagenes de Inicio
		/// </summary>
		/// <returns></returns>
		public List<Comunicados> ListaComunicados()
		{
			var comunicados = new List<Comunicados>();
			try
			{
				using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
				{
					con.Open();
					var cmd = new SqlCommand("SELECT id, UrlImagen FROM Comunicados", con);
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							var comunicado = new Comunicados
							{
								Id = Convert.ToInt32(dr["ID"].ToString()),
								UrlImagen = dr["URLIMAGEN"].ToString().Trim(),
							};
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
		/// <summary>
		/// Eliminar un registro de Pantalla inicio
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Eliminar(int id)
		{
			bool respuesta = false;
			SqlTransaction Trn;
			try
			{
				using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
				{
					con.Open();
					Trn = con.BeginTransaction();
					var query = new SqlCommand("DELETE Comunicados where id=@ID", con, Trn);
					query.Parameters.AddWithValue("@ID", id);
					query.ExecuteNonQuery();
					query.Transaction.Commit();
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
		/// <summary>
		/// Obtener registro de lista de Inicio
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="comunicados"></param>
		/// <returns></returns>
		public bool Obtener(int Id, ref Comunicados comunicados)
		{
			bool respuesta = false;
			try
			{
				using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
				{
					con.Open();
					var query = new SqlCommand("SELECT id, UrlImagen FROM Comunicados WHERE ID=@ID", con);
					SqlParameter Prm;
					Prm = query.Parameters.AddWithValue("@ID", Id);
					using (SqlDataReader dr = query.ExecuteReader())
					{
						dr.Read();
						if (dr.HasRows)
						{
							comunicados.Id = Convert.ToInt32(dr["Id"].ToString());
							comunicados.UrlImagen = dr["urlImagen"].ToString().Trim();
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
		public bool Actualizar(int id, string Archivo)
		{
			bool respuesta = false;
			SqlTransaction Trn;
			try
			{
				using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSQL"].ToString()))
				{
					con.Open();
					Trn = con.BeginTransaction();
					var query = new SqlCommand("UPDATE Comunicados SET urlImagen=@URLIMAGEN where id=@ID", con, Trn);
					query.Parameters.AddWithValue("@ID", id);
					query.Parameters.AddWithValue("@URLIMAGEN", Archivo);
					query.ExecuteNonQuery();
					query.Transaction.Commit();
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
	}
}
