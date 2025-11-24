using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        [HttpGet]
        public IActionResult helloword()
        {
            return Ok("Hello Word!");
        }

        [HttpPost]

        public IActionResult helloWorldPost([FromBody] String login)
        {

            return Ok($"O login enviado foi {login}");

            //return Ok(new
            //{
            //    nome = "Diego ",
            //    sobrenome = "Aquila",
            //    email = "diego@diegoaquilla.com.br"

            //});

            
        }
    }
}

