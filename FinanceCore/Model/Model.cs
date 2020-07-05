using FinanceCore.Model;
using FinanceCore.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinanceCore.Model
{
    public class FinDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=fin.db");
    }

    public class Event : ObservableBase
    {
        private int eventId;
        public int EventId
        {
            get => eventId;
            set => Set(ref eventId, value);
        }

        private int userId;
        public int UserId
        {
            get => userId;
            set => Set(ref userId, value);
        }

        private User user;
        public User User { get => user;
            set => Set(ref user, value); }

        private DateTime date;
        public DateTime Date { get => date; set => Set(ref date, value); }

        private decimal amount;
        public decimal Amount { get => amount; set => Set(ref amount, value); }

        private int categoryId;
        public int CategoryId { get => categoryId; set => Set(ref categoryId, value); }

        private Category category;
        public Category Category { get => category; set => Set(ref category, value); }

        private string name;
        public string Name { get => name; set => Set(ref name, value); }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }

    public class Category: ObservableBase
    {
        private int categoryId;
        public int CategoryId { get => categoryId; set => Set(ref categoryId, value); }
        
        private string name;
        public string Name { get => name; set => Set(ref name, value); }
    }
}
