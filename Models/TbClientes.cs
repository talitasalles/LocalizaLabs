using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LocalizaCS.Controllers;

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
        [Required, Display(Name = "CPF")]
        [Remote(action: "TbClientesCPFExists", controller: "TbClientes", AdditionalFields = "Id")]
        public string Cpf { get; set; }
        [Display(Name = "Aniversário"), DataType(DataType.Date)]
        public DateTime? Aniversario { get; set; }
        [Required, Display(Name = "CEP")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        [StringLength(6)]
        public string Nro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<TbLocacoes> TbLocacoes { get; set; }

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
