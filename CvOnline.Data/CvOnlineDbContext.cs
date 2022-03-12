using CvOnline.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace CvOnline.Infrastructure
{
    public class CvOnlineDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Entreprise> Entreprise { get; }
        public DbSet<Address> Address { get; }
        public DbSet<CV> CV { get; set; }


        public CvOnlineDbContext(DbContextOptions<CvOnlineDbContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Methode pour configuration d'autre options.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}
