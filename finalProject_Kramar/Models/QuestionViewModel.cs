using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }
            

       // public int Test_Id { get; set; }      
        public TestViewModel TestObj { get; set; }
         
        public ICollection<OptionalAnswerViewModel> OptionalAnswers { get; set; }
        public QuestionViewModel()
        {
            OptionalAnswers = new List<OptionalAnswerViewModel>();
        }
    }
}