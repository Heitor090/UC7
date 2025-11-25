using System.ComponentModel.DataAnnotations;

namespace apiAutenticacao.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="O email é obrigatório")]
        [EmailAddress(ErrorMessage ="O email é invalido")]
        public string email { get; set; } = string.Empty;
        [Required(ErrorMessage ="A senha é obtigatória")]
        public string senha { get; set; } = string.Empty;
    }
}
