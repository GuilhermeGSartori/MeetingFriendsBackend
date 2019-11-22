using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;

namespace App.Repo
{
    public class UserRepo : IUser
    {

        private readonly UserDbContext _db;

        public UserRepo(UserDbContext db) //If UserDbContext not public, this does not work!
        {
            _db = db;
        }
        public IQueryable<User> GetUsers => _db.Users;

        public User GetUser(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
