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
    public class OptionalAnswerRepository : IRepository<OptionalAnswer>
    {
        private TestContext db;

        public OptionalAnswerRepository(TestContext context)
        {
            this.db = context;
        }


        public void Create(OptionalAnswer item)
        {
            db.OptionalAnswers.Add(item);
        }

        public void Delete(int id)
        {
            OptionalAnswer OA = db.OptionalAnswers.Find(id);
            if (OA != null)
                db.OptionalAnswers.Remove(OA);
        }

        public IEnumerable<OptionalAnswer> Find(Func<OptionalAnswer, bool> predicate)
        {
            return db.OptionalAnswers.Where(predicate).ToList();
        }

        public async Task<OptionalAnswer> Get(int id)
        {
            return await db.OptionalAnswers.FindAsync(id);
        }

        public IEnumerable<OptionalAnswer> GetAll()
        {
            return db.OptionalAnswers;
        }

        public void Update(OptionalAnswer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
