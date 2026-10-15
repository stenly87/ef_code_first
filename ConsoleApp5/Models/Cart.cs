using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5.Models;

public class Cart
{
    public int Id { get; set; }
    [MaxLength(255)]
    
    public User User { get; set; }
    public IEnumerable<Product> Products { get; set; }
}