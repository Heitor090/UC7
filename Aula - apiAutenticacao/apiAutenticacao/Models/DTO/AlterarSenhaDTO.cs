using System.ComponentModel.DataAnnotations;

namespace apiAutenticacao.Models.DTO
{
    public class AlterarSenhaDTO
    {
        [Required(ErrorMessage = "O email é necessário")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="A senha é obrigatoria")]
        public string SenhaAtual { get; set; } = string.Empty ;



        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres")]
       
        public string NovaSenha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não conferem")]

        public string ConfirmarSenha { get; set; } = string.Empty;

    }
}
