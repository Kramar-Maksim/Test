using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<OptionalAnswer> OptionalAnswers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Result> Result { get; }
        IRepository<Test> Tests { get; } 
        IRepository<User> Users { get; }
         
        void Save();
    }
}
