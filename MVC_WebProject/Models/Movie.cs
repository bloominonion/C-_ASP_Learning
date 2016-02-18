using System;
using System.Data.Entity;

namespace MVC_WebProject.Models
{

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Car> Cars { get; set; }
    }


    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        //Added field for comments
        //Added migration to this, then update-database
        public string Comments { get; set; }
    }

    public class Car
    {

        public int ID { get; set; }
        public string ModelName { get; set; }
    }
}