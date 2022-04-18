using Locations.Api.Data;
using Locations.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.Where(x => x.Status == 1).ToList();

            return Ok(users);
        }

        // POST
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            {
                var _user = new User();
                _user.LastName = user.LastName;
                _user.FirstName = user.FirstName;
                _user.Email = user.Email;
                _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                _user.Country = user.Country;
                _user.Phone = user.Phone;
                _user.Status = 1;

                _context.Users.Add(_user);
                _context.SaveChanges();

                return Ok(); // return a 201
            }
        }

        // GET
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return Ok(user);
        }
        
    }
}
