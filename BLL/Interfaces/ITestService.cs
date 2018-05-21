using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        void CreateTest(TestDTO TestInstance);
        void EditTest(TestDTO TestInstance);
        void DeleteTest(TestDTO TestInstance);
        Task<TestDTO> GetTest(int? id);
        void UpdateTest(TestDTO TestInstance);

        IEnumerable<TestDTO> GetTests();

        void Dispose();
    }
}
