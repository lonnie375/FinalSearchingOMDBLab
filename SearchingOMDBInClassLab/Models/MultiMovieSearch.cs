using System.ComponentModel.DataAnnotations;

namespace SearchingOMDBInClassLab.Models
{
    public class MultiMovieSearch
    {
        [Required]
        public string Movie1 { get; set; }
        public string Movie2 { get; set; }  
        public string Movie3 { get; set; } 

    }
}
