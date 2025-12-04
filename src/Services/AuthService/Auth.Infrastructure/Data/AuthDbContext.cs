using Auth.Domain.Entities;
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Data
{
    /// <summary>
    /// DbContext para o domínio de autenticação.
    /// </summary>
    public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                    entry.Property("ModificationDate").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nome).IsRequired().HasMaxLength(100);
                entity.OwnsOne(u => u.Email, e =>
                {
                    e.Property(p => p.Address).HasColumnName("Email").IsRequired();
                });
                entity.OwnsOne(u => u.Senha, s =>
                {
                    s.Property(p => p.Valor).HasColumnName("Senha").IsRequired();
                });
            });
        }
    }

}
