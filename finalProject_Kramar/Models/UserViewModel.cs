using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}