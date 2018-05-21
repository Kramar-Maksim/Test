using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

namespace BLL.DTO
{
    public class ResultDTO
    {
        public int Id { get; set; }
         
        public int? CheckedAnswers { get; set; }

        public int? UncheckedAnswers { get; set; }
          
        public string Performance { get; set; }

        public int? TotalWrongAnswers { get; set; }

        public DateTime PassingDate { get; set; } 
        // public string Result { get; set; }
         

        public int User_Id { get; set; }
        public UserDTO User { get; set; }
         
        public int Id_Test { get; set; }
        public TestDTO Test { get; set; }


    }
}
