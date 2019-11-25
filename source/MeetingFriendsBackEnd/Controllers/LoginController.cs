using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.Data;

namespace MeetingFriendsBackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly IUser users_db;
        private readonly ILogin login_db;

        public LoginController(IUser _users_db, ILogin _login_db)
        {
            users_db = _users_db;
            login_db = _login_db;
        }

        //GET api/Login
        [HttpGet]
        public async Task<IActionResult> GetLogin()
        {
            User data = await users_db.GetUser(1);
            if (data == null)
                return NotFound();

            TAR model = await login_db.Save(data);

            return Ok(model);
        }
    }
}