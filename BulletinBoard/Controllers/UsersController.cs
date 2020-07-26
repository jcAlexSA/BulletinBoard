using AutoMapper;
using BulletinBoard.Infrastructure;
using BulletinBoard.Models.Users;
using Core.DTOs;
using Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BulletinBoard.Controllers
{
    public class UsersController : Controller
    {
        private IUsersManager usersManager;

        public UsersController(IUsersManager um)
        {
            this.usersManager = um;
        }

        public ActionResult Index()
        {
            HttpCookie httpCookie = HttpContext.Request.Cookies.Get(ConfigurationManager.AppSettings[Constants.AuthenticationCookieName]);

            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(CreateUserRequest user)
        {
            if (ModelState.IsValid)
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

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, user.FirstName);
                string enTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie cookie = new HttpCookie(ConfigurationManager.AppSettings[Constants.AuthenticationCookieName], enTicket);
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Adverts");
            }

            return View("Registration");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInUserRequest user)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SignInUserRequest, SignInUserDto>()
                    .ForMember(u => u.Email, opt => opt.MapFrom(dto => dto.Email))
                    .ForMember(u=> u.Password, opt => opt.MapFrom(dto => dto.Password))
                );

                var mapper = new Mapper(config);
                SignInUserDto userDto = mapper.Map<SignInUserRequest, SignInUserDto>(user);

                bool isExists = this.usersManager.IsUserExists(userDto);

                if (isExists)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, string.Empty);
                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie cookie = new HttpCookie(ConfigurationManager.AppSettings[Constants.AuthenticationCookieName], enTicket);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Adverts");
                }
            }

            return View("Registration");
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies[ConfigurationManager.AppSettings[Constants.AuthenticationCookieName]] != null)
            {
                var cookie = new HttpCookie(ConfigurationManager.AppSettings[Constants.AuthenticationCookieName]);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Adverts");
        }
    }
}