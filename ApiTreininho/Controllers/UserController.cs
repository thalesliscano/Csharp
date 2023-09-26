using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; // Adicionei o using para ControllerBase

namespace ApiTreininho.Controllers
{
    [Route("api")]
    [ApiController] // Adicionei o atributo ApiController
    public class UserController : ControllerBase // Corrigi o nome da classe base para ControllerBase
    {
        [HttpGet]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("api/funcionario")]
        [Authorize(Roles = "Funcionario,Gerente")] // Corrigi o nome das roles
        public string Employee() => "Thales";

        [HttpGet]
        [Route("api/gerente")]
        [Authorize(Roles = "gerente")]
        public string Manager() => "Gerente"; // Corrigi o nome do método
    }
}