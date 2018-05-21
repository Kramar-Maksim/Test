using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

         
        public ICollection<QuestionViewModel> Questions { get; set; }
        public TestViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
    }
}