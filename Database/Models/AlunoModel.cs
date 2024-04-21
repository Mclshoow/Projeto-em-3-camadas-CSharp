using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Aluno
    {
        [Key]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime Data_Nascimento { get; set; }

        [Required(ErrorMessage = "Pelo menos um endereço é obrigatório.")]
        public List<Endereco> Endereco { get; set; }

        [Required(ErrorMessage = "A série é obrigatória.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "O segmento é obrigatória.")]
        public string Segmento { get; set; }

        [Required(ErrorMessage = "O nome do pai é obrigatório.")]
        public string Nome_Pai { get; set; }

        [Required(ErrorMessage = "O nome da mãe é obrigatório.")]
        public string Nome_Mae { get; set; }
    }
}

