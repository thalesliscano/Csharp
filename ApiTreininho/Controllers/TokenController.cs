using ApiTreininho.Models;
using ApiTreininho.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTreininho.Controllers
{
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            // Verifique se o modelo é nulo
            if (model == null)
            {
                return BadRequest(new { message = "Modelo inválido" });
            }

            // Verifique se os campos obrigatórios não são nulos ou vazios
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "Nome de usuário e senha são obrigatórios" });
            }

            var user = UsersRepository.Get(model.Name, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = Services.TokenService.GenerateToken(user);

            user.Password = ""; // Não é uma boa prática enviar a senha do usuário no resultado

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
