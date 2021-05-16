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
    public partial class TbVeiculo
    {
        public int Id { get; set; }
        [Required, StringLength(7, MinimumLength = 7)]
        [Remote(action: "TbVeiculoPlacaExists", controller: "TbVeiculoes", AdditionalFields = "Id")]
        public string Placa { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [Required]
        public int ModeloId { get; set; }
        [Required]
        public int? Ano { get; set; }
        [Required]
        public decimal? ValorHora { get; set; }
        [Required]
        public string Combustivel { get; set; }
        [Required]
        public int? LtPortaMala { get; set; }
        [Required]
        public string Categoria { get; set; }

        public virtual TbMarcaVeiculo Marca { get; set; }
        public virtual TbModeloVeiculo Modelo { get; set; }
        public virtual ICollection<TbLocacoes> TbLocacoes { get; set; }
    }
}
