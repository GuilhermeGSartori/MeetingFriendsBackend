using App.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ILogin
    {
        Task<User> GetLogin();
        Task<TAR> Save(User user);
    }
}
