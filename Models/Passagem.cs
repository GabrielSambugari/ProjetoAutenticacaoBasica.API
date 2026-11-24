namespace ProjetoAutenticacaoBasica.API.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public int PassageiroId { get; set; }
        public int assento { get; set; }
        public int VooId { get; set; }
        public Voo? Voo { get; set; }
        public Passageiro? Passageiro { get; set; }

    }
}
