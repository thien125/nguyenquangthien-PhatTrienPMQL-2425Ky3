using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    public class Person
    {
        [Key]
        public required string PersonId { get; set; }
        [MinLength(5, ErrorMessage = "Full name must be at least 5 characters long.")]
        public string? FullName { get; set; }
        public string? Address { get; set; }
    }
}
