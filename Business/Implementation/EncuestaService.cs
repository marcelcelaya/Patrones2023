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
            if (id <= 0) return false;
            return _encuestaRepo.Delete(id);
        }

        public Encuesta Get(int id)
        {
            if (id <= 0) return null;
            return _encuestaRepo.Get(id);
        }

        public List<Encuesta> GetSurveys(int idEncuesta)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsersFromSurvey(int surveyId)
        {
            if (surveyId <= 0) return null;
            return _encuestaRepo.GetUsersFromSurvey(surveyId);
        }

        public bool RelateSurveyWithUser(int surveyId, int userId)
        {
            if (surveyId <= 0) return false;
            if (userId <= 0) return false;
            return _encuestaRepo.RelateSurveyWithUser(surveyId, userId);
        }

        public bool Update(Encuesta enc)
        {
            if (enc == null) return false;
            if (enc.Id <= 0) return false;
            return _encuestaRepo.Update(enc);
        }
    }
}
