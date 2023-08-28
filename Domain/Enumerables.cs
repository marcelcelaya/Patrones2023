using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    enum UserType{
        Encuestador,
        Encuestado
    }
    enum QuestionType
    {
        OpcionMultiple,
        OpcionUnica,
        Abierta,
        VerdaderoFalso
    }
}
