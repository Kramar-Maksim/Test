using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }


        public UserService(IUnitOfWork uow) //в конструкторе принимает объект IUnitOfWork, через который идет взаимодействие с уровнем DAL.
        {
            Database = uow;
        }

        public async void AddUser(UserDTO userDto)
        {
            User user = await Database.Users.Get(userDto.Id);

            // валидация
            if (user == null)
                throw new ValidationException("User not found", "");

            User myUser = new User
            {
                Email = userDto.Email,
                Id = userDto.Id,
                Name = userDto.Name,
                Password = userDto.Password,
                Surname = userDto.Surname
            };
            Database.Users.Create(myUser);
            Database.Save();
        }

        public void EditUser(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserDTO userDto)
        {
            Database.Tests.Delete(userDto.Id);
            Database.Save();
        }

        public IEnumerable<UserDTO> GetUSers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
