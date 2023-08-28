using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        // public Byte[] Avatar { get; set; }
        public int UserType { get; set; }
        public List<Encuesta> Encuestas { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
