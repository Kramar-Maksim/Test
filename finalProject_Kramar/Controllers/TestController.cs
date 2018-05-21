using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using finalProject_Kramar.Models;
using AutoMapper;
using Ninject;
using BLL.Services;
using Ninject.Modules;
using BLL.Infrastructure;
using finalProject_Kramar.Util;
using Ninject.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System;

namespace finalProject_Kramar.Controllers
{
    public class TestController : Controller
    {
        ITestService testService;

        public TestController(ITestService serv)
        {
            testService = serv;
        }

        [HttpPost]
        public string PassTheTest(List<int?> checkedAnswers, int? TestId)        //taks the id and show test by id
        {
            List<TestViewModel> tests = Map();

            var query = from t in tests
                        where t.Id == TestId.Value          //chose 1 test to pass
                        select t;


            string s = "";

            foreach (var test in query)     // take from table test table question from it table answers and compear uor answers to real answer
            {
                foreach (var question in test.Questions)
                { 


                    foreach (var myAnswerId in checkedAnswers)
                    {

                        foreach (var answer in question.OptionalAnswers)
                        {
                            if (myAnswerId.Value == answer.Id && answer.TrueAnswer)
                            {
                                //you choose right answer
                                s += "YES" + answer.OptionAnswer + "----";
                            }
                            else if (myAnswerId.Value == answer.Id && !answer.TrueAnswer)
                            {
                                //you choose wrong answer
                                s += "NO" + answer.OptionAnswer + "----";
                            }
                            else if (myAnswerId.Value != answer.Id && answer.TrueAnswer)
                            {
                                //you do not choose right answer
                                s += "Empty" + answer.OptionAnswer + "----";
                            }
                        }
                    }
                }
            }

            return s;
        }
        public ActionResult PassTheTest(int? id)        //taks the id and show test by id
        {
            List<TestViewModel> tests = Map();

            var query = from t in tests
                        where t.Id == id.Value
                        select t;

            return View(query);
        }

        // GET: Test
        public ActionResult Index()
        {
            List<TestViewModel> tests = Map();

            return View(tests);     //list of tests
        }

        [HttpPost]
        public ActionResult Tests(string findTests)
        {
            //IEnumerable<TestDTO> testDtos = testService.GetTests();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            //var tests = mapper.Map<IEnumerable<TestDTO>, List<TestViewModel>>(testDtos);

            List<TestViewModel> tests = Map();

            var quest = from t in tests
                        where t.Description.ToLower().StartsWith(findTests.ToLower())
                        select t;


            return View(quest);
        }
        public ActionResult Tests()
        {
            //IEnumerable<TestDTO> testDtos = testService.GetTests();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            //var tests = mapper.Map<IEnumerable<TestDTO>, List<TestViewModel>>(testDtos);

            List<TestViewModel> tests = Map();

            return View(tests);     //list of tests
        }

        public List<TestViewModel> Map()
        {
            IEnumerable<TestDTO> testDtos = testService.GetTests();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<TestDTO>, List<TestViewModel>>(testDtos);
        }

        public async Task<ActionResult> EditAsync(int? id)
        {
            TestDTO TD = await testService.GetTest(id.Value); //with ref

            TD.Description = "TestEdit";

            testService.EditTest(TD);
            return View();//tests);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            TestDTO TD = await testService.GetTest(id.Value);
            TD.Id = id.Value;
            testService.DeleteTest(TD);

            return View();
        }

        [HttpPost]      //add test
        public ActionResult Add(string TestName, string question, List<string> Answers, List<int?> checkBoxNum)
        {
            TestDTO TD = new TestDTO();
            QuestionsDTO QU = new QuestionsDTO();
            List<OptionalAnswerDTO> AnswerList = new List<OptionalAnswerDTO>();

            int count = 0;
            bool isTrue = false;

            foreach (var answ in Answers)
            {
                count++;
                isTrue = false;

                foreach (var item in checkBoxNum)
                {
                    if (count == item.Value)
                        isTrue = true;
                }
                AnswerList.Add(new OptionalAnswerDTO()
                {
                    TrueAnswer = isTrue,
                    OptionAnswer = answ,
                    QuestionObj = QU
                });      //fill list of answers with the list from user
            }

            QU.QuestionText = question;
            QU.OptionalAnswers = AnswerList;
            QU.TestObj = TD;

            TD.Questions.Add(QU);
            TD.Description = TestName;

            testService.CreateTest(TD);


            //return PassTheTest(TD.Id);
            return View();
        }
        public ActionResult Add()
        {
            return View();// tests);
        }

        [HttpPost]
        public async Task<ActionResult> AddQustion(int? testId, string question, List<string> Answers, List<int?> checkBoxNum)
        {
            TestDTO TestInstance = new TestDTO(); // get that test
            QuestionsDTO QU = new QuestionsDTO();
            List<OptionalAnswerDTO> AnswerList = new List<OptionalAnswerDTO>();

            int count = 0;
            bool isTrue = false;

            foreach (var answ in Answers)
            {
                count++;
                isTrue = false;

                foreach (var item in checkBoxNum)
                {
                    if (count == item.Value)
                        isTrue = true;
                }
                AnswerList.Add(new OptionalAnswerDTO()
                {
                    TrueAnswer = isTrue,
                    OptionAnswer = answ,
                    QuestionObj = QU
                });      //fill list of answers with the list from user
            }

            //foreach (var answ in Answers)
            //{ 
            //    AnswerList.Add(new OptionalAnswerDTO()
            //    {
            //        OptionAnswer = answ,
            //        QuestionObj = QU
            //    });      //fill list of answers with the list from user
            //}

            QU.QuestionText = question;
            QU.OptionalAnswers = AnswerList;
            QU.TestObj = TestInstance;
            TestInstance.Questions.Add(QU);
            TestInstance.Id = testId.Value;


            testService.UpdateTest(TestInstance);

            // return View(PassTheTest(testId.Value));
            return AddQustion(testId);
        }
        public ActionResult AddQustion(int? id)
        {
            //IEnumerable<TestDTO> testDtos = testService.GetTests();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            //var tests = mapper.Map<IEnumerable<TestDTO>, List<TestViewModel>>(testDtos);

            List<TestViewModel> tests = Map();


            var query = from t in tests
                        where t.Id == id.Value
                        select t;            //represent 1 test with given ID

            TestViewModel TestVM = new TestViewModel();

            foreach (var test in query)
            {
                TestVM = test;
            }

            return View(TestVM);
        }

    }
}