using EMedicineBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EMedicineBackend.Data
{
    public class EMedicineDbContext : DbContext
    {
        public EMedicineDbContext(DbContextOptions<EMedicineDbContext> options) : base(options) { }
        public DbSet<DataAccessLayer> EmedDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasKey(am => new
            {
                am.id,
                am.userId
            });



            //modelBuilder.Entity<Cart>().HasOne(m => m.unitprice)
            //.WithMany(am => am.Actor_Movie).HasForeignKey(m => m.MovieID);

            //modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
            //.WithMany(at => at.Actors_Movies).HasForeignKey(a => a.ActorID);


            base.OnModelCreating(modelBuilder);

        }
    }
