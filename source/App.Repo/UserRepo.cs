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
    public class UserRepo : IUser //o que exatamente isso quer dizer? que depende da IUser? Herda dela?
    {

        private readonly UserDbContext _db; //injeção de dependência

        public UserRepo(UserDbContext db) //If UserDbContext not public, this does not work!
        {
            _db = db;
        }
        public IQueryable<User> GetUsers => _db.Users;

        public async Task<User> GetUser(int? Id)
        {
            User user = new User();
            //need to implement non existence.
            //TCP skills? Tudo encapsulado com baixa agregação?
            //check Id and check user...
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
                    await _db.Users.AddAsync(user); //does add deals with the Id?
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
                    //since Id cannot be null, if user does not exists
                    //this will result in exception
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
