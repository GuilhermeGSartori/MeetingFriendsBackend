﻿using App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IUser
    {
        Task<User> GetUser(int? Id);
        IQueryable<User> GetUsers { get; }
        Task<TAR> Save(User user);
        Task<User> Login(int? Id);
    }
}
