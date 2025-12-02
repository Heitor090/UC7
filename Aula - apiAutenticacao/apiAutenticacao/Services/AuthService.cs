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

        public async Task<ResponseCadastro> CadastrarUsuariosAsync(CadastroUsuarioDTO dadosUsuariosCadastro)
        {
            Usuario? usuarioExistente = await _context.Usuarios.
             FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuariosCadastro.Email);

            if (usuarioExistente != null)
            {
                return new ResponseCadastro
                {
                    Erro = true,
                    Messege = "Impossível realizar este cadastro com este e-mail!"

                };
               
            }
            Usuario usuario = new Usuario
            {
                Nome = dadosUsuariosCadastro.Nome,
                Email = dadosUsuariosCadastro.Email,
                Senha = HashPassword(dadosUsuariosCadastro.Senha),
                ConfirmarSenha = HashPassword(dadosUsuariosCadastro.ConfirmarSenha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new ResponseCadastro
            {
                Erro = false,
                Messege ="Usuario cadastrado com sucesso!",
                Usuario = usuario
            };                          
                                

        }
        public async Task<ResponseTrocaSenha> AlterarSenhaAsync(AlterarSenhaDTO dadosUsuarioTrocaSenhas)
        {
            Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuarioTrocaSenhas.Email);

            if (usuarioExistente == null)
            {
                return new ResponseTrocaSenha
                {
                    Erro = true,
                    Message = "Usuario não encontrado!"
                };
            }

            bool isValidPassword = Verify(dadosUsuarioTrocaSenhas.SenhaAtual, usuarioExistente.Senha);

            if (!isValidPassword)
            {
                return new ResponseTrocaSenha 
                
                {
                    Erro = true,
                    Message="Senha não confere"
                };



            }

            if (dadosUsuarioTrocaSenhas.NovaSenha != dadosUsuarioTrocaSenhas.ConfirmarSenha)
            {
                return new ResponseTrocaSenha

                {
                    Erro = true,
                    Message = "A senha de confirmação deve ser igual a nova!"
                };

            }

            usuarioExistente.Senha = HashPassword(dadosUsuarioTrocaSenhas.NovaSenha);
               

            Usuario usuario = new Usuario { 
            Email = dadosUsuarioTrocaSenhas.Email,            
            Senha = HashPassword(dadosUsuarioTrocaSenhas.NovaSenha),
            
            
            };

            _context.Usuarios.Update(usuario);
           await _context.SaveChangesAsync();

            return new ResponseTrocaSenha
            {
                Erro = false,
                Message = "Usuario cadastrado com sucesso!",
                
            };

        }

    }
}
