using System;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure; 
using DAL.Entitys;
using DAL.Interfaces;
using System.Collections.Generic;
using AutoMapper;


namespace BLL.Services
{
    public class ResultService : IResultService
    {
        IUnitOfWork Database { get; set; }

        public ResultService(IUnitOfWork item)
        {
            Database = item;
        }

        public void CreateResult(ResultDTO resultDTO)
        {
            Result res = new Result
            {
                Id = resultDTO.Id,
                TestId = resultDTO.Id_Test,
                UserId = resultDTO.User_Id,
                CheckedAnswers = resultDTO.CheckedAnswers,
                PassingDate = resultDTO.PassingDate,
                Performance = resultDTO.Performance,
                TotalWrongAnswers = resultDTO.TotalWrongAnswers,
                UncheckedAnswers = resultDTO.UncheckedAnswers
            };

            Database.Result.Create(res);
            Database.Save();
        }

        public void DeleteResult(ResultDTO resultDTO)
        {
            Database.Result.Delete(resultDTO.Id);
            Database.Save();
        }

        public ResultDTO GetResult(ResultDTO resultDTO)
        { 

            //Result res = Database.Result.Get(resultDTO.Id);

            //return res;


            throw new NotImplementedException();
        }

        public IEnumerable<ResultDTO> GetResults()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Result, ResultDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Result>, List<ResultDTO>>(Database.Result.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}