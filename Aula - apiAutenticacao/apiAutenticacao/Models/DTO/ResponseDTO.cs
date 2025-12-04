namespace apiAutenticacao.Models.DTO
{
    public class ResponseDTO
    {
        public bool Erro { get; set; }
        public string Messege { get; set; } = string.Empty;

        public Usuario?  Usuario { get; set; }


    }
}
