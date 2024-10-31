using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tryitter.Models
{
    public class Fornecedor
    {
        [Key]
        [JsonIgnore]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "RazaoSocial is required.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "CNPJ is required.")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "NomeFantasia is required.")]
        public string? NomeFantasia { get; set; } = null;

        [Required(ErrorMessage = "Email is required.")]
        //[RegularExpression(
        //    @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
        //    ErrorMessage = "Email in invalid format.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefone Password is required")]
        
        public string Telefone { get; set; }

        
    }
}
