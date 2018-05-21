using System;
using DAL.Interfaces;
using DAL.EF;
using DAL.Entitys;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TestContext db;

        private OptionalAnswerRepository optionalAnswerRepository;
        private QuestionRepository questRepository;
        private TestRepository testRepository;
        private UserRepository userRepository;
        private ResultRepository resultRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new TestContext(connectionString);
        }

        public IRepository<OptionalAnswer> OptionalAnswers
        {
            get
            {
                if (optionalAnswerRepository == null)
                    optionalAnswerRepository = new OptionalAnswerRepository(db);
                return optionalAnswerRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questRepository == null)
                    questRepository = new QuestionRepository(db);
                return questRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Result> Result
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(db);
                return resultRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
