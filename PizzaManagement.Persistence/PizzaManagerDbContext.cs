using Microsoft.EntityFrameworkCore;
using PizzaManagement.Domain.Addresses;
using PizzaManagement.Domain.Images;
using PizzaManagement.Domain.Orders;
using PizzaManagement.Domain.Pizzas;
using PizzaManagement.Domain.Users;
using PizzaManagement.Domain.RankHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaManagement.Domain;

namespace PizzaManagement.Persistence
{
    public class PizzaManagerDbContext:DbContext
    {
        public PizzaManagerDbContext(DbContextOptions<PizzaManagerDbContext> options)
            :base(options)
        {

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AutoSave();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            AutoSave();
            return base.SaveChanges();
        }
        private void AutoSave()
        {//Entity is also my abstract class
            var entries = ChangeTracker
               .Entries()
               .Where(e => e.Entity is Entity && (
               e.State == EntityState.Added
               || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((Entity)entry.Entity).UpdatedOn = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedOn = DateTime.Now;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasOne<Image>(p=>p.Image)
                .WithOne(p => p.Pizza)
                .HasForeignKey<Pizza>(p => p.ImageId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<Address>(u => u.Adresses)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RankHistory>()
                .HasOne<User>(rh => rh.User)
                .WithMany()
                .HasForeignKey(rh => rh.UserId);

            modelBuilder.Entity<RankHistory>()
                .HasOne<Pizza>(rh=>rh.Pizza)
                .WithMany(p=>p.RankHistories)
                .HasForeignKey(rh=>rh.PizzaId);

            modelBuilder.Entity<Order>()
                .HasOne<Pizza>(p => p.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PizzaId);

            modelBuilder.Entity<Order>()
                .HasOne<Address>(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId);

            modelBuilder.Entity<Order>()
                .HasOne<User>(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);


            modelBuilder.Entity<User>()
                .Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RankHistory>()
                .Property(rh => rh.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Pizza>()
                .Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>()
                .Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Address>()
                .Property(a => a.Id).ValueGeneratedOnAdd();


        }
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<RankHistory>? RankHistories { get; set; }

    }
}
