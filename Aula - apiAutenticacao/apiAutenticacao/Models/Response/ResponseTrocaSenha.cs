namespace apiAutenticacao.Models.Response
{
    public class ResponseTrocaSenha
    {
        public bool Erro { get; set; }

        public Usuario? Usuario { get; set; } = new Usuario();

        public string Message { get; set; } = string.Empty;
    }
}
