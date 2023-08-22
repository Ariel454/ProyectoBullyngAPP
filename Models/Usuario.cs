using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBullying.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idCursoF { get; set; }
        public int rol { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public int genero { get; set; }
        public string correo { get; set; }
        public List<object> formularios { get; set; }
        public object idCursoFNavigation { get; set; }
        public List<object> mensajes { get; set; }
        public List<object> tests { get; set; }
    }
}
