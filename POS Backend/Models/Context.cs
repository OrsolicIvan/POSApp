using POS_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace POS_Backend.Models
{
    public class Context :
        IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JedinicaMjere>()
                .HasMany(pr => pr.Proizvodi)
                .WithOne(jm => jm.JedinicaMjere)
                .HasForeignKey(i => i.JedinicaId);
            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.AppUser)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            modelBuilder.Entity<ZaglavljeRacuna>()
                .HasMany(z => z.StavkeRacuna)
                .WithOne(s => s.ZaglavljeRacuna)
                .HasForeignKey(s => s.ZaglavljeRacunaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Proizvod>()
                .HasMany(p => p.StavkeRacuna)
                .WithOne(s => s.Proizvod)
                .HasForeignKey(s => s.ProizvodId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Kupac>()
                .HasMany(k => k.ZaglavljeRacuna)
                .WithOne(z => z.Kupac)
                .HasForeignKey(z => z.KupacId);

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<ZaglavljeRacuna> ZaglavljeRacuna { get; set; }
        public DbSet<StavkaRacuna> StavkeRacuna { get; set; }
        public DbSet<JedinicaMjere> JediniceMjere { get; set; }
        
        
    }
}
