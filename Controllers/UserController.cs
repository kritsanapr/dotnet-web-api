using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using assignment_api.Models;
using System.Collections.Generic;

namespace assignment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private List<UserModel> users;

        public UserController()
        {
            users = new List<UserModel>();
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UserModel>> Get(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<IEnumerable<UserModel>> Post([FromBody] UserModel user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("id")]
        public ActionResult<UserModel> Put(int id, [FromBody] UserModel user) {
            var existingUser = users.FirstOrDefault(x => x.Id == id);
            if (existingUser == null) {
                return NotFound();
            } 

            existingUser.Name = user.Name;
            existingUser.Age = user.Age;
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public ActionResult<UserModel> Delete(int id) {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null) {
                return NotFound();
            }

            return Ok(user);
        }
    }
}