using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
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

        public async Task<String> Login( LoginDTO dadosUsuario)
        {
           
            Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.email);
            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuario.senha, usuarioEncontrado.Senha);
                if (isValidPassword)
                {
                    return "login reealizado com sucesso";

                }
                return "Login não realizado. Email ou senha incorretos!";

            }
            return "Usuário não encontrado!";
        }

    }
}
