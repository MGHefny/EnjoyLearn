using learnApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//service function for Instractours
namespace learnApp.services
{
    public interface ITrainerService
    {
        int Creat(instractor trainer);
        instractor FindByEmail(string Email);
        instractor ReadById(int Id);
        IEnumerable<instractor> ReadAll();
    }
    public class TrainerService : ITrainerService
    {
        private readonly enjoy_learn_DBEntities db;
        public TrainerService()
        {
            db = new enjoy_learn_DBEntities();
        }
        public int Creat(instractor trainer)
        {
            var existsTrainer = FindByEmail(trainer.email);
            if(existsTrainer != null)
            {
                return -2;
            }
            trainer.creation_date = DateTime.Now;
            db.instractors.Add(trainer);
            return db.SaveChanges();

            throw new NotImplementedException();
        }

        public instractor FindByEmail(string Email)
        {
            return db.instractors.Where(t => t.email == Email).FirstOrDefault();
        }

        public IEnumerable<instractor> ReadAll()
        {
            return db.instractors;
        }

        public instractor ReadById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}