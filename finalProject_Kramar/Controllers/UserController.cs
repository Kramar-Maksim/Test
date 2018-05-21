using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using finalProject_Kramar.Models;
using AutoMapper;
using BLL.Infrastructure;

namespace finalProject_Kramar.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;

        public UserController(IUserService serv)
        {
            userService = serv;
        }


        // GET: User
        //public ActionResult Index()
        //{
        //    IEnumerable<UserDTO> userDtos = UserService.AddUser();
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
        //    var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
        //    return View(users);
        //}
    }
}