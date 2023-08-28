using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Business.Contracts
{
    public interface IEncuestaService
    {

        //Create
        int Add(Encuesta enc);
        //Read
        Encuesta Get(int id);
        //Update
        bool Update(Encuesta enc);
        //Delete
        bool Delete(int id);
        List<Encuesta> GetSurveys(int idEncuesta);
    }
}
