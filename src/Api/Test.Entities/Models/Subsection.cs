
using System.ComponentModel.DataAnnotations;

namespace Test.Entities.Models;

public class Subsection
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
