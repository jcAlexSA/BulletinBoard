using AutoMapper;
using Core.DTOs;
using Core.Interfaces.Managers;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;

namespace BusinessLogicLayer
{
    public class UsersManager : ManagerBase, IUsersManager
    {
        private IUsersRepository usersRepository;

        public UsersManager(IUsersRepository ur, IUnitOfWork unitOfWork) : base (unitOfWork)
        {
            this.usersRepository = ur;
        }

        public void Add(UserDto userDto)
        {
            if (!userDto.Password.Equals(userDto.RepeatPassword))
            {
                throw new HttpException((int)HttpStatusCode.Forbidden, "Password and Repeat password aren't equals.");
            }

            userDto.Password = this.MD5StringHash(userDto.Password);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, User>()
                .ForMember(ud => ud.Email, opt => opt.MapFrom(cur => cur.Email))
                .ForMember(ud => ud.Password, opt => opt.MapFrom(cur => cur.Password))
                .ForMember(ud => ud.FirstName, opt => opt.MapFrom(cur => cur.FirstName))
                .ForMember(ud => ud.SecondName, opt => opt.MapFrom(cur => cur.SecondName))
                .ForMember(ud => ud.Gender, opt => opt.MapFrom(cur => cur.Gender))
                .ForMember(ud => ud.Phone, opt => opt.MapFrom(cur => cur.Phone))
                .ForMember(ud => ud.Age, opt => opt.MapFrom(cur => cur.Age))
            );
            var mapper = new Mapper(config);
            User user = mapper.Map<UserDto, User>(userDto);

            if (this.GetUserByEmail(user.Email) == null)
            {
                this.usersRepository.Add(user);
                this.unitOfWork.Save();
            }
            else
            {
                throw new ArgumentException("This email is already used.");
            }
        }

        public bool IsUserExists(SignInUserDto user)
        {
            user.Password = this.MD5StringHash(user.Password);

            bool isExists = this.usersRepository.IsUserExists(user.Email, user.Password);

            return isExists;
        }

        public User GetUserByEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return null;
            }

            User user = this.usersRepository.GetUserByEmail(email);

            return user;
        }

        private string MD5StringHash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
