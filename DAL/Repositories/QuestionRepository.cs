using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.EF;
using DAL.Entitys;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private TestContext db;

        public QuestionRepository(TestContext context)
        {
            this.db = context;
        }


        public void Create(Question item)
        {
            db.Questions.Add(item);
        }

        public void Delete(int id)
        {
            Question quest = db.Questions.Find(id);
            if (quest != null)
                db.Questions.Remove(quest);
        }

        public async Task<Question> Get(int id)
        {
            return await db.Questions.FindAsync(id);
        }

        public void Update(Question item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }
    }
}
