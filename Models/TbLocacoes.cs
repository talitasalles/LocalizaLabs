using System;
using System.Collections.Generic;

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

        public virtual TbClientes Cliente { get; set; }
        public virtual TbVeiculo Veiculo { get; set; }
    }
}
