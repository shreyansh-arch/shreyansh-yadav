using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new();

        [HttpGet]
        public IActionResult GetAll() => Ok(Users);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound(new { error = "User not found." }) : Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName) || string.IsNullOrWhiteSpace(user.Email))
                return BadRequest(new { error = "Invalid user data." });

            user.Id = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound(new { error = "User not found." });

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound(new { error = "User not found." });

            Users.Remove(user);
            return NoContent();
        }
    }
}
