using PruebaTecnicaSignos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PruebaTecnicaSignos.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // 📦 DbSets
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<UnidadMedida> UnidadesMedida => Set<UnidadMedida>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔑 Claves explícitas (aunque por convención ya se reconocen)
            modelBuilder.Entity<Producto>().HasKey(p => p.ProductoId);
            modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaId);
            modelBuilder.Entity<Proveedor>().HasKey(p => p.ProveedorId);
            modelBuilder.Entity<UnidadMedida>().HasKey(u => u.UnidadId);

            // 🔗 Relaciones correctas
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Productos)
                .HasForeignKey(p => p.ProveedorId);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.UnidadMedida)
                .WithMany(u => u.Productos)
                .HasForeignKey(p => p.UnidadId);

            // 🔒 Mapea nombres exactos (opcional)
            modelBuilder.Entity<UnidadMedida>().ToTable("UnidadesMedida");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
        }
    }
}
