using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{ 
    public class Result
    {
        [Key]
        public int Id { get; set; }
         
        public int? CheckedAnswers { get; set; }

        public int? UncheckedAnswers { get; set; }
         
        public string  Performance { get; set; }

        public int? TotalWrongAnswers { get; set; }

        public DateTime? PassingDate { get; set; }

        // public string Result { get; set; }



        //[ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        //[ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
