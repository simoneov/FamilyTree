using FamilyTree.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace FamilyTree.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonPerson> PeoplePeople { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonPerson>()
    .HasKey(x => new { x.ParentId, x.ChildId });

            modelBuilder.Entity<PersonPerson>()
                .HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<PersonPerson>()
                .HasOne(x => x.Child)
                .WithMany(x => x.Parents)
                .HasForeignKey(x => x.ChildId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Wedding>()
                .HasOne(x => x.Husband)
                .WithMany(x => x.Wives)
                .HasForeignKey(x => x.HusbandId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Wedding>()
                .HasOne(x => x.Wife)
                .WithMany(x => x.Husbands)
                .HasForeignKey(x => x.WifeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
