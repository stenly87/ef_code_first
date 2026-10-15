using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5.Models;

public class Product
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Name { get; set; }
    public IEnumerable<Cart> Carts { get; set; }
}