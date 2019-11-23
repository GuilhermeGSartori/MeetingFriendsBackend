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
        public async Task<IActionResult> Save([FromBody] User data)
        {
            if (data == null)
                return BadRequest();

            TAR result = await db.Save(data); //the one implemented in repo.
            if (result == null) // almost impossible to happen, but it's necessary
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("(Id)")]
        public async Task<IActionResult> GetUser(int? Id)
        {
            if (Id == null)
                return BadRequest();

            User result = await db.GetUser(Id);
            if (result == null) //if for some reason the result does to returns...
                return NotFound(); //this happens the Id is null...

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IQueryable<User> data = db.GetUsers;

            return Ok(data);
        }
    }
}