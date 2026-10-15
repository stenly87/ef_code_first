using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5.Models;

public class UserInfo
{
    public string PassportSerial { get; set; }
    public string PassportNumber { get; set; }
    
    public DateTime DateGet { get; set; }
    
    public User User { get; set; }
}

