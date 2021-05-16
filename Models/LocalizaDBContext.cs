using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalizaCS.Models
{
    public partial class LocalizaDBContext : DbContext
    {
        public LocalizaDBContext()
        {
        }

        public LocalizaDBContext(DbContextOptions<LocalizaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClientes> TbClientes { get; set; }
        public virtual DbSet<TbMarcaVeiculo> TbMarcaVeiculo { get; set; }
        public virtual DbSet<TbModeloVeiculo> TbModeloVeiculo { get; set; }
        public virtual DbSet<TbOperadores> TbOperadores { get; set; }
        public virtual DbSet<TbVeiculo> TbVeiculo { get; set; }
        public virtual DbSet<TbLocacoes> TbLocacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbClientes>(entity =>
            {
                entity.ToTable("tbClientes");

                entity.Property(e => e.Aniversario).HasColumnType("date");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Cidade)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Complemento)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Nro)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbMarcaVeiculo>(entity =>
            {
                entity.ToTable("tbMarcaVeiculo");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbModeloVeiculo>(entity =>
            {
                entity.ToTable("tbModeloVeiculo");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TbModeloVeiculo)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModeloVeiculo_ToTbMarcaVeiculo");
            });

            modelBuilder.Entity<TbOperadores>(entity =>
            {
                entity.ToTable("tbOperadores");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbVeiculo>(entity =>
            {
                entity.ToTable("tbVeiculo");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Combustivel)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.ValorHora).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.MarcaId)
                    .HasMaxLength(10);
                /*entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TbVeiculo)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVeiculo_ToTbMarcaVeiculo");*/

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.TbVeiculo)
                    .HasForeignKey(d => d.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVeiculo_ToTbModeloVeiculo");
            });

            modelBuilder.Entity<TbLocacoes>(entity =>
            {
                entity.ToTable("tbLocacoes");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.TbLocacoes)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbLocacoes_ToTbClientes");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.TbLocacoes)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbLocacoes_ToTbVeiculo");

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.Property(e => e.Termino).HasColumnType("datetime");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}