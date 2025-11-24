using System.ComponentModel.DataAnnotations;

namespace apiAutenticacao.Models.DTO
{
    public class CadastroUsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome {  get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength (100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres")]

        public string Senha { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]

        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
