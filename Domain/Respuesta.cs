using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Respuesta
    {
        public int Id { get; set; }
        public String Texto { get; set; }
        public Usuario Usuario { get; set; }
        public String TipoDeRespuesta { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
