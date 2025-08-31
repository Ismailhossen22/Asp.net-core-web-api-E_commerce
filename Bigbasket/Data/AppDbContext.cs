using Bigbasket_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Bigbasket_Ecommerce.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options  ):base(options)
        {
            
        }


       
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get;set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
 
        public DbSet<Order> Orders { get;set;}
        public DbSet<Employees> Employees { get;set;}
        public DbSet<Shipment> Shipments { get;set;}
        public DbSet<UserRole>UserRole { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasMany(u => u.RefreshTokens).WithOne(u => u.User)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.SetNull);
               
            });
            modelBuilder.Entity<User>(entity =>
            {

                entity.HasMany(c => c.CartItems).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(u => new { u.UserId, u.RoleId });//compsoit key
                entity.HasOne(u => u.User).WithMany(u => u.UserRole)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade) ;
                entity.HasOne(r => r.Role).WithMany(u => u.UserRole)
                .HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Cascade);
              
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.HasOne(p => p.Category).WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.CartItem).WithOne(c => c.Products)
                .HasForeignKey<CartItem>(c => c.ProductId).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.HasMany(e => e.Orders).WithOne(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasMany(o => o.Payments).WithOne(p => p.Order).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(o => o.OrderItems).WithOne(o => o.Order).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(o => o.Shipments).WithOne(s => s.Order).HasForeignKey(s => s.OrderId).OnDelete(DeleteBehavior.SetNull);

            });

           

           

            modelBuilder.Entity<Role>().Property(e => e.RoleId).UseIdentityColumn(seed: 101, increment: 1);
            modelBuilder.Entity<Category>().Property(e => e.CategoryId).UseIdentityColumn(seed: 101,increment: 1);
            modelBuilder.Entity<Shipment>().Property(e => e.ShipmentId).UseIdentityColumn(seed: 101,increment: 1);


            // Electronics (101)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Smartphone A1", ProductShortName = "SM-A1", ProductPrice = 15000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/smartphone_a1.jpg", ProductDescription = "High quality smartphone with 10 features.", CategoryId = 101 },
                new Product { ProductId = 2, ProductName = "Laptop B1", ProductShortName = "LP-B1", ProductPrice = 55000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/laptop_b1.jpg", ProductDescription = "Powerful laptop suitable for work and gaming.", CategoryId = 101 },
                new Product { ProductId = 3, ProductName = "Wireless Headphones C1", ProductShortName = "WH-C1", ProductPrice = 5000, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/headphones_c1.jpg", ProductDescription = "Comfortable wireless headphones for daily use.", CategoryId = 101 },
                new Product { ProductId = 4, ProductName = "Smartwatch D1", ProductShortName = "SW-D1", ProductPrice = 8000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/smartwatch_d1.jpg", ProductDescription = "Feature-packed smartwatch with long battery life.", CategoryId = 101 },
                new Product { ProductId = 5, ProductName = "Tablet E1", ProductShortName = "TB-E1", ProductPrice = 20000, DelevaryTimeSpan = "2-5 days", ImageFile = "https://example.com/images/tablet_e1.jpg", ProductDescription = "Compact tablet perfect for work and media.", CategoryId = 101 },
                new Product { ProductId = 6, ProductName = "Bluetooth Speaker F1", ProductShortName = "BS-F1", ProductPrice = 3500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/speaker_f1.jpg", ProductDescription = "Portable Bluetooth speaker with crystal clear sound.", CategoryId = 101 },
                new Product { ProductId = 7, ProductName = "Camera G1", ProductShortName = "CM-G1", ProductPrice = 25000, DelevaryTimeSpan = "3-6 days", ImageFile = "https://example.com/images/camera_g1.jpg", ProductDescription = "High-resolution camera for photography enthusiasts.", CategoryId = 101 }
            );

            // Fashion (102)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 8, ProductName = "Men's T-Shirt A2", ProductShortName = "TS-A2", ProductPrice = 800, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/tshirt_men_a2.jpg", ProductDescription = "Cotton t-shirt perfect for summer season.", CategoryId = 102 },
                new Product { ProductId =9 , ProductName = "Women's Dress B2", ProductShortName = "DR-B2", ProductPrice = 1500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/dress_women_b2.jpg", ProductDescription = "Elegant dress suitable for parties and events.", CategoryId = 102 },
                new Product { ProductId = 10, ProductName = "Men's Jeans C2", ProductShortName = "JN-C2", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/jeans_men_c2.jpg", ProductDescription = "Stylish and comfortable denim jeans.", CategoryId = 102 },
                new Product { ProductId = 11, ProductName = "Women's Jacket D2", ProductShortName = "JK-D2", ProductPrice = 2500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/jacket_women_d2.jpg", ProductDescription = "Warm jacket for chilly seasons.", CategoryId = 102 },
                new Product { ProductId = 12, ProductName = "Women's Jacket D2", ProductShortName = "JK-D2", ProductPrice = 2500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/jacket_women_d2.jpg", ProductDescription = "Warm jacket for chilly seasons.", CategoryId = 102 },
                new Product { ProductId = 13, ProductName = "Men's Shoes E2", ProductShortName = "SH-E2", ProductPrice = 2000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/shoes_men_e2.jpg", ProductDescription = "Comfortable and durable shoes for daily use.", CategoryId = 102 },
                new Product { ProductId =14 , ProductName = "Women's Sandals F2", ProductShortName = "SD-F2", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/sandals_women_f2.jpg", ProductDescription = "Lightweight and stylish sandals for summer.", CategoryId = 102 },
                new Product { ProductId = 15 , ProductName = "Fashion Handbag G2", ProductShortName = "HB-G2", ProductPrice = 3000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/handbag_g2.jpg", ProductDescription = "Trendy handbag to complement your outfit.", CategoryId = 102 }
            );

            // Home Appliances (103)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 16 , ProductName = "Microwave A3", ProductShortName = "MW-A3", ProductPrice = 8000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/microwave_a3.jpg", ProductDescription = "High efficiency microwave oven.", CategoryId = 103 },
                new Product { ProductId = 17 , ProductName = "Refrigerator B3", ProductShortName = "RF-B3", ProductPrice = 35000, DelevaryTimeSpan = "4-6 days", ImageFile = "https://example.com/images/fridge_b3.jpg", ProductDescription = "Spacious refrigerator with energy saving.", CategoryId = 103 },
                new Product { ProductId = 18 , ProductName = "Washing Machine C3", ProductShortName = "WM-C3", ProductPrice = 25000, DelevaryTimeSpan = "3-6 days", ImageFile = "https://example.com/images/washing_c3.jpg", ProductDescription = "Efficient washing machine for families.", CategoryId = 103 },
                new Product { ProductId = 19 , ProductName = "Air Conditioner D3", ProductShortName = "AC-D3", ProductPrice = 40000, DelevaryTimeSpan = "5-7 days", ImageFile = "https://example.com/images/ac_d3.jpg", ProductDescription = "Powerful AC to cool large rooms.", CategoryId = 103 },
                new Product { ProductId = 20 , ProductName = "Blender E3", ProductShortName = "BL-E3", ProductPrice = 3000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/blender_e3.jpg", ProductDescription = "Multi-function blender for kitchen use.", CategoryId = 103 },
                new Product { ProductId = 21 , ProductName = "Toaster F3", ProductShortName = "TS-F3", ProductPrice = 1500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/toaster_f3.jpg", ProductDescription = "Convenient toaster for breakfast.", CategoryId = 103 },
                new Product { ProductId = 22 , ProductName = "Electric Kettle G3", ProductShortName = "EK-G3", ProductPrice = 1800, DelevaryTimeSpan = "2-3 days", ImageFile = "https://example.com/images/kettle_g3.jpg", ProductDescription = "Fast boiling electric kettle.", CategoryId = 103 }
            );

            // Books (104)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId =23  , ProductName = "Novel A4", ProductShortName = "NV-A4", ProductPrice = 500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/novel_a4.jpg", ProductDescription = "Engaging novel with great story.", CategoryId = 104 },
                new Product { ProductId = 24 , ProductName = "Textbook B4", ProductShortName = "TB-B4", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/textbook_b4.jpg", ProductDescription = "Educational textbook for students.", CategoryId = 104 },
                new Product { ProductId = 25 , ProductName = "Comic Book C4", ProductShortName = "CB-C4", ProductPrice = 300, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/comic_c4.jpg", ProductDescription = "Fun comic book for kids.", CategoryId = 104 },
                new Product { ProductId = 26 , ProductName = "Science Book D4", ProductShortName = "SB-D4", ProductPrice = 800, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/science_d4.jpg", ProductDescription = "Informative science book.", CategoryId = 104 },
                new Product { ProductId = 27 , ProductName = "History Book E4", ProductShortName = "HB-E4", ProductPrice = 700, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/history_e4.jpg", ProductDescription = "Interesting history book.", CategoryId = 104 },
                new Product { ProductId = 28 , ProductName = "Dictionary F4", ProductShortName = "DC-F4", ProductPrice = 900, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/dictionary_f4.jpg", ProductDescription = "Comprehensive dictionary.", CategoryId = 104 },
                new Product { ProductId = 29 , ProductName = "Magazine G4", ProductShortName = "MG-G4", ProductPrice = 400, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/magazine_g4.jpg", ProductDescription = "Latest magazine for readers.", CategoryId = 104 }
            );

            // Toys (105)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 30 , ProductName = "Action Figure A5", ProductShortName = "AF-A5", ProductPrice = 800, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/action_figure_a5.jpg", ProductDescription = "Collectible action figure toy for kids.", CategoryId = 105 },
                new Product { ProductId = 31 , ProductName = "Doll B5", ProductShortName = "DL-B5", ProductPrice = 500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/doll_b5.jpg", ProductDescription = "Beautiful doll with dress and accessories.", CategoryId = 105 },
                new Product { ProductId = 32 , ProductName = "Puzzle C5", ProductShortName = "PZ-C5", ProductPrice = 300, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/puzzle_c5.jpg", ProductDescription = "Fun puzzle game to improve problem solving.", CategoryId = 105 },
                new Product { ProductId =33  , ProductName = "Toy Car D5", ProductShortName = "TC-D5", ProductPrice = 400, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/toy_car_d5.jpg", ProductDescription = "Miniature car for kids to play.", CategoryId = 105 },
                new Product { ProductId = 34 , ProductName = "Board Game E5", ProductShortName = "BG-E5", ProductPrice = 700, DelevaryTimeSpan = "2-5 days", ImageFile = "https://example.com/images/board_game_e5.jpg", ProductDescription = "Family board game for fun evenings.", CategoryId = 105 },
                new Product { ProductId = 35 , ProductName = "Building Blocks F5", ProductShortName = "BB-F5", ProductPrice = 600, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/blocks_f5.jpg", ProductDescription = "Colorful building blocks for kids.", CategoryId = 105 },
                new Product { ProductId = 36 , ProductName = "Remote Car G5", ProductShortName = "RC-G5", ProductPrice = 1500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/remote_car_g5.jpg", ProductDescription = "Remote control car with rechargeable battery.", CategoryId = 105 }
            );

            // Sports (106)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId =37  , ProductName = "Football A6", ProductShortName = "FB-A6", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/football_a6.jpg", ProductDescription = "Official size football for matches.", CategoryId = 106 },
                new Product { ProductId = 38 , ProductName = "Basketball B6", ProductShortName = "BB-B6", ProductPrice = 1500, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/basketball_b6.jpg", ProductDescription = "Durable basketball for indoor/outdoor use.", CategoryId = 106 },
                new Product { ProductId = 39 , ProductName = "Tennis Racket C6", ProductShortName = "TR-C6", ProductPrice = 2000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/racket_c6.jpg", ProductDescription = "Lightweight tennis racket for beginners.", CategoryId = 106 },
                new Product { ProductId = 40 , ProductName = "Cricket Bat D6", ProductShortName = "CB-D6", ProductPrice = 2500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/bat_d6.jpg", ProductDescription = "Professional grade cricket bat.", CategoryId = 106 },
                new Product { ProductId = 41 , ProductName = "Gym Gloves E6", ProductShortName = "GG-E6", ProductPrice = 500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/gloves_e6.jpg", ProductDescription = "Comfortable gloves for gym workouts.", CategoryId = 106 },
                new Product { ProductId = 42 , ProductName = "Yoga Mat F6", ProductShortName = "YM-F6", ProductPrice = 800, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/yogamat_f6.jpg", ProductDescription = "Non-slip yoga mat for daily exercises.", CategoryId = 106 },
                new Product { ProductId = 43 , ProductName = "Dumbbell Set G6", ProductShortName = "DB-G6", ProductPrice = 3000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/dumbbell_g6.jpg", ProductDescription = "Adjustable dumbbells for strength training.", CategoryId = 106 }
            );

            // Groceries (107)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 44 , ProductName = "Rice A7", ProductShortName = "RC-A7", ProductPrice = 80, DelevaryTimeSpan = "1-2 days", ImageFile = "https://example.com/images/rice_a7.jpg", ProductDescription = "High quality Basmati rice.", CategoryId = 107 },
                new Product { ProductId = 45 , ProductName = "Cooking Oil B7", ProductShortName = "CO-B7", ProductPrice = 150, DelevaryTimeSpan = "1-2 days", ImageFile = "https://example.com/images/oil_b7.jpg", ProductDescription = "Pure sunflower cooking oil.", CategoryId = 107 },
                new Product { ProductId = 46 , ProductName = "Sugar C7", ProductShortName = "SG-C7", ProductPrice = 60, DelevaryTimeSpan = "1-2 days", ImageFile = "https://example.com/images/sugar_c7.jpg", ProductDescription = "Refined white sugar for daily use.", CategoryId = 107 },
                new Product { ProductId = 47 , ProductName = "Salt D7", ProductShortName = "SL-D7", ProductPrice = 30, DelevaryTimeSpan = "1-2 days", ImageFile = "https://example.com/images/salt_d7.jpg", ProductDescription = "Fine table salt for cooking.", CategoryId = 107 },
                new Product { ProductId = 48 , ProductName = "Tea E7", ProductShortName = "TE-E7", ProductPrice = 200, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/tea_e7.jpg", ProductDescription = "Premium black tea leaves.", CategoryId = 107 },
                new Product { ProductId = 49 , ProductName = "Coffee F7", ProductShortName = "CF-F7", ProductPrice = 300, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/coffee_f7.jpg", ProductDescription = "Ground coffee for morning energy.", CategoryId = 107 },
                new Product { ProductId = 50 , ProductName = "Flour G7", ProductShortName = "FL-G7", ProductPrice = 70, DelevaryTimeSpan = "1-2 days", ImageFile = "https://example.com/images/flour_g7.jpg", ProductDescription = "Fine wheat flour for baking.", CategoryId = 107 }
            );
            // Beauty (108)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 51 , ProductName = "Lipstick A8", ProductShortName = "LP-A8", ProductPrice = 500, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/lipstick_a8.jpg", ProductDescription = "Long-lasting red lipstick for all occasions.", CategoryId = 108 },
                new Product { ProductId = 52 , ProductName = "Foundation B8", ProductShortName = "FD-B8", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/foundation_b8.jpg", ProductDescription = "Matte finish foundation for smooth skin.", CategoryId = 108 },
                new Product { ProductId = 53 , ProductName = "Eye Shadow C8", ProductShortName = "ES-C8", ProductPrice = 700, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/eyeshadow_c8.jpg", ProductDescription = "Vibrant colors for eye makeup.", CategoryId = 108 },
                new Product { ProductId = 54 , ProductName = "Perfume D8", ProductShortName = "PF-D8", ProductPrice = 2500, DelevaryTimeSpan = "2-5 days", ImageFile = "https://example.com/images/perfume_d8.jpg", ProductDescription = "Floral fragrance for everyday use.", CategoryId = 108 },
                new Product { ProductId = 55 , ProductName = "Nail Polish E8", ProductShortName = "NP-E8", ProductPrice = 300, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/nailpolish_e8.jpg", ProductDescription = "Quick-dry nail polish in multiple colors.", CategoryId = 108 },
                new Product { ProductId = 56 , ProductName = "Face Cream F8", ProductShortName = "FC-F8", ProductPrice = 900, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/facecream_f8.jpg", ProductDescription = "Moisturizing cream for healthy skin.", CategoryId = 108 },
                new Product { ProductId = 57 , ProductName = "Makeup Kit G8", ProductShortName = "MK-G8", ProductPrice = 3000, DelevaryTimeSpan = "2-5 days", ImageFile = "https://example.com/images/makeupkit_g8.jpg", ProductDescription = "Complete makeup kit for all occasions.", CategoryId = 108 }
            );

            // Automobile (109)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 58 , ProductName = "Car Seat Cover A9", ProductShortName = "CS-A9", ProductPrice = 1500, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/carseat_a9.jpg", ProductDescription = "Comfortable and durable car seat cover.", CategoryId = 109 },
                new Product { ProductId = 59 , ProductName = "Car Wax B9", ProductShortName = "CW-B9", ProductPrice = 700, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/carwax_b9.jpg", ProductDescription = "Protective wax for car body shine.", CategoryId = 109 },
                new Product { ProductId = 60 , ProductName = "Car Air Freshener C9", ProductShortName = "AF-C9", ProductPrice = 300, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/airfreshener_c9.jpg", ProductDescription = "Pleasant fragrance for your car.", CategoryId = 109 },
                new Product { ProductId = 61 , ProductName = "Car Battery D9", ProductShortName = "CB-D9", ProductPrice = 5000, DelevaryTimeSpan = "3-6 days", ImageFile = "https://example.com/images/battery_d9.jpg", ProductDescription = "Long-lasting car battery for all vehicles.", CategoryId = 109 },
                new Product { ProductId = 62 , ProductName = "Car Light E9", ProductShortName = "CL-E9", ProductPrice = 1200, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/carlight_e9.jpg", ProductDescription = "High-intensity LED car lights.", CategoryId = 109 },
                new Product { ProductId =63  , ProductName = "Steering Wheel Cover F9", ProductShortName = "SW-F9", ProductPrice = 600, DelevaryTimeSpan = "1-3 days", ImageFile = "https://example.com/images/steering_f9.jpg", ProductDescription = "Comfortable grip steering wheel cover.", CategoryId = 109 },
                new Product { ProductId =64  , ProductName = "Car Mat G9", ProductShortName = "CM-G9", ProductPrice = 900, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/carmat_g9.jpg", ProductDescription = "Durable car floor mats for protection.", CategoryId = 109 }
            );

            // Jewelry (110)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 65 , ProductName = "Gold Ring A10", ProductShortName = "GR-A10", ProductPrice = 5000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/goldring_a10.jpg", ProductDescription = "Elegant gold ring for all occasions.", CategoryId = 110 },
                new Product { ProductId = 66 , ProductName = "Silver Necklace B10", ProductShortName = "SN-B10", ProductPrice = 7000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/silvernecklace_b10.jpg", ProductDescription = "Beautiful silver necklace with pendant.", CategoryId = 110 },
                new Product { ProductId =67  , ProductName = "Bracelet C10", ProductShortName = "BR-C10", ProductPrice = 4000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/bracelet_c10.jpg", ProductDescription = "Stylish bracelet for daily wear.", CategoryId = 110 },
                new Product { ProductId =68  , ProductName = "Earrings D10", ProductShortName = "ER-D10", ProductPrice = 3500, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/earrings_d10.jpg", ProductDescription = "Diamond stud earrings for elegance.", CategoryId = 110 },
                new Product { ProductId = 69 , ProductName = "Pendant E10", ProductShortName = "PD-E10", ProductPrice = 6000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/pendant_e10.jpg", ProductDescription = "Gold pendant with intricate design.", CategoryId = 110 },
                new Product { ProductId = 70 , ProductName = "Bangle F10", ProductShortName = "BG-F10", ProductPrice = 4500, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/bangle_f10.jpg", ProductDescription = "Traditional bangle for women.", CategoryId = 110 },
                new Product { ProductId = 71 , ProductName = "Brooch G10", ProductShortName = "BR-G10", ProductPrice = 3000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/brooch_g10.jpg", ProductDescription = "Elegant brooch for formal wear.", CategoryId = 110 }
            );

            // Computers (111)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 72 , ProductName = "Laptop A11", ProductShortName = "LP-A11", ProductPrice = 55000, DelevaryTimeSpan = "5-7 days", ImageFile = "https://example.com/images/laptop_a11.jpg", ProductDescription = "High performance laptop for office and gaming.", CategoryId = 111 },
                new Product { ProductId =73  , ProductName = "Desktop B11", ProductShortName = "DT-B11", ProductPrice = 40000, DelevaryTimeSpan = "5-7 days", ImageFile = "https://example.com/images/desktop_b11.jpg", ProductDescription = "Powerful desktop computer for work.", CategoryId = 111 },
                new Product { ProductId = 74 , ProductName = "Keyboard C11", ProductShortName = "KB-C11", ProductPrice = 1500, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/keyboard_c11.jpg", ProductDescription = "Mechanical keyboard for smooth typing.", CategoryId = 111 },
                new Product { ProductId = 75 , ProductName = "Mouse D11", ProductShortName = "MS-D11", ProductPrice = 800, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/mouse_d11.jpg", ProductDescription = "Wireless mouse with ergonomic design.", CategoryId = 111 },
                new Product { ProductId = 76 , ProductName = "Monitor E11", ProductShortName = "MN-E11", ProductPrice = 12000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/monitor_e11.jpg", ProductDescription = "Full HD monitor for gaming and work.", CategoryId = 111 },
                new Product { ProductId = 78 , ProductName = "Printer F11", ProductShortName = "PR-F11", ProductPrice = 10000, DelevaryTimeSpan = "3-5 days", ImageFile = "https://example.com/images/printer_f11.jpg", ProductDescription = "Laser printer for office use.", CategoryId = 111 },
                new Product { ProductId =79  , ProductName = "Webcam G11", ProductShortName = "WC-G11", ProductPrice = 3000, DelevaryTimeSpan = "2-4 days", ImageFile = "https://example.com/images/webcam_g11.jpg", ProductDescription = "HD webcam for online meetings.", CategoryId = 111 }
            );


            base.OnModelCreating(modelBuilder);
        }







    }
}
