﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class TbMarcaVeiculo
    {
        public TbMarcaVeiculo()
        {
            TbModeloVeiculo = new HashSet<TbModeloVeiculo>();
            TbVeiculo = new HashSet<TbVeiculo>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }

        public virtual ICollection<TbModeloVeiculo> TbModeloVeiculo { get; set; }
        public virtual ICollection<TbVeiculo> TbVeiculo { get; set; }
    }
}
