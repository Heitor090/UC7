using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace apiAutenticacao.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;       
        }

        public async Task<ResponseLogin> Login( LoginDTO dadosUsuario)
        {
           
            Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.email);
            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuario.senha, usuarioEncontrado.Senha);
                if (isValidPassword)
                {
                    return new ResponseLogin
                    {

                        Erro = false,
                        Message = "Login cadastrado com sucesso",
                        Usuario = usuarioEncontrado
                    };

                }
                   return new ResponseLogin
                {

                    Erro = true,
                    Message = "Email ou senha incorretos!",
                   
                }; ;

            }
            return new ResponseLogin
            {

                Erro = true,
                Message = "Usuario não encontrado",
               
            };
        }

    }
}
