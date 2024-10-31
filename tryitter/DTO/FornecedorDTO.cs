using tryitter.Models;

namespace tryitter.DTO
{
    public class FornecedorDTO
    {
        public int FornecedorId { get; set; }
        public string? RazaoSocial { get; set; }
       
        public string? CNPJ { get; set; }
        public string Email { get; set; }
        public string? NomeFantasia { get; set; }
        public string Telefone { get; set; }
      
    }

    public class FornecedorNomeFantasiaDTO
    {
        public int FornecedorId { get; set; }
        public string? NomeFantasia { get; set; }
    }
}
