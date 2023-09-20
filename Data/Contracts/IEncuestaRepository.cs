 using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IEncuestaRepository : IGenericRepository<Encuesta>
    {
        public List<Usuario> GetUsersFromSurvey(int surveyId);
        public bool RelateSurveyWithUser(int surveyId, int userId);
    }
}
