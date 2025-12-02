namespace apiAutenticacao.Models.Response
{
    public class ResponseCadastro
    {
        public bool Erro { get; set; } 

        public string Messege { get; set; } = string.Empty;

        public Usuario? Usuario { get; set; }
    }
}
