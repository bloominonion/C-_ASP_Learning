using System;
using System.ComponentModel.DataAnnotations;
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

        //This is to reformat the output display of the release date in a friendly format.
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]

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