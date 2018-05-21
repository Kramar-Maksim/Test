using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class OptionalAnswerViewModel
    {
        public int Id { get; set; } 

        public string OptionAnswer { get; set; }
        public bool TrueAnswer { get; set; }

        public int Question_Id { get; set; }
        public QuestionViewModel QuestionObj { get; set; }
    } 
}