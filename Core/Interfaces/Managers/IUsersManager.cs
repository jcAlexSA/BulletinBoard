﻿using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Managers
{
    public interface IUsersManager
    {
        void Add(UserDto user);

        bool IsUserExists(SignInUserDto user);
    }
}
