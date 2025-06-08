using Microsoft.EntityFrameworkCore; // allow us to inherit ifo from DBContext
namespace FilmApp.Models


{
    public class FilmContext : DbContext // the parent clase where Film construcure gets passed
    {
        public DbSet<FilmModel> Film { get; set; } = null!; // is a list of movies, that is comming from the database (This property is going to be used to store oure movies)
        public FilmContext(DbContextOptions<FilmContext> options) : base(options) { } // methode that haves a same name as a class is called constructore. It allows us to configure oure DB Contex

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>().HasData(
                new FilmModel() { Id = 1, Navn = "How To Be Single", AAr = 2016, Poeng = 5 },
                new FilmModel() { Id = 2, Navn = "Senior Year", AAr = 2022, Poeng = 3 },
                new FilmModel() { Id = 3, Navn = "The Wrong Missy", AAr = 2020, Poeng = 4 }
                );
        }
    }
}


