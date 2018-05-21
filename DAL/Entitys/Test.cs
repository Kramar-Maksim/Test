using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entitys
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }


        public List<Question> Questions { get; set; }
    }
}
