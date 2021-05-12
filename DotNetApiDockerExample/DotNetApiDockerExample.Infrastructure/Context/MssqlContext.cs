using DotNetApiDockerExample.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace DotNetApiDockerExample.Infrastructure.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(u =>
            {
                u.ToTable("Usuario");
                u.HasKey(k => k.Id);
                u.Property<int>(p => p.Id).ValueGeneratedOnAdd().HasColumnType("int").HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                u.Property<string>(p => p.Nome).HasColumnType("varchar(50)");
                u.Property<string>(p => p.Sobrenome).HasColumnType("varchar(50)");
                u.Property<string>(p => p.Cpf).HasColumnType("varchar(11)");
                u.Property<DateTime>(p => p.DataNascimento).HasColumnType("datetime");
            });
        }
    }
}
