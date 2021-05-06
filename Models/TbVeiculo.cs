using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class TbVeiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public int? Ano { get; set; }
        [DataType(DataType.Currency)]
        public decimal? ValorHora { get; set; }
        public string Combustivel { get; set; }
        public int? LtPortaMala { get; set; }
        public string Categoria { get; set; }

        public virtual TbMarcaVeiculo Marca { get; set; }
        public virtual TbModeloVeiculo Modelo { get; set; }
    }
}
