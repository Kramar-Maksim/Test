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
    class ResultRepository : IRepository<Result>
    {
        private TestContext db;

        public ResultRepository(TestContext context)
        {
            this.db = context;
        } 
        public void Create(Result item)
        {
            db.Results.Add(item);
        } 

        public void Delete(int id)
        {
            Result res = db.Results.Find(id);
            if (res != null)
                db.Results.Remove(res);
        } 

        public async Task<Result> Get(int id)
        {
            return await db.Results.FindAsync(id);
        } 

        public void Update(Result item)
        {
            db.Entry(item).State = EntityState.Modified;
        } 

        public IEnumerable<Result> Find(Func<Result, bool> predicate)
        {
            return db.Results.Where(predicate).ToList();
        }

        public IEnumerable<Result> GetAll()
        {
            return db.Results;
        } 
         
    }
}
