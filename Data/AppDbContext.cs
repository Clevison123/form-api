using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using FormAPI.Models;

namespace FormAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet pode continuar como Forms, mas vamos mapear para a tabela correta
        public DbSet<PersonForm> Forms => Set<PersonForm>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeia a entidade PersonForm para a tabela FormDb
            modelBuilder.Entity<PersonForm>().ToTable("PersonForms");
        }
    }
}
