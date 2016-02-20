using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace MVC_WebProject.Models
{

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MVC_WebProject.Models.FieldControls> FieldControls { get; set; }
    }


    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Title { get; set; }

        //This is to reformat the output display of the release date in a friendly format.
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [StringLength(10)]
        public string Rating { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //Added field for comments
        //Added migration to this, then update-database
        public string Comments { get; set; }  
    }

    public class FieldControls
    {
        public int ID { get; set; }
        public string ControlName { get; set; }
        public string Control1 { get; set; }
        public string Control2 { get; set; }
    }
}
