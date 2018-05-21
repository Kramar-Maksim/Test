using DAL.Entitys;
using System.Collections.Generic;



namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }
         

        public ICollection<QuestionsDTO> Questions { get; set; }
        public TestDTO()
        {
            Questions = new List<QuestionsDTO>();
        }

    }
}
