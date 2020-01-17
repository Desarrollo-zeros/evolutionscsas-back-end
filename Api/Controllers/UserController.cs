using Api.Interface;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<User> Authenticate([FromBody] User user)
        {
            if(user.Username.Length < 2)
            {
                return BadRequest("Username is Empty");
            }

            var entity = _userService.Authenticate(user);

            if (entity == null)
            {
                return BadRequest(entity);
            }
            return Ok(entity);

        }
        [HttpGet]
        public ActionResult<User> Get()
        {
            return Ok(_userService.GetUser(int.Parse(User.Identity.Name)));
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public ActionResult<IEnumerable<User>> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            pageSize = pageSize == 0 ? 10 : pageSize;
            return Ok(_userService.GetAll(pageIndex, pageSize));
        }


        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult<User> Create(User entity)
        {
            if (entity == null) return BadRequest("Model empty");
            var response = _userService.Create(entity);
            if (response == null) return BadRequest(response);
            return Ok(response);
        }

    }
}
