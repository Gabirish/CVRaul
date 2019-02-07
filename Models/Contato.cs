using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVRaul.Models
{
    public class Contato
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Apenas letras, por favor.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, digite um e-mail valido")]
        [EmailAddress(ErrorMessage = "Por favor, digite um e-mail valido")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Mensagem:")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, MinimumLength = 20)]
        public string Mensagem { get; set; }

        [Display(Name = "Assunto:")]
        [Required]
        public string Assunto { get; set; }
    }
}