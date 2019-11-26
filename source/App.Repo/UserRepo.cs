using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Repo
{
    public class UserRepo : IUser //using IUser interface (service)
    {

        private readonly UserDbContext _db; 

        public UserRepo(UserDbContext db) 
        {
            _db = db;
        }
        public IQueryable<User> GetUsers => _db.Users;

        public async Task<User> GetUser(int? Id)
        {
            User user = new User();

            if (Id != null)
                user = await _db.Users.FindAsync(Id);

            return user;
        }

        //Add/Update
        public async Task<TAR> Save(User user)
        {
            TAR model = new TAR();

            if (user.UserId == 0) //New
            {
                try
                {
                    await _db.Users.AddAsync(user);
                    await _db.SaveChangesAsync();

                    model.Id = user.UserId;
                    model.Success = true;
                    model.Message = "New user created!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else
            {
                User existing_user = await GetUser(user.UserId);
                existing_user.Name = user.Name;
                existing_user.Email = user.Email;

                try
                {
                    //if Id null this will return as an exception (since Id is the Key)
                    await _db.SaveChangesAsync();
                    model.Id = user.UserId;
                    model.Success = true;
                    model.Message = "Old user updated!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            return model;
        }

    }
}
