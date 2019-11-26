using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeetingFriendsBackEnd.Controllers
{
    [Route("api/[controller]")] //Startup URL -> This controller is only used to redirect the URL to the Login
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public RedirectResult Get()
        {
            return Redirect("Login");
        }

        // GET api/values/5
        // POST api/values
        // PUT api/values/5
        // DELETE api/values/5
    }
}
