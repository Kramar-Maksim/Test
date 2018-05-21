using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class ResultViewModel
    {
        public int Id { get; set; }

        public int? CheckedAnswers { get; set; }

        public int? UncheckedAnswers { get; set; }

        public string Performance { get; set; }

        public int? TotalWrongAnswers { get; set; }

        public DateTime PassingDate { get; set; }
        // public string Result { get; set; }


        public int User_Id { get; set; }
        public UserViewModel User { get; set; }

        public int Id_Test { get; set; }
        public TestViewModel Test { get; set; }


    }
}