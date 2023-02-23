using Microsoft.EntityFrameworkCore;
using SplitWebAPI.Models;

namespace SplitWebAPI.DataBase
{
    public class SplitContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Benefiter> Benefiters { get; set; }

        public SplitContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SplitContext;Integrated Security=True")
                    .LogTo(Console.WriteLine); //Пока захардкодил. Не получается получить свойство GetConnectionString из appsettings
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefiter>()
                .HasOne(b => b.User)
                .WithMany(u => u.Benefiters)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static User GetUserById(int id)
        {
            using (SplitContext _db = new())
            {
                User entity = _db.Users.Find(id);
                return entity;
            }
        }

        public static void DeleteUserById(int id)
        {
            using (SplitContext _db = new())
            {

                _db.Users.Remove(GetUserById(id));
                _db.SaveChanges();
            }
        }

        public static void DeleteAllUsers()
        {
            using (SplitContext _db = new())
            {
                foreach (User u in _db.Users)
                {
                    _db.Users.Remove(u);
                }
                _db.SaveChanges();
            }
        }

        
    }
}