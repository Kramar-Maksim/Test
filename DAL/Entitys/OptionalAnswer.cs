using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class OptionalAnswer
    {
        [Key]
        public int Id { get; set; }

        public string OptionAnswer { get; set; }
        public bool TrueAnswer { get; set; }


        // [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question QuestionObj { get; set; }
    }
}
