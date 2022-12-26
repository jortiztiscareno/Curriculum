using System.Data;
using System.Web.Http;
using API_BACK.Datos;
using API_BACK.Models;
namespace API_BACK.Controllers
{
    public class UsuariosController : ApiController
    {
        DatosUsuarios datosUsuario = new DatosUsuarios();

        [HttpGet]
        public DataTable Get(int id_usuario)
        {
            return datosUsuario.consultaUsuarios(new Usuarios { id_usuarios = id_usuario });
        }
        [HttpPost]
        public string Post(Usuarios Usuario)
        {
            Usuarios Usr = new Usuarios();
            Usr.id_usuarios = Usuario.id_usuarios;
            Usr.nombre_usuario = Usuario.nombre_usuario;
            Usr.primer_apellido = Usuario.primer_apellido;
            Usr.segundo_apellido = Usuario.segundo_apellido;
            Usr.sexo = Usuario.sexo;
            Usr.activo = Usuario.activo;
            datosUsuario.guardaUsuario(Usr);
            return "OK INSERTADO";
            
        }
        [HttpPut]
        public string Put(Usuarios UsuarioA)
        {
            Usuarios Usr = new Usuarios();
            Usr.id_usuarios = UsuarioA.id_usuarios;
            Usr.nombre_usuario = UsuarioA.nombre_usuario;
            Usr.primer_apellido = UsuarioA.primer_apellido;
            Usr.segundo_apellido = UsuarioA.segundo_apellido;
            Usr.sexo = UsuarioA.sexo;
            Usr.activo = UsuarioA.activo;
            datosUsuario.guardaUsuario(Usr);
            return "OK ACTUALIZADO";
        }

        [HttpPost]
        public string Post(int id_usuarioE)
        {
            datosUsuario.eliminaUsuario(new Usuarios { id_usuarios = id_usuarioE });
            return "Eliminado";
        }
    }
}
