using System;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure; 
using DAL.Entitys;
using DAL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork item)
        {
            Database = item;
        }
 
        public Test ConvertDTOtoDALTest(TestDTO TestInstance)
        {
            Test testTemp = new Test();
            List<Question> QuestionList = new List<Question>();
            List<OptionalAnswer> AnswersList;

            foreach (var Questions in TestInstance.Questions)
            {
                AnswersList = new List<OptionalAnswer>();

                foreach (var Answers in Questions.OptionalAnswers)
                {
                    AnswersList.Add(new OptionalAnswer()
                    {
                        OptionAnswer = Answers.OptionAnswer,
                        TrueAnswer = Answers.TrueAnswer 
                    });
                }
                QuestionList.Add(new Question()
                {
                    QuestionText = Questions.QuestionText, 
                    OptionalAnswers = AnswersList
                });
            }
            testTemp.Description = TestInstance.Description;
            testTemp.Questions = QuestionList;

            return testTemp;
        }
        public TestDTO ConvertTESTtoTestDTO(Test TestInstance)
        {
            TestDTO testTemp = new TestDTO();
            List<QuestionsDTO> QuestionList = new List<QuestionsDTO>();
            List<OptionalAnswerDTO> AnswersList;

            foreach (var Questions in TestInstance.Questions)
            {
                AnswersList = new List<OptionalAnswerDTO>();

                foreach (var Answers in Questions.OptionalAnswers)
                {
                    AnswersList.Add(new OptionalAnswerDTO()
                    {
                        OptionAnswer = Answers.OptionAnswer,
                        TrueAnswer = Answers.TrueAnswer
                    });
                }
                QuestionList.Add(new QuestionsDTO()
                {
                    QuestionText = Questions.QuestionText,
                    //RealAnswer_Id = Questions.RealAnswer_Id,
                    OptionalAnswers = AnswersList
                });
            }
            testTemp.Description = TestInstance.Description;
            testTemp.Questions = QuestionList;

            return testTemp;
        }


        public void CreateTest(TestDTO TestInstance)
        {
            Test testTemp = ConvertDTOtoDALTest(TestInstance);

            Database.Tests.Create(testTemp);

            foreach (var item in testTemp.Questions)
            {
                Database.Questions.Create(item);
                foreach (var item1 in item.OptionalAnswers)
                {
                    Database.OptionalAnswers.Create(item1);
                }
            }

            Database.Save();
        }

        public async void EditTest(TestDTO TestInstance)
        {
            Test curentTest = ConvertDTOtoDALTest(TestInstance);

            Database.Tests.Update(curentTest);
            
        }

        public async Task<TestDTO> GetTest(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Test", "");

            IEnumerable<TestDTO> TestsList = GetTests();         //ads refs to curent test xz how DO NOT DELL IT, Intitial DataBase
            Test curentTest = await Database.Tests.Get(id.Value);     //returns DAL Test with a given ID, but      WITOUT referents or with?? ref are here      to other tabels need to convert to DTO


            if (curentTest == null)
                throw new ValidationException("curentTest не найден", "");


            return ConvertTESTtoTestDTO(curentTest);            //Convert to DTO and return
        }

        public void DeleteTest(TestDTO TestInstance)
        {
            #region
            // працює з звязаними таблицями
            //IEnumerable<Question> AllQuestions = Database.Questions.GetAll();
            //IEnumerable<OptionalAnswer> AllAnswers = Database.OptionalAnswers.GetAll();

            //List<Question> QuestionsForDelete = new List<Question>();
            //List<OptionalAnswer> AnswersForDelete = new List<OptionalAnswer>();



            //foreach (var item1 in AllQuestions)
            //{
            //    if (item1.TestId == testTemp.Id)
            //    {
            //        QuestionsForDelete.Add(item1);

            //    }
            //}
            //foreach (var item in QuestionsForDelete )
            //{
            //    foreach (var item1 in AllAnswers)
            //    {
            //        if (item1.QuestionId == item.Id)
            //            AnswersForDelete.Add(item1);
            //    } 
            //}

            //////////////////////////////////////////////////////
            //foreach (var item in AnswersForDelete)
            //{
            //    Database.OptionalAnswers.Delete(item.Id);
            //}
            //foreach (var item in QuestionsForDelete)
            //{
            //    Database.Questions.Delete(item.Id);
            //} 
            ///////////////////////////////////////////////////////
            #endregion

            Database.Tests.Delete(TestInstance.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TestDTO> GetTests()
        {
            // применяем автомаппер для проекции одной коллекции на другую 

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            var testsMaped = mapper.Map<IEnumerable<Test>, List<TestDTO>>(Database.Tests.GetAll());

            var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionsDTO>()).CreateMapper();
            var questMaped = mapper1.Map<IEnumerable<Question>, List<QuestionsDTO>>(Database.Questions.GetAll());

            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<OptionalAnswer, OptionalAnswerDTO>()).CreateMapper();
            var answersMaped = mapper2.Map<IEnumerable<OptionalAnswer>, List<OptionalAnswerDTO>>(Database.OptionalAnswers.GetAll());


            List<TestDTO> TestList = new List<TestDTO>();
            List<QuestionsDTO> QuestList;
            List<OptionalAnswerDTO> AnswerList;

            foreach (var test in testsMaped)
            {
                QuestList = new List<QuestionsDTO>();
                foreach (var quest in questMaped)
                {
                    AnswerList = new List<OptionalAnswerDTO>();
                    foreach (var answer in answersMaped)
                    {
                        if (answer.QuestionDTO_Id == quest.Id)
                            AnswerList.Add(answer);
                    }
                    quest.OptionalAnswers = AnswerList;
                    if (quest.TestDTO_Id == test.Id)
                        QuestList.Add(quest);
                }
                test.Questions = QuestList;
                TestList.Add(test);
            }

            testsMaped = TestList;      //returns testdto obj with referents to tabels with questions and answers

            return testsMaped;
        }

        public async void UpdateTest(TestDTO TestInstance)
        {
            IEnumerable<TestDTO> TestsList = GetTests();         //ads refs to curent test xz how DO NOT DELL IT, Intitial DataBase
            Test curentTest = await Database.Tests.Get(TestInstance.Id);     //returns DAL Test with a given ID, but      WITOUT referents or with?? ref are here      to other tabels need to convert to DTO


            List<Question> QuestionList = new List<Question>();
            List<OptionalAnswer> AnswersList;

            foreach (var Questions in TestInstance.Questions)
            {
                AnswersList = new List<OptionalAnswer>();
                foreach (var Answers in Questions.OptionalAnswers)
                {
                    AnswersList.Add(new OptionalAnswer()
                    {
                        OptionAnswer = Answers.OptionAnswer,
                        TrueAnswer = Answers.TrueAnswer 
                    });
                }
                QuestionList.Add(new Question()
                {
                    QuestionText = Questions.QuestionText, 
                    OptionalAnswers = AnswersList
                });
            }
            // testTemp.Description = TestInstance.Description;
            curentTest.Questions.AddRange(QuestionList);// = QuestionList;


            Database.Tests.Update(curentTest);
            Database.Save();
        }
    }

}
