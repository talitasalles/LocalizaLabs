using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LocalizaCS.Data
{
    public class LocalizaCSContext : DbContext
    {
        public LocalizaCSContext (DbContextOptions<LocalizaCSContext> options)
            : base(options)
        {
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            { }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }
        }

    public DbSet<LocalizaCS.Models.TbClientes> TbClientes { get; set; }

        public DbSet<LocalizaCS.Models.TbOperadores> TbOperadores { get; set; }

        public DbSet<LocalizaCS.Models.TbVeiculo> TbVeiculo { get; set; }

        public DbSet<LocalizaCS.Models.TbModeloVeiculo> TbModeloVeiculo { get; set; }

        public DbSet<LocalizaCS.Models.TbMarcaVeiculo> TbMarcaVeiculo { get; set; }

        public DbSet<LocalizaCS.Models.TbLocacoes> TbLocacoes { get; set; }
    }
}
