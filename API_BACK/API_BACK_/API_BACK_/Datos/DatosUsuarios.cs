using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using API_BACK.Models;
using SQL;

namespace API_BACK.Datos
{
    public class DatosUsuarios
    {
        public DataTable consultaUsuarios(Usuarios Usuario)
        {
            SqlParameter[] Parametros = new SqlParameter[] {

                        new SqlParameter("@id_usuarios", Usuario.id_usuarios)
                    };
            return Base.consultarDT(Base.ConexionCadena, "sp_consulta_usuarios", Parametros);

        }
        public string eliminaUsuario(Usuarios Usuario)
        {
            SqlParameter[] Parametros = new SqlParameter[] {
                        new SqlParameter("@id_usuarios", Usuario.id_usuarios)
            };
            return (string)Base.consultarScalar(Base.ConexionCadena, "sp_elimina_usuario", Parametros);

        }
        public string guardaUsuario(Usuarios Usuario)
        {
            SqlParameter[] Parametros = new SqlParameter[] {
                        new SqlParameter("@id_usuarios", Usuario.id_usuarios),
                        new SqlParameter("@nombre_usuario", Usuario.nombre_usuario),
                        new SqlParameter("@primer_apellido", Usuario.primer_apellido),
                        new SqlParameter("@segundo_apellido", Usuario.segundo_apellido),
                        new SqlParameter("@sexo", Usuario.sexo),
                        new SqlParameter("@activo", Usuario.activo)

            };
            return (string)Base.consultarScalar(Base.ConexionCadena, "sp_insertaActualiza_usuarios", Parametros);

        }
    }
}