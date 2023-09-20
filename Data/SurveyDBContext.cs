using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SurveyDBContext : DbContext 
    {
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public SurveyDBContext(DbContextOptions<SurveyDBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MARCELCELAYA\\SQLEXPRESS;Database=EncuestaDb;Integrated Security=SSPI;TrustServerCertificate=true;");
        }
    }
}
