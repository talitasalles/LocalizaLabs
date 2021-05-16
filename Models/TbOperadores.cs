using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class TbOperadores
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo 'Nome' obrigatório."), StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo 'Matrícula' obrigatório."), Display(Name = "Matrícula"), StringLength(10, MinimumLength = 3)]
        public string Matricula { get; set; }
    }
}
