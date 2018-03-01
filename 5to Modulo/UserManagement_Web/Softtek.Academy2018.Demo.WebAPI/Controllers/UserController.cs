using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.Demo.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("Request is null");

            User user = new User
            {
                IS = userDTO.IS,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                Salary = userDTO.Salary
            };

            int id = _userService.Add(user);

            if (id <= 0)
            {
                return BadRequest("Unable to create user");
            }

            var payload = new { UserId = id };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            User user = _userService.Get(id);

            if (user == null) return NotFound();
                                  
            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                IS = user.IS,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                CreatedDate = user.CreatedDate,
                ModifiedDate = user.ModifiedDate,
                Salary = user.Salary
            };

            return Ok(userDTO);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var users = _userService.GetAll();

            if (users == null) return NotFound();

            List<UserDTO> userDTO = users.Select(q => new UserDTO
            {
                Id = q.Id,
                IS = q.IS,
                FirstName = q.FirstName,
                LastName = q.LastName,
                DateOfBirth = q.DateOfBirth,
                CreatedDate = q.CreatedDate,
                ModifiedDate = q.ModifiedDate,
                Salary = q.Salary
            }).ToList();

            return Ok(userDTO);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _userService.Delete(id);

            if (!result) return BadRequest("Unable to delete user");

            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Update([FromUri] int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("User is null");

            User user = new User
            {
                Id = id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                Salary = userDTO.Salary
            };

            var result = _userService.Update(user);

            if (!result) return BadRequest("Unable to update user");

            return Ok();
        }

    }
}
