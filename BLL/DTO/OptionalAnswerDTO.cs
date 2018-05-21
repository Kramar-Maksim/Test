using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys; 

namespace BLL.DTO
{
    public class OptionalAnswerDTO
    { 
        public int Id { get; set; }

        public string OptionAnswer { get; set; }
        public bool TrueAnswer { get; set; }

        public int QuestionDTO_Id { get; set; }
        public QuestionsDTO QuestionObj { get; set; }
    }
}
