namespace ProjetoAutenticacaoBasica.API.Models.DTOs
{
   
    public class CriarPassageiroDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }

    public class CodigoInfoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
