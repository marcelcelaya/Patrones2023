using Business.Contracts;
using Data.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class EncuestaService : IEncuestaService
    {
        private readonly IEncuestaRepository _encuestaRepo;

        public EncuestaService(IEncuestaRepository encuestaRepo)
        {
            _encuestaRepo = encuestaRepo;
        }

        public int Add(Encuesta enc)
        {
            if (enc == null) return 0;
            return _encuestaRepo.Add(enc);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Encuesta Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Encuesta> GetSurveys(int idEncuesta)
        {
            throw new NotImplementedException();
        }

        public bool Update(Encuesta enc)
        {
            throw new NotImplementedException();
        }
    }
}
