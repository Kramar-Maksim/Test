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
    public class ResultController : Controller
    { 
        IResultService resultService; 

        public ResultController(IResultService serv)
        {
            resultService = serv; 
        }

        //public List<ResultViewModel> MapVM()
        //{
        //    IEnumerable<ResultDTO> testDtos = resultService.GetResults();
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResultDTO, ResultViewModel>()).CreateMapper();
        //    return mapper.Map<IEnumerable<ResultDTO>, List<ResultViewModel>>(testDtos);
        //}
        //public List<TestViewModel> Map()
        //{
        //    IEnumerable<TestDTO> testDtos = testService.GetTests();
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
        //    return mapper.Map<IEnumerable<TestDTO>, List<TestViewModel>>(testDtos);
        //}


        //// GET: Result
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public string PassTheTest(List<int?> checkedAnswers, int? TestId)        //taks the id and show test by id
        //{
        //    List<ResultViewModel> tests = MapVM();

        //    var query = from t in tests
        //                where t.Id == TestId.Value          //chose 1 test to pass
        //                select t;

        //    string s = "";

        //    foreach (var test in query)
        //    {
        //        foreach (var question in test.Questions)
        //        {
        //            foreach (var answer in question.OptionalAnswers)
        //            {

        //                foreach (var myAnswerId in checkedAnswers)
        //                {
        //                    if (myAnswerId.Value == answer.Id && answer.TrueAnswer)
        //                    {
        //                        //you choose right answer
        //                        s += "you choose right answer" + answer.OptionAnswer + "--------------";
        //                    }
        //                    else if (myAnswerId.Value == answer.Id && !answer.TrueAnswer)
        //                    {
        //                        //you choose wrong answer
        //                        s += "you choose wrong answer" + answer.OptionAnswer + "--------------";
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return s;
        //}
        //public ActionResult PassTheTest(int? id)        //taks the id and show test by id
        //{
        //    List<TestViewModel> tests = Map();

        //    var query = from t in tests
        //                where t.Id == id.Value          //chose 1 test to pass
        //                select t;

        //    return View(query);
        //}

    }
}