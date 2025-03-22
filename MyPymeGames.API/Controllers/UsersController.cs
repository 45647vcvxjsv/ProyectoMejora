using Microsoft.AspNetCore.Mvc;
using MyPymeGames.Core.Interfaces;
using MyPymeGames.Core.Entities;
using MyPymeGames.API.DTOs;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MyPymeGames.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // crear un nuevo usuario 

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                PasswordHash = createUserDto.Password
            };

            // guardar el usuario en la base de datos

            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id= user.Id}, user);
            
        }

        // actualizar el usuario 

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            // si actualiza los campos que se piden 

            if (updateUserDto.Username != null)
                user.Username = updateUserDto.Username;
            
            if (updateUserDto.Email != null)
                user.Email = updateUserDto.Email;
            
            await _userRepository.UpdateAsync(user);

            return Ok(user);

        }

        // eliminar usuarios 

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            await  _userRepository.DeleteAsync(id);
            return NoContent(); // no content 204 - se eliminaria si los datos son correctos 
        }
    }
}
