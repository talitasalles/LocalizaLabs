using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class TbLocacoes
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public DateTime DataAtual => DateTime.Now;

        public String Mes => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

        public virtual TbClientes Cliente { get; set; }
        public virtual TbVeiculo Veiculo { get; set; }

        public decimal ValorHora => 200;
    }
}
