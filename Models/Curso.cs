using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBullying.Models
{
    public class Curso
    {
        public int idCurso { get; set; }
        public int idInstitucionF { get; set; }
        public int nivel { get; set; }
        public string paralelo { get; set; }
        public object idInstitucionFNavigation { get; set; }
        public List<object> usuarios { get; set; }
    }

}
