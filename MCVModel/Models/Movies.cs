using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
//namespace MVC.Model.Models

namespace MVCModel.Models

{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string  Name { get; set; }

        [Required]
        public string  Genre { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Duration should be between 1 to 10")]
        public int duration { get; set; }

        public int year { get; set; } = 0;

        public DateTime DateTime { get; set; } = DateTime.Now;

      

    }
}
