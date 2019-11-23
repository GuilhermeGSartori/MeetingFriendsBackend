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
    [Route("api/Location")]
    public class LocationController : Controller
    {
        //define more precise requests (deal wit problems, async, etc...)
        private readonly ILocation db;

        public LocationController(ILocation _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Save([FromBody] Location data)
        {
            if (data == null)
                return BadRequest();

            db.Save(data); //the one implemented in repo.

            return Ok(data);
        }

        [HttpGet("(name)")]
        public IActionResult GetLocation(string name)
        {
            Location data = db.GetLocation(name);

            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            IQueryable<Location> data = db.GetLocations;

            return Ok(data);
        }
    }
}