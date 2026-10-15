using ConsoleApp5;
using ConsoleApp5.Models;

var db = new MyDbContext();
var role = new Role { Title = "Администратор" };
var user = new User
{
    Name = "Админ",
    Password =  "123456",
    Role = role
};
db.Users.Add(user);
db.SaveChanges();

Console.WriteLine("Hello ef!");