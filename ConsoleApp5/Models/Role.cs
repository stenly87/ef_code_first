using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp5.Models;

// атрибут позволяет поменять имя таблицы
[Table("UserRoles")] 
public class Role
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string? Title { get; set; }
    
    // создание внешнего ключа для связи с таблицей ролей
    // роли соответствует много пользователей
    public IEnumerable<User> Users { get; set; }
}