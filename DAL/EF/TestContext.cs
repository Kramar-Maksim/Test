using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entitys;


namespace DAL.EF
{
    public class TestContext : DbContext
    {
        public DbSet<OptionalAnswer> OptionalAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }

        public TestContext() : base()
        {

        }
        public TestContext(string connectionString)
            : base(connectionString)
        {
        }
        
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext db)
        {
             
        }
    }
}
