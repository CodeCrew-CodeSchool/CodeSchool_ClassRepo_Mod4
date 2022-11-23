using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class TestDbContext : DbContext
    {
		public DbSet<Cast> Casts { get; set; }

		public DbSet<Person> People { get; set; }

		public DbSet<Show> Shows { get; set; }
		public DbSet<Venue> Venues { get; set; }

		public TestDbContext(DbContextOptions options) : base(options)
        {

            

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Person John = new Person() { ID = 1, Name = "John Doe" };
            //Venue MemphisOrpheum = new Venue() { Id = 1, Name = "Memphis Orpheum" };
            //Show MLTC = new Show() { Id = 1, Title = "Madea Learns to Code", Venue = MemphisOrpheum};
            //Cast cast = new Cast() { Id = 1, JobTitle = "Actor", PersonId=John.ID, PersonName=John.Name, ShowId=MLTC.Id, ShowName=MLTC.Title};
            //MLTC.Cast = cast;
            //var j = new { CastId = cast.Id, ID = John.ID, Name = John.Name };
            //var s = new { CastId = cast.Id, Id = MLTC.Id, Title = MLTC.Title, VenueId = MLTC.Venue.Id };
            ////mb.Entity<Person>().HasData(John);
            //mb.Entity<Venue>().HasData(MemphisOrpheum);
            
            ////mb.Entity<Show>().HasData(MLTC);
            //mb.Entity<Cast>(c =>
            //{
                
            //    c.HasData(cast);
            //    c.OwnsOne(p => p.Person).HasData(j);
            //    c.OwnsOne(s => s.Show).HasData(s);
            //});
        }
       
    }
}
