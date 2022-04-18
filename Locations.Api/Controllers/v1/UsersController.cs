using Locations.Api.Data;
using Locations.Api.Dtos;
using Locations.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locations.Api.Controllers.v1
{
    public class UsersController : BaseController
    {
        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.All();

            return Ok(users);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto user)
        {
            var _user = new User();
            _user.LastName = user.LastName;
            _user.FirstName = user.FirstName;
            _user.Email = user.Email;
            _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
            _user.Country = user.Country;
            _user.Phone = user.Phone;
            _user.Status = 1;

            await _unitOfWork.Users.Add(_user);
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetUser", new { id = _user.Id }, user); // return a 201
        }

        // GET
        [HttpGet]
        [Route("GetUser", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);

            return Ok(user);
        }
    }
}