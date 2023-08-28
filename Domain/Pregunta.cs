using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pregunta
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public bool Obligatoria { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public int TipoDePregunta { get; set; }
        //Imagen Pendiente
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
