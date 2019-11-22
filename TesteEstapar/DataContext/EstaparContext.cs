using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Models;

namespace TesteEstapar.DataContext
{
    public class EstaparContext : DbContext
    {
        public EstaparContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manobrista>().HasKey(k => k.Cpf);
            modelBuilder.Entity<Veiculo>().HasKey(k => k.Placa);

            //modelBuilder.HasSequence<int>("ManobristaVeiculo_seq", "dbo")
            //    .StartsAt(0)
            //    .IncrementsBy(1);


            modelBuilder.Entity<ManobristaVeiculo>()
                .Property(p=> p.IdManobra)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ManobristaVeiculo>().HasKey(k => k.IdManobra);
            modelBuilder.Entity<ManobristaVeiculo>().Ignore(p => p.Veiculo);
            modelBuilder.Entity<ManobristaVeiculo>().Ignore(p => p.Manobrista);
            
            modelBuilder.Entity<ManobristaVeiculo>()
                .HasOne(mv => mv.Manobrista)
                .WithOne(m => m.ManobristaVeiculo)
                .HasForeignKey<ManobristaVeiculo>(fk => fk.CpfManobrista);
            modelBuilder.Entity<ManobristaVeiculo>()
                .HasOne(mv => mv.Veiculo)
                .WithOne(v => v.ManobristaVeiculo)
                .HasForeignKey<ManobristaVeiculo>(fk => fk.PlacaVeiculo);



        }

        public DbSet<Manobrista> Manobristas { get; set; }
        public DbSet<Veiculo> Veiculos { get;set; }

        public DbSet<ManobristaVeiculo> ManobristasVeiculos { get; set; }
    }
}
