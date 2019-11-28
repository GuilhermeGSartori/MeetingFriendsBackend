using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Threading.Tasks;
using System.Linq;

namespace App.Repo
{
    public class LoginRepo : ILogin //using ILogin interface (service)
    {
        private readonly LoginDbContext _db; 

        public LoginRepo(LoginDbContext db) 
        {
            _db = db;
        }

        public async Task<User> GetLogin()
        {
            User mainUser = new User();
            mainUser = await _db.Login.FindAsync(1); //Since there is only one element in the table (if a user is logged)
                                                     //this gets the logged user (the first and only User of the table)
            return mainUser;
        }

        public async Task<TAR> Save(User user)
        {
            TAR model = new TAR();

            if (!_db.Login.Any()) //To login a User, the Login Table must be empty (No one is logged)!
            {
                try
                {
                    await _db.Login.AddAsync(user);
                    await _db.SaveChangesAsync();

                    model.Id = user.UserId;
                    model.Success = true;
                    model.Message = "User logged!";
                }
                catch (Exception ex) // Could not save User info from users to login
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else // There is a user already logged in!
            {
                model.Success = false;
                model.Message = "User already logged!";
            }

            return model;
        }
    }
}
