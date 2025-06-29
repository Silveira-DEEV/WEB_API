using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuario user)
        {
            UserService.AddUser(user);
            var totalUsers = UserService.LoadUsers().Count;
            return Ok(new { message = "Usuário registrado com sucesso.", totalUsers });
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var users = UserService.LoadUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            bool deleted = UserService.DeleteUserById(id);
            if (deleted)
                return Ok(new { message = $"Usuário com ID {id} foi deletado com sucesso." });

            return NotFound(new { error = $"Usuário com ID {id} não encontrado." });
        }

        [HttpGet("download-json")]
        public IActionResult DownloadJson()
        {
            var filePath = "users.json";
            if (!System.IO.File.Exists(filePath))
                return NotFound("Arquivo não encontrado");

            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "application/json", "users.json");
        }
    }
}
