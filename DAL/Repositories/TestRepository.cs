using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.EF;
using DAL.Entitys;
using System.Data.Entity;
using System.Threading.Tasks;

namespace  DAL.Repositories
{
    public class TestRepository : IRepository<Test>
    {
        private TestContext db;

        public TestRepository(TestContext context)
        {
            this.db = context;
        }

         

        public void Create(Test item)
        {
            db.Tests.Add(item);
        }

        public void Delete(int id)
        {
            Test OA = db.Tests.Find(id);
            if (OA != null)
                db.Tests.Remove(OA); 
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            return db.Tests.Where(predicate).ToList();
        }


        public async Task<Test> Get(int id)
        {
            return await db.Tests.FindAsync(id);
        }


        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }

        public void Update(Test item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
 
    }
}
