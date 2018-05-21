using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IResultService
    {
        void CreateResult(ResultDTO resultDTO);
        // void EditOptAnsw(ResultDTO resultDTO);
        void DeleteResult(ResultDTO resultDTO);
        ResultDTO GetResult(ResultDTO resultDTO);

        IEnumerable<ResultDTO> GetResults();

        void Dispose();
    }
}
