using App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services
{
    public interface IUser
    {
        User GetUser(int? Id);
        IQueryable<User> GetUsers { get; }
        void Save(User user);
    }
}
