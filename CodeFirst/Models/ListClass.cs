using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class ListClass
    {
        [Key]
        public string? AllItems { get; set; }
    }
}
