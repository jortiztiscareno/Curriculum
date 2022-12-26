using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_BACK.Models
{
    public class Usuarios
    {
        public int id_usuarios { get; set; }
        public string nombre_usuario { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string sexo { get; set; }
        public int activo { get; set; }
    }
}