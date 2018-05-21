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
    public class OptionalAnswerService : IOptionalAnswerService
    {
        IUnitOfWork Database { get; set; }

        public OptionalAnswerService(IUnitOfWork item)
        {
            Database = item; 
        }

        public void CreateAnswer(OptionalAnswerDTO OptAnswDataTraObj)
        {
            //Question question = Database.Questions.Get(OptAnswDataTraObj.Id_Question);
             
            //if(question == null)                                                                          // check this under comments
            //    throw new ValidationException("Question not found", "");

            OptionalAnswer OA = new OptionalAnswer
            {
                
                Id = OptAnswDataTraObj.Id,
              //  Id_Test = OptAnswDataTraObj.Id_Test,
              //  Id_Question = OptAnswDataTraObj.Id_Question,
                OptionAnswer = OptAnswDataTraObj.OptionAnswer,
              //  Question = question
            };
            

           ///////////////// Database.OptionalAnswers.Create(OA);
           ///////////////// Database.Save();
        }

        public void DeleteOptAnsw(OptionalAnswerDTO OptAnswDataTraObj)
        {
            Database.OptionalAnswers.Delete(OptAnswDataTraObj.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditOptAnsw(OptionalAnswerDTO OptAnswDataTraObj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OptionalAnswerDTO> GetOptionalAnswers()
        {  
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OptionalAnswer, OptionalAnswerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OptionalAnswer>, List<OptionalAnswerDTO>>(Database.OptionalAnswers.GetAll());
        }

      
    }
}
