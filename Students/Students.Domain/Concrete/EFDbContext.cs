using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Students.Domain.Entities;
using System.Threading.Tasks;

namespace Students.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<HousingAnnouncment> HousingAnnouncments { get; set; }

        public DbSet<TravelAnnouncment> TravelAnnouncments { get; set; }

        public DbSet<MarketAnnouncment> MarketAnnouncments { get; set; }   

        public DbSet<ServiceAnnouncment> ServiceAnnouncments { get; set; }

        public DbSet<HousingComment> HousingComments { get; set; }

        public DbSet<TravelComment> TravelComments { get; set; }

        public DbSet<MarketComment> MarketComments { get; set; }

        public DbSet<ServiceComment> ServiceComments { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HousingComment>()
                .HasRequired(hc => hc.User)
                .WithMany(u => u.HousingComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HousingComment>()
                .HasRequired(hc => hc.HousingAnnouncment)
                .WithMany(ha => ha.HousingComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelComment>()
                .HasRequired(tc => tc.User)
                .WithMany(u => u.TravelComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelComment>()
                .HasRequired(tc => tc.TravelAnnouncment)
                .WithMany(ta => ta.TravelComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MarketComment>()
                .HasRequired(mc => mc.User)
                .WithMany(u => u.MarketComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MarketComment>()
                .HasRequired(mc => mc.MarketAnnouncment)
                .WithMany(ma => ma.MarketComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceComment>()
                .HasRequired(sc => sc.User)
                .WithMany(u => u.ServiceComments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceComment>()
                .HasRequired(sc => sc.ServiceAnnouncment)
                .WithMany(sa => sa.ServiceComments)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// test speed with this method and without it
        /// </summary>
        /// <returns></returns>
        public static bool HasUnsavedChanges(EFDbContext context)
        {
            return context.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                      || e.State == EntityState.Modified
                                                      || e.State == EntityState.Deleted);
        }
    }
}
