using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Encuesta
    {

        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Color { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
        //Dejamos pendientelaImagen
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Encuestas")]
        public List<Usuario> Usuarios { get; set; }
    }
}
