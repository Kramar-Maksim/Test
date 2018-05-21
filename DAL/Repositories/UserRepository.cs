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
    public class UserRepository : IRepository<User>
    {
        private TestContext db;
        
        public UserRepository(TestContext context)
        {
            this.db = context;
        }
        
        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public async Task<User> Get(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
