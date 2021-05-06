using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class TbClientes : IValidatableObject
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Aniversário"), DataType(DataType.Date)]
        public DateTime? Aniversario { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Nro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Data.ValidacoesController.ValidaCPF.IsCpf(Cpf))
            {
                yield return new ValidationResult(
                    $"CPF inválido.",
                    new[] { nameof(Cpf) });
            }
        }
    }
}
