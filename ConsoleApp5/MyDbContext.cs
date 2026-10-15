using ConsoleApp5.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp5;

public class MyDbContext : DbContext
{
    // ТУТ КОНСТАНТА ТОЛЬКО ДЛЯ ПРИМЕРА. ЭТО ПЛОХО. ОЧЕНЬ.
    private const string CONNECTION = "server=192.168.200.13;user=student;password=student;database=1135_from_ef;";
    public DbSet<User> Users { get; set; } // объявляем таблицу
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }

    // конструктор для случаев, когда мы хотим code first (создать бд из кода)
    public MyDbContext()
    {
        //Database.EnsureDeleted(); // в связке с этим методом получится пересоздание
        // создание базы данных, если ее не существует
        Database.EnsureCreated();
    }

    // данный метод для указания строки соединения
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(CONNECTION, new MariaDbServerVersion(
            ServerVersion.AutoDetect(CONNECTION))
        );
        base.OnConfiguring(optionsBuilder);
    }

    // данный метод для настройки таблиц через fluent код
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        // HasAlternateKey - создать уникальный индекс для колонки -> уникальные значения
        modelBuilder.Entity<Role>().HasAlternateKey(s => s.Title);
        
        // через HasKey можно указать составной первичный ключ
        // вариант с ручным указанием столбцов
        //modelBuilder.Entity<UserInfo>().HasKey(["PassportSerial", "PassportNumber"]);
        // вариант с указанием свойств
        modelBuilder.Entity<UserInfo>().HasKey(s => new { s.PassportSerial, s.PassportNumber });
    }
}