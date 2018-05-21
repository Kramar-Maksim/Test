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
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }
                
        public QuestionService(IUnitOfWork item)
        {
            Database = item; 
        }
         
 
        public void AddQuestion(QuestionsDTO questDTO)
        {
            Question quest = new Question
            {
           //     Id = questDTO.DTO_Id,
               // Id_Test = questDTO.Id_Test,
           //     QuestionText = questDTO.DTO_QuestionText,
              //  Answer_Id = questDTO.Answer_Id
            };

            Database.Questions.Create(quest);
            Database.Save();
        }

        public void RemoveQuestion(QuestionsDTO questDTO)
        {
            Database.Questions.Delete(questDTO.Id);
            Database.Save(); 
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<QuestionsDTO> GetQuestions()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Question>, List<QuestionsDTO>>(Database.Questions.GetAll());

            //  List<QuestionsDTO> ls = new List<QuestionsDTO>(Database.Questions.GetAll();

            //IEnumerable<QuestionsDTO> QuestDTOList = Database.Questions.GetAll();

            //List<Question> QuestList = new List<Question>();

            //foreach (var item in QuestDTOList)
            //{
            //    QuestList.Add(new Question()
            //    {
            //        Id = item.Id,
            //        Answer_Id = item.Answer_Id,
            //        Id_Test = item.Id_Test
            //    }; 
            //}
            //return (IEnumerable)QuestList;
        }

        public void EditQUestion(QuestionsDTO questDTO)
        {
            throw new NotImplementedException();
        }
    }
}