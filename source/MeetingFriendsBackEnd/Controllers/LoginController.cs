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
        //Simulation(not real) of the process of log in a User (saving the "logged" user info in a logged user table)
        [HttpGet]
        public async Task<IActionResult> GetLogin()
        {
            User logged = await login_db.GetLogin();
            if (logged == null) // no one is logged in in the system
            {
                User data = await users_db.GetUser(1); //Since the scope of this project is limited, the first User
                                                       //will always be selected to be an example of a logged user!
                if (data == null)
                    return NotFound();

                TAR model = await login_db.Save(data);

                if (model.Success == true)
                    return Ok(data);

                else
                    return Ok(model);
            }
            else // a user is already logged!
                return Ok(logged);
        }
    }
}