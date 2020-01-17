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
    [Route("api/person")]
    [ApiController]
    
    public class PersonController : ControllerBase
    {
        private readonly Person person;
        public PersonController()
        {
            person = new Person();
        }


        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return Ok(person.Get(id));
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public ActionResult<IEnumerable<object>> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            
            return Ok(person.GetAll(pageIndex, pageSize));
        }


        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult<Person> Create(Person entity)
        {
            if (entity == null) return BadRequest("Model empty");
            var response = person.Create(entity);
            if (response == null) return BadRequest(response);
            return Ok(response);
        }
    }
}
