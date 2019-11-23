using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;

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

        public User GetUser(int? Id)
        {
            //need to implement non existence.
            //TCP skills? Tudo encapsulado com baixa agregação?
            //check Id and check user...
            User user = _db.Users.Find(Id);
            return user;
        }
        //Add/Update
        public void Save(User user)
        {
            if(user.UserId == 0) //New
            {
                _db.Users.Add(user); //does add deals with the Id?
                _db.SaveChanges();
            }
            else
            {
                User existing_user = _db.Users.Find(user.UserId);
                existing_user.Name = user.Name;
                existing_user.Email = user.Email;

                _db.SaveChanges();
            }
        }
    }
}
