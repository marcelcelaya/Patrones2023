using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Encuesta
    {
        private string description;

        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get => description; set => description = value; }
        public int Color { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
        //Dejamos pendientelaImagen
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
