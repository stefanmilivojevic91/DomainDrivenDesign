using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _usersService.GetUsersAsync();

            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            var user = await _usersService.GetUserAsync(id);

            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto user)
        {
            var userDto = await _usersService.SaveUserAsync(user);

            return Ok(userDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Put(string id, [FromBody] UserDto user)
        {
            var userDto = await _usersService.UpdateUserAsync(id, user);

            return Ok(userDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var isDeleted = await _usersService.DeleteUserAsync(id);

            return Ok(new
            {
                IsDeleted = isDeleted
            });
        }
    }
}
