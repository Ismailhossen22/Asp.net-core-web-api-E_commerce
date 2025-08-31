using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bigbasket_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateTime", "DelevaryTimeSpan", "ImageFile", "ProductDescription", "ProductName", "ProductPrice", "ProductShortName", "Stock" },
                values: new object[,]
                {
                    { 1, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/smartphone_a1.jpg", "High quality smartphone with 10 features.", "Smartphone A1", 15000.0, "SM-A1", 0 },
                    { 2, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/laptop_b1.jpg", "Powerful laptop suitable for work and gaming.", "Laptop B1", 55000.0, "LP-B1", 0 },
                    { 3, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/headphones_c1.jpg", "Comfortable wireless headphones for daily use.", "Wireless Headphones C1", 5000.0, "WH-C1", 0 },
                    { 4, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/smartwatch_d1.jpg", "Feature-packed smartwatch with long battery life.", "Smartwatch D1", 8000.0, "SW-D1", 0 },
                    { 5, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 days", "https://example.com/images/tablet_e1.jpg", "Compact tablet perfect for work and media.", "Tablet E1", 20000.0, "TB-E1", 0 },
                    { 6, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/speaker_f1.jpg", "Portable Bluetooth speaker with crystal clear sound.", "Bluetooth Speaker F1", 3500.0, "BS-F1", 0 },
                    { 7, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-6 days", "https://example.com/images/camera_g1.jpg", "High-resolution camera for photography enthusiasts.", "Camera G1", 25000.0, "CM-G1", 0 },
                    { 8, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/tshirt_men_a2.jpg", "Cotton t-shirt perfect for summer season.", "Men's T-Shirt A2", 800.0, "TS-A2", 0 },
                    { 9, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/dress_women_b2.jpg", "Elegant dress suitable for parties and events.", "Women's Dress B2", 1500.0, "DR-B2", 0 },
                    { 10, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/jeans_men_c2.jpg", "Stylish and comfortable denim jeans.", "Men's Jeans C2", 1200.0, "JN-C2", 0 },
                    { 11, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/jacket_women_d2.jpg", "Warm jacket for chilly seasons.", "Women's Jacket D2", 2500.0, "JK-D2", 0 },
                    { 12, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/jacket_women_d2.jpg", "Warm jacket for chilly seasons.", "Women's Jacket D2", 2500.0, "JK-D2", 0 },
                    { 13, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/shoes_men_e2.jpg", "Comfortable and durable shoes for daily use.", "Men's Shoes E2", 2000.0, "SH-E2", 0 },
                    { 14, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/sandals_women_f2.jpg", "Lightweight and stylish sandals for summer.", "Women's Sandals F2", 1200.0, "SD-F2", 0 },
                    { 15, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/handbag_g2.jpg", "Trendy handbag to complement your outfit.", "Fashion Handbag G2", 3000.0, "HB-G2", 0 },
                    { 16, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/microwave_a3.jpg", "High efficiency microwave oven.", "Microwave A3", 8000.0, "MW-A3", 0 },
                    { 17, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4-6 days", "https://example.com/images/fridge_b3.jpg", "Spacious refrigerator with energy saving.", "Refrigerator B3", 35000.0, "RF-B3", 0 },
                    { 18, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-6 days", "https://example.com/images/washing_c3.jpg", "Efficient washing machine for families.", "Washing Machine C3", 25000.0, "WM-C3", 0 },
                    { 19, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-7 days", "https://example.com/images/ac_d3.jpg", "Powerful AC to cool large rooms.", "Air Conditioner D3", 40000.0, "AC-D3", 0 },
                    { 20, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/blender_e3.jpg", "Multi-function blender for kitchen use.", "Blender E3", 3000.0, "BL-E3", 0 },
                    { 21, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/toaster_f3.jpg", "Convenient toaster for breakfast.", "Toaster F3", 1500.0, "TS-F3", 0 },
                    { 22, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-3 days", "https://example.com/images/kettle_g3.jpg", "Fast boiling electric kettle.", "Electric Kettle G3", 1800.0, "EK-G3", 0 },
                    { 23, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/novel_a4.jpg", "Engaging novel with great story.", "Novel A4", 500.0, "NV-A4", 0 },
                    { 24, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/textbook_b4.jpg", "Educational textbook for students.", "Textbook B4", 1200.0, "TB-B4", 0 },
                    { 25, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/comic_c4.jpg", "Fun comic book for kids.", "Comic Book C4", 300.0, "CB-C4", 0 },
                    { 26, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/science_d4.jpg", "Informative science book.", "Science Book D4", 800.0, "SB-D4", 0 },
                    { 27, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/history_e4.jpg", "Interesting history book.", "History Book E4", 700.0, "HB-E4", 0 },
                    { 28, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/dictionary_f4.jpg", "Comprehensive dictionary.", "Dictionary F4", 900.0, "DC-F4", 0 },
                    { 29, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/magazine_g4.jpg", "Latest magazine for readers.", "Magazine G4", 400.0, "MG-G4", 0 },
                    { 30, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/action_figure_a5.jpg", "Collectible action figure toy for kids.", "Action Figure A5", 800.0, "AF-A5", 0 },
                    { 31, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/doll_b5.jpg", "Beautiful doll with dress and accessories.", "Doll B5", 500.0, "DL-B5", 0 },
                    { 32, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/puzzle_c5.jpg", "Fun puzzle game to improve problem solving.", "Puzzle C5", 300.0, "PZ-C5", 0 },
                    { 33, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/toy_car_d5.jpg", "Miniature car for kids to play.", "Toy Car D5", 400.0, "TC-D5", 0 },
                    { 34, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 days", "https://example.com/images/board_game_e5.jpg", "Family board game for fun evenings.", "Board Game E5", 700.0, "BG-E5", 0 },
                    { 35, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/blocks_f5.jpg", "Colorful building blocks for kids.", "Building Blocks F5", 600.0, "BB-F5", 0 },
                    { 36, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/remote_car_g5.jpg", "Remote control car with rechargeable battery.", "Remote Car G5", 1500.0, "RC-G5", 0 },
                    { 37, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/football_a6.jpg", "Official size football for matches.", "Football A6", 1200.0, "FB-A6", 0 },
                    { 38, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/basketball_b6.jpg", "Durable basketball for indoor/outdoor use.", "Basketball B6", 1500.0, "BB-B6", 0 },
                    { 39, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/racket_c6.jpg", "Lightweight tennis racket for beginners.", "Tennis Racket C6", 2000.0, "TR-C6", 0 },
                    { 40, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/bat_d6.jpg", "Professional grade cricket bat.", "Cricket Bat D6", 2500.0, "CB-D6", 0 },
                    { 41, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/gloves_e6.jpg", "Comfortable gloves for gym workouts.", "Gym Gloves E6", 500.0, "GG-E6", 0 },
                    { 42, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/yogamat_f6.jpg", "Non-slip yoga mat for daily exercises.", "Yoga Mat F6", 800.0, "YM-F6", 0 },
                    { 43, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/dumbbell_g6.jpg", "Adjustable dumbbells for strength training.", "Dumbbell Set G6", 3000.0, "DB-G6", 0 },
                    { 44, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 days", "https://example.com/images/rice_a7.jpg", "High quality Basmati rice.", "Rice A7", 80.0, "RC-A7", 0 },
                    { 45, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 days", "https://example.com/images/oil_b7.jpg", "Pure sunflower cooking oil.", "Cooking Oil B7", 150.0, "CO-B7", 0 },
                    { 46, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 days", "https://example.com/images/sugar_c7.jpg", "Refined white sugar for daily use.", "Sugar C7", 60.0, "SG-C7", 0 },
                    { 47, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 days", "https://example.com/images/salt_d7.jpg", "Fine table salt for cooking.", "Salt D7", 30.0, "SL-D7", 0 },
                    { 48, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/tea_e7.jpg", "Premium black tea leaves.", "Tea E7", 200.0, "TE-E7", 0 },
                    { 49, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/coffee_f7.jpg", "Ground coffee for morning energy.", "Coffee F7", 300.0, "CF-F7", 0 },
                    { 50, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-2 days", "https://example.com/images/flour_g7.jpg", "Fine wheat flour for baking.", "Flour G7", 70.0, "FL-G7", 0 },
                    { 51, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/lipstick_a8.jpg", "Long-lasting red lipstick for all occasions.", "Lipstick A8", 500.0, "LP-A8", 0 },
                    { 52, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/foundation_b8.jpg", "Matte finish foundation for smooth skin.", "Foundation B8", 1200.0, "FD-B8", 0 },
                    { 53, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/eyeshadow_c8.jpg", "Vibrant colors for eye makeup.", "Eye Shadow C8", 700.0, "ES-C8", 0 },
                    { 54, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 days", "https://example.com/images/perfume_d8.jpg", "Floral fragrance for everyday use.", "Perfume D8", 2500.0, "PF-D8", 0 },
                    { 55, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/nailpolish_e8.jpg", "Quick-dry nail polish in multiple colors.", "Nail Polish E8", 300.0, "NP-E8", 0 },
                    { 56, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/facecream_f8.jpg", "Moisturizing cream for healthy skin.", "Face Cream F8", 900.0, "FC-F8", 0 },
                    { 57, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-5 days", "https://example.com/images/makeupkit_g8.jpg", "Complete makeup kit for all occasions.", "Makeup Kit G8", 3000.0, "MK-G8", 0 },
                    { 58, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/carseat_a9.jpg", "Comfortable and durable car seat cover.", "Car Seat Cover A9", 1500.0, "CS-A9", 0 },
                    { 59, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/carwax_b9.jpg", "Protective wax for car body shine.", "Car Wax B9", 700.0, "CW-B9", 0 },
                    { 60, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/airfreshener_c9.jpg", "Pleasant fragrance for your car.", "Car Air Freshener C9", 300.0, "AF-C9", 0 },
                    { 61, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-6 days", "https://example.com/images/battery_d9.jpg", "Long-lasting car battery for all vehicles.", "Car Battery D9", 5000.0, "CB-D9", 0 },
                    { 62, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/carlight_e9.jpg", "High-intensity LED car lights.", "Car Light E9", 1200.0, "CL-E9", 0 },
                    { 63, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-3 days", "https://example.com/images/steering_f9.jpg", "Comfortable grip steering wheel cover.", "Steering Wheel Cover F9", 600.0, "SW-F9", 0 },
                    { 64, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/carmat_g9.jpg", "Durable car floor mats for protection.", "Car Mat G9", 900.0, "CM-G9", 0 },
                    { 65, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/goldring_a10.jpg", "Elegant gold ring for all occasions.", "Gold Ring A10", 5000.0, "GR-A10", 0 },
                    { 66, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/silvernecklace_b10.jpg", "Beautiful silver necklace with pendant.", "Silver Necklace B10", 7000.0, "SN-B10", 0 },
                    { 67, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/bracelet_c10.jpg", "Stylish bracelet for daily wear.", "Bracelet C10", 4000.0, "BR-C10", 0 },
                    { 68, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/earrings_d10.jpg", "Diamond stud earrings for elegance.", "Earrings D10", 3500.0, "ER-D10", 0 },
                    { 69, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/pendant_e10.jpg", "Gold pendant with intricate design.", "Pendant E10", 6000.0, "PD-E10", 0 },
                    { 70, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/bangle_f10.jpg", "Traditional bangle for women.", "Bangle F10", 4500.0, "BG-F10", 0 },
                    { 71, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/brooch_g10.jpg", "Elegant brooch for formal wear.", "Brooch G10", 3000.0, "BR-G10", 0 },
                    { 72, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-7 days", "https://example.com/images/laptop_a11.jpg", "High performance laptop for office and gaming.", "Laptop A11", 55000.0, "LP-A11", 0 },
                    { 73, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-7 days", "https://example.com/images/desktop_b11.jpg", "Powerful desktop computer for work.", "Desktop B11", 40000.0, "DT-B11", 0 },
                    { 74, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/keyboard_c11.jpg", "Mechanical keyboard for smooth typing.", "Keyboard C11", 1500.0, "KB-C11", 0 },
                    { 75, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/mouse_d11.jpg", "Wireless mouse with ergonomic design.", "Mouse D11", 800.0, "MS-D11", 0 },
                    { 76, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/monitor_e11.jpg", "Full HD monitor for gaming and work.", "Monitor E11", 12000.0, "MN-E11", 0 },
                    { 78, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-5 days", "https://example.com/images/printer_f11.jpg", "Laser printer for office use.", "Printer F11", 10000.0, "PR-F11", 0 },
                    { 79, 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-4 days", "https://example.com/images/webcam_g11.jpg", "HD webcam for online meetings.", "Webcam G11", 3000.0, "WC-G11", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 79);
        }
    }
}
