using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Threading.Tasks;
using System.Linq;

namespace App.Repo
{
    public class LoginRepo : ILogin
    {
        private readonly LoginDbContext _db; //injeção de dependência

        public LoginRepo(LoginDbContext db) //If UserDbContext not public, this does not work!
        {
            _db = db;
        }

        public async Task<User> GetLogin()
        {
            User mainUser = new User();
            mainUser = await _db.Login.FindAsync(1);

            return mainUser;
        }

        public async Task<TAR> Save(User user)
        {
            TAR model = new TAR();

            if (!_db.Login.Any())
            {
                try
                {
                    await _db.Login.AddAsync(user);
                    await _db.SaveChangesAsync();

                    model.Id = user.UserId;
                    model.Success = true;
                    model.Message = "User logged!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else
            {
                model.Success = false;
                model.Message = "User already logged!";
            }

            return model;
        }
    }
}
