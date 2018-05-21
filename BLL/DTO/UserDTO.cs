using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }


        // public int Result_Id { get; set; }      
        //public ICollection<ResultDTO> Results { get; set; } 
    }
}
