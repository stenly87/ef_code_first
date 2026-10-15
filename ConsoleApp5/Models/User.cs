using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp5.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    // Ограничиваем тип через varchar
    [MaxLength(255)]
    public string Name { get; set; } = null!; // обязательное поле
   
    [Column("Nickname", TypeName = "text")]
    public string? Nick { get; set; } // необязательное поле из-за ?
    
    [Required]
    [MaxLength(255)]
    public string? Password { get; set; } // атрибут Required задаст обязательное поле, даже если тип nullable

    // создание внешнего ключа для связи с таблицей ролей
    // пользователю соответствует одна роль
    public Role? Role { get; set; }
}