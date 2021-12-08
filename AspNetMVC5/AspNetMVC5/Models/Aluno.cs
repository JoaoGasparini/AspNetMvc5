using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetMVC5.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        [MaxLength(100, ErrorMessage = "No maximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        [EmailAddress(ErrorMessage ="Email em formato inválido !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é requirido")]
        public string CPF { get; set; } 

        public DateTime DataMatricula { get; set; }

        public bool Ativo { get; set; }

        
    }
}