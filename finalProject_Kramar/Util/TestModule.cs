using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;

namespace finalProject_Kramar.Util
{ 
    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestService>().To<TestService>();
            Bind<IOptionalAnswerService>().To<OptionalAnswerService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IUserService>().To<UserService>();
            Bind<IResultService>().To<ResultService>();
        }
    }
}