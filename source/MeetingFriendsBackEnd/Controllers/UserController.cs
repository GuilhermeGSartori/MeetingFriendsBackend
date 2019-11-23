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
    [Produces("application/json")] //what does this means?
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUser db;

        public UserController(IUser _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Save([FromBody] User data)
        {
            if (data == null)
                return BadRequest();

            db.Save(data); //the one implemented in repo.

            return Ok(data);
        }

        [HttpGet("(Id)")]
        public IActionResult GetUser(int? Id)
        {
            User data = db.GetUser(Id);

            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IQueryable<User> data = db.GetUsers;

            return Ok(data);
        }
    }
}