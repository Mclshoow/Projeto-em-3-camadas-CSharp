using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        public int AlunoMatricula { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O rua é obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O complemento é obrigatório.")]
        public string Complemento { get; set; }
    }
}

