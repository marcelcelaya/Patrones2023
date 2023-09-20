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
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
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
            if (id <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Helpers.Constants.ConnectionString)
             .Options;
            Encuesta enc;
            bool deleted = false;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                //Return Id, Name, etc FROM Encuesta WHERE x.Id => Id LIMIT 1
                enc = ctx.Encuestas.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.Encuestas.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public Encuesta Get(int id)
        {
            if (id <= 0) return null;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Helpers.Constants.ConnectionString)
             .Options;
            Encuesta enc;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                //Return Id, Name, etc FROM Encuesta WHERE x.Id => Id LIMIT 1
                enc = ctx.Encuestas.Where(x => x.Id == id).FirstOrDefault();
            }
            return enc;

        }

        public List<Usuario> GetUsersFromSurvey(int surveyId)
        {
            if (surveyId <= 0) return null;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Helpers.Constants.ConnectionString)
             .Options;
            var users = new List<Usuario>();
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                users = ctx
                    .Encuestas
                    .Where(s => s.Id == surveyId)
                    .SelectMany(e => e.Usuarios).ToList();
            }
            return users;
        }

        public bool RelateSurveyWithUser(int surveyId, int userId)
        {
            if (surveyId <= 0) return false;
            if (userId <= 0) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Helpers.Constants.ConnectionString)
             .Options;
            try
            {
                using (var ctx = new SurveyDBContext(options: connectionOptions))
                {
                    //Entity Framework por default funciona con Lazy Loading, por lo cual,
                    //Por default no incluye las tablas relacionadas.
                    //Necesitamos Usar el metodo include para decirle que se traiga la informacion
                    //De la tabla relacionada que queremos.
                    var user = ctx.Usuarios.Include(a=> a.Encuestas).FirstOrDefault(u => u.Id == userId);
                    var survey = ctx.Encuestas.FirstOrDefault(s => s.Id == surveyId);
                    if (user != null && survey != null)
                    {
                        user.Encuestas.Add(survey);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(Encuesta entity)
        {
            if (entity == null) return false;
            if (entity.Id <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
            .UseSqlServer(Helpers.Constants.ConnectionString)
            .Options;
            try
            {
                using (var ctx = new SurveyDBContext(options: connectionOptions))
                {
                    Encuesta enc = ctx.Encuestas.Where(x => x.Id == entity.Id).FirstOrDefault();
                    enc.Title = entity.Title;
                    enc.Description = entity.Description;
                    enc.Color = entity.Color;
                    enc.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}