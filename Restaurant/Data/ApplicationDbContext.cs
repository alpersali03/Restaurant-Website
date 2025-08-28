using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Models;
using System.Reflection.Emit;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

               // Customer relationship
                builder.Entity<Order>()
                    .HasOne(o => o.IdentityUser)
                    .WithMany()
                    .HasForeignKey(o => o.IdentityUserId)
                    .OnDelete(DeleteBehavior.Restrict);
              

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pizza", IconUrl = "https://cdn-icons-png.flaticon.com/512/1404/1404945.png" },
                new Category { Id = 2, Name = "Desserts", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046784.png" },
                new Category { Id = 3, Name = "Drinks", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046786.png" },
                new Category { Id = 4, Name = "Salads", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046795.png" },
                new Category { Id = 5, Name = "Pasta", IconUrl = "https://cdn-icons-png.flaticon.com/512/1404/1404948.png" },
                new Category { Id = 6, Name = "Soups", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046803.png" },
                new Category { Id = 7, Name = "Snacks", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046790.png" },
                new Category { Id = 8, Name = "Vegetarian", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046841.png" },
                new Category { Id = 9, Name = "Breakfast", IconUrl = "https://cdn-icons-png.flaticon.com/512/1046/1046779.png" },
                new Category { Id = 10, Name = "Burgers", IconUrl = "https://cdn-icons-png.flaticon.com/512/1404/1404942.png" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Margherita", Description = "Classic tomato, mozzarella, and basil pizza.", Price = 49.90M, IsAvailable = true, CategoryId = 1, ImageUrl = "https://source.unsplash.com/600x400/?margherita,pizza"}, 
                new Product { Id = 2, Name = "Nutella Pizza", Description = "Sweet pizza topped with Nutella and fruits.", Price = 59.90M, IsAvailable = true, CategoryId = 2, ImageUrl = "https://source.unsplash.com/600x400/?nutella,dessert"}, 
                new Product { Id = 3, Name = "Coca-Cola", Description = "330ml cold soft drink.", Price = 9.90M, IsAvailable = true, CategoryId = 3, ImageUrl = "https://source.unsplash.com/600x400/?coca-cola,drink"},  // DRINKS5
                new Product { Id = 4, Name = "Caesar Salad", Description = "Chicken, croutons, and parmesan.", Price = 38.50M, IsAvailable = true, CategoryId = 4, ImageUrl = "https://source.unsplash.com/600x400/?caesar,salad"},  
                new Product { Id = 5, Name = "Penne Arrabbiata", Description = "Spicy tomato pasta.", Price = 42.00M, IsAvailable = true, CategoryId = 5, ImageUrl = "https://source.unsplash.com/600x400/?penne,pasta"},  // SUMMER15
                new Product { Id = 6, Name = "Lentil Soup", Description = "Traditional Turkish red lentil soup.", Price = 19.00M, IsAvailable = true, CategoryId = 6, ImageUrl = "https://source.unsplash.com/600x400/?lentil,soup" },  // RETRY10
                new Product { Id = 7, Name = "Mozzarella Sticks", Description = "Deep-fried mozzarella cheese.", Price = 27.00M, IsAvailable = true, CategoryId = 7, ImageUrl = "https://source.unsplash.com/600x400/?mozzarella,snacks"},  // RETRY10
                new Product { Id = 8, Name = "Vegetable Casserole", Description = "Oven-roasted seasonal vegetables.", Price = 35.00M, IsAvailable = true, CategoryId = 8, ImageUrl = "https://source.unsplash.com/600x400/?vegetable,meal"},  // VEGAN25
                new Product { Id = 9, Name = "Breakfast Platter", Description = "Traditional Turkish breakfast assortment.", Price = 69.00M, IsAvailable = true, CategoryId = 9, ImageUrl = "https://source.unsplash.com/600x400/?breakfast,food"}, // BREAKFAST30
                new Product { Id = 10, Name = "Cheeseburger", Description = "Beef patty with cheddar cheese.", Price = 48.00M, IsAvailable = true, CategoryId = 10, ImageUrl = "https://source.unsplash.com/600x400/?cheeseburger"}   // BURGER50
            );


            builder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, CustomerName = "John Smith", PhoneNumber = "5551234567", GuestCount = 2, ReservationDate = DateTime.Today.AddDays(1), Notes = "Window seat", Status = ReservationStatus.Confirmed },
                new Reservation { Id = 2, CustomerName = "Emily Johnson", PhoneNumber = "5552345678", GuestCount = 4, ReservationDate = DateTime.Today.AddHours(18), Notes = "", Status = ReservationStatus.Pending },
                new Reservation { Id = 3, CustomerName = "Michael Lee", PhoneNumber = "5553456789", GuestCount = 3, ReservationDate = DateTime.Today.AddDays(2), Notes = "Birthday celebration", Status = ReservationStatus.Confirmed },
                new Reservation { Id = 4, CustomerName = "Sophia Davis", PhoneNumber = "5554567890", GuestCount = 5, ReservationDate = DateTime.Today.AddDays(3), Notes = "", Status = ReservationStatus.Pending },
                new Reservation { Id = 5, CustomerName = "David Brown", PhoneNumber = "5555678901", GuestCount = 2, ReservationDate = DateTime.Today.AddHours(21), Notes = "Romantic table", Status = ReservationStatus.Confirmed },
                new Reservation { Id = 6, CustomerName = "Olivia Wilson", PhoneNumber = "5556789012", GuestCount = 6, ReservationDate = DateTime.Today.AddDays(1), Notes = "", Status = ReservationStatus.Cancelled },
                new Reservation { Id = 7, CustomerName = "James Miller", PhoneNumber = "5557890123", GuestCount = 3, ReservationDate = DateTime.Today.AddHours(19), Notes = "Non-smoking area", Status = ReservationStatus.Confirmed },
                new Reservation { Id = 8, CustomerName = "Ava Martinez", PhoneNumber = "5558901234", GuestCount = 1, ReservationDate = DateTime.Today.AddDays(4), Notes = "", Status = ReservationStatus.Pending },
                new Reservation { Id = 9, CustomerName = "William Anderson", PhoneNumber = "5559012345", GuestCount = 2, ReservationDate = DateTime.Today.AddDays(2), Notes = "", Status = ReservationStatus.Confirmed },
                new Reservation { Id = 10, CustomerName = "Emma Thomas", PhoneNumber = "5550123456", GuestCount = 4, ReservationDate = DateTime.Today.AddDays(5), Notes = "Birthday dinner", Status = ReservationStatus.Pending }
            );

            builder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, Code = "HELLO2025", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(1) },
                new Coupon { Id = 2, Code = "HELLOSUMMER", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(10) },
                new Coupon { Id = 3, Code = "WELCOME", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(30) },
                new Coupon { Id = 4, Code = "BIGDISCOUNT", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(15) },
                new Coupon { Id = 5, Code = "BESTPLACE", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(2) },
                new Coupon { Id = 6, Code = "MEMORIES", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5) },
                new Coupon { Id = 7, Code = "HAVEFUN25", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7) },
                new Coupon { Id = 8, Code = "ANNIVERSARRY", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(20) },
                new Coupon { Id = 9, Code = "LETSDRINK", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(15) },
                new Coupon { Id = 10, Code = "LETSEAT", Percentage = PercentageRate.low, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(12) }
            );

            builder.Entity<Review>().HasData(
                new Review { Id = 1, CustomerName = "John", Rating = 5, Comment = "Amazing flavor!", CreatedAt = DateTime.Now },
                new Review { Id = 2, CustomerName = "Emily", Rating = 4, Comment = "Great taste but a bit salty.", CreatedAt = DateTime.Now },
                new Review { Id = 3, CustomerName = "Michael", Rating = 3, Comment = "Average meal.", CreatedAt = DateTime.Now },
                new Review { Id = 4, CustomerName = "Sophia", Rating = 5, Comment = "Absolutely loved it!", CreatedAt = DateTime.Now },
                new Review { Id = 5, CustomerName = "David", Rating = 2, Comment = "Not what I expected.", CreatedAt = DateTime.Now },
                new Review { Id = 6, CustomerName = "Olivia", Rating = 4, Comment = "Tasty and well presented.", CreatedAt = DateTime.Now },
                new Review { Id = 7, CustomerName = "James", Rating = 5, Comment = "Top quality!", CreatedAt = DateTime.Now },
                new Review { Id = 8, CustomerName = "Ava", Rating = 3, Comment = "It was okay.", CreatedAt = DateTime.Now },
                new Review { Id = 9, CustomerName = "William", Rating = 4, Comment = "Quick service, nice meal.", CreatedAt = DateTime.Now },
                new Review { Id = 10, CustomerName = "Emma", Rating = 5, Comment = "Best burger I've had!", CreatedAt = DateTime.Now }
            );


        }

    }
}
