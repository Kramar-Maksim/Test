using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserDTO userDto);
         
        void EditUser(UserDTO userDto);
        void DeleteUser(UserDTO userDto);

        IEnumerable<UserDTO> GetUSers();

        void Dispose(); 
    }
}
