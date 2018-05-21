using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }


        //[ForeignKey("Test")]
        public int TestId { get; set; }
        public Test TestObj { get; set; }
        
        public List<OptionalAnswer> OptionalAnswers { get; set; }
    }
}
