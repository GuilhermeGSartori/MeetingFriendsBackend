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
        public async Task<IActionResult> Save([FromBody] Location data)
        {
            if (data == null)
                return BadRequest();

            LocationTAR result = await db.Save(data); //the one implemented in repo.
            if (result == null) // almost impossible to happen, but it's necessary
            {
                return NotFound();
            }

            return Ok(result); ;
        }

        [HttpGet("(LocationName)")]
        public async Task<IActionResult> GetLocation(string name)
        {
            if (name == null)
                return BadRequest();

            Location result = await db.GetLocation(name);

            if (result == null) //if for some reason the result does to returns...
                return NotFound(); //this happens the Id is null...

            return Ok(result);

        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            IQueryable<Location> data = db.GetLocations;

            return Ok(data);
        }
    }
}