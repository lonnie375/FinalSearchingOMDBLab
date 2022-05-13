using System.ComponentModel.DataAnnotations;

namespace SearchingOMDBInClassLab.Models
{
    public class SearchMovie
    {
        [Required]
        public string SearchTerm { get; set; } 
    }
}
