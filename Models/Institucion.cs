using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBullying.Models
{
    public class Institucion
    {
        public int idInstitucion { get; set; }
        public string nombre { get; set; }
        public string logo { get; set; }
        public string info { get; set; }
        public List<object> cuentos { get; set; }
        public List<object> cursos { get; set; }
        public List<object> informacions { get; set; }
    }
}
