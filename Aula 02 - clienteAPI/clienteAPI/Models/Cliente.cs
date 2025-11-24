using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clienteAPI.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public string Id { get; set; }

        [Required(ErrorMessage ="O nome é um dado obrigatório!")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome não pode exceder 100 caracteres")]
       public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "o email é obrigatorio")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength (100, ErrorMessage = "o email deve ser no máximo 100 caracteres")]
       public string  Email { get; set; } = string.Empty ;

        
       public string Telefone {  get; set; } = string.Empty ;
        [DataType(DataType.DateTime)]
       public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
