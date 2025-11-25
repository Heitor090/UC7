using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;


namespace apiAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarUsuarioAsync([FromBody] CadastroUsuarioDTO dadosUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario? usuarioExistente = await _context.Usuarios.
               FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.Email);

            if (usuarioExistente != null)
            {
                return BadRequest(new { Mensagem = "Este email ja esta cadastrado!" });
            }
            Usuario Usuario = new Usuario
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Senha = HashPassword(dadosUsuario.Senha),
                ConfirmarSenha = HashPassword(dadosUsuario.ConfirmarSenha)
            };

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                id = Usuario.Id,
                nome = Usuario.Nome,
                email = Usuario.Email,
                
            });
               
                
                
                
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody ]LoginDTO dadosUsuario) 
        {
        if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);    
            }

           Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.email);
            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuario.senha, usuarioEncontrado.Senha);
                if (isValidPassword)
                {
                    return Ok("login reealizado com sucesso");

                }
                return Unauthorized("Login não realizado. Email ou senha incorretos!");
                
                }
            return NotFound("Usuário não encontrado!");
        
        }
    }
}