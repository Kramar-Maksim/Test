using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

namespace BLL.DTO
{
    public class QuestionsDTO            //Data Transfer Object
    {
        public int Id { get; set; }
         
        public string QuestionText { get; set; } 
       // public int RealAnswer_Id { get; set; }

        
        public int TestDTO_Id { get; set; }
        public TestDTO TestObj { get; set; }
        
        public ICollection<OptionalAnswerDTO> OptionalAnswers { get; set; }
        public QuestionsDTO()
        {
            OptionalAnswers = new List<OptionalAnswerDTO>();
        }
    } 
}
