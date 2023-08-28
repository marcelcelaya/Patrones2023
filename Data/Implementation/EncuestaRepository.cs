using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class EncuestaRepository : IEncuestaRepository
    {
        public int Add(Encuesta entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer("Server=MARCELCELAYA\\;Database=EncuestaDb;Integrated Security=SSPI;TrustServerCertificate=true;")
                .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                ctx.Encuestas.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }
      
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Encuesta Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Encuesta entity)
        {
            throw new NotImplementedException();
        }
    }
}
