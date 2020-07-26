using AutoMapper;
using BulletinBoard.Models.Users;
using Core.DTOs;
using Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulletinBoard.Controllers
{
    public class UsersController : Controller
    {
        private IUsersManager usersManager;
        public UsersController()
        {

        }
        public UsersController(IUsersManager um)
        {
            this.usersManager = um;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }

        public ActionResult Registrate(CreateUserRequest user)
        {  
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserRequest, UserDto>()
                .ForMember(ud => ud.Email, opt => opt.MapFrom(cur => cur.Email))
                .ForMember(ud => ud.Password, opt => opt.MapFrom(cur => cur.Password))
                .ForMember(ud => ud.RepeatPassword, opt => opt.MapFrom(cur => cur.RepeatPassword))
                .ForMember(ud => ud.FirstName, opt => opt.MapFrom(cur => cur.FirstName))
                .ForMember(ud => ud.SecondName, opt => opt.MapFrom(cur => cur.LastName))
                .ForMember(ud => ud.Gender, opt => opt.MapFrom(cur => cur.Gender))
                .ForMember(ud => ud.Phone, opt => opt.MapFrom(cur => cur.Phone))
                .ForMember(ud => ud.Age, opt => opt.MapFrom(cur => cur.Age))
            );

            var mapper = new Mapper(config);
            UserDto userDto = mapper.Map<CreateUserRequest, UserDto>(user);

            this.usersManager.Add(userDto);

            return View("Registration");
        }
    }
}