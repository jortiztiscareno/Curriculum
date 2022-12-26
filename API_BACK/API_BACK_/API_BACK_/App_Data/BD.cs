using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SQL
{
	public abstract class Base
	{
		public static string ConexionCadena = ConfigurationManager.ConnectionStrings["ConexionCadena"].ToString();
		public static DataTable consultarDT(string connectionString, string cmdText)
		{
			DataTable tabla = null;
			using (SqlConnection conexion = new SqlConnection(connectionString))
			{
				try
				{
					conexion.Open();
					DataSet ds = new DataSet();
					SqlDataAdapter adapter = new SqlDataAdapter();
					adapter.SelectCommand = new SqlCommand(cmdText, conexion);
					adapter.Fill(ds);
					tabla = ds.Tables[0];
				}
				catch (Exception)
				{
					return null;
				}
			}
			return tabla;
		}
		public static object consultarScalar(string cadenaConexion, string procedimientoAlmacenado, SqlParameter[] parametros, int Tiempo = 160)
		{
			using (SqlConnection conexion = new SqlConnection(cadenaConexion))
			{
				conexion.Open();
				SqlCommand comando = new SqlCommand();
				comando.Connection = conexion;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = procedimientoAlmacenado;

				if (parametros != null)
				{
					for (int indice = 0; indice < parametros.Length; indice++)
					{
						comando.Parameters.Add(parametros[indice]);
					}
				}
				object resultados = comando.ExecuteScalar();

				return resultados;
			}
		}
		public static DataTable consultarDT(string cadenaConexion, string procedimientoAlmacenado, SqlParameter[] parametros, int Tiempo = 160)
		{
			DataTable tabla = null;
			using (SqlConnection conexion = new SqlConnection(cadenaConexion))
			{
				conexion.Open();
				SqlCommand comando = new SqlCommand();
				comando.Connection = conexion;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandTimeout = Tiempo;
				comando.CommandText = procedimientoAlmacenado;

				if (parametros != null)
				{
					for (int indice = 0; indice < parametros.Length; indice++)
					{
						comando.Parameters.Add(parametros[indice]);
					}
				}

				SqlDataAdapter adaptador = new SqlDataAdapter();
				adaptador.SelectCommand = comando;
				DataSet ds = new DataSet();
				adaptador.Fill(ds, "Tabla");

				tabla = ds.Tables["Tabla"];
			}

			return tabla;
		}
	}
}
